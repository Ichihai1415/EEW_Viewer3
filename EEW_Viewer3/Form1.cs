
using EEW_Viewer3.Utilities;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using static EEW_Viewer3.Utilities.Utils;

namespace EEW_Viewer3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal static HttpClient client = new();

        private async void Form1_Load(object sender, EventArgs e)
        {
            Debug();
#if DEBUG2
            ConWrite("<お知らせ>[Form1_Load]Debug2構成のため取得しません。");
#else
            await Get();
#endif
        }

        public static void Debug()
        {
#if !DEBUG2
            throw new Exception("Debug2構成のみ有効です。");
#endif
            /*//jsonから
            var jsonSt = File.ReadAllText(@"C:\Ichihai1415\source\vs\EEW_Viewer3\EEW_Viewer3\ReferenceData\20250324113843.5945.json");
            var jsonN = JsonNode.Parse(jsonSt);
            var type = (string?)jsonN["type"];
            ConWrite("[Debug]type=" + type);
            var json = JsonSerializer.Deserialize<WebSocketV2_Response_Data>(jsonSt);
            ConWrite("[Debug]Compression=" + json.Compression);
            ConWrite("[Debug]Encoding=" + json.Encoding);
            var bodySt = ExtractDataString(json.Body, json.Compression, json.Encoding);
            ConWrite(bodySt, ConsoleColor.Green);
            */

            //xmlから
            var bodySt = File.ReadAllText(@"C:\Ichihai1415\source\vs\EEW_Viewer3\EEW_Viewer3\ReferenceData\77_01_17_240613_VXSE45.xml");

            var xml = new XmlDocument();
            xml.LoadXml(bodySt);
            var nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("xmlns_jmx", "http://xml.kishou.go.jp/jmaxml1/");
            nsmgr.AddNamespace("xmlns_ib", "http://xml.kishou.go.jp/jmaxml1/informationBasis1/");
            nsmgr.AddNamespace("xmlns_se", "http://xml.kishou.go.jp/jmaxml1/body/seismology1/");
            nsmgr.AddNamespace("xmlns_eb", "http://xml.kishou.go.jp/jmaxml1/elementBasis1/");

            var report = xml.SelectSingleNode("xmlns_jmx:Report", nsmgr);
            var report_control = report.SelectSingleNode("xmlns_jmx:Control", nsmgr);

            var report_head = report.SelectSingleNode("xmlns_ib:Head", nsmgr);
            var report_head_headline = report_head.SelectSingleNode("xmlns_ib:Headline", nsmgr);


            var report_head_headline_information_s = report_head_headline.SelectNodes("xmlns_ib:Information", nsmgr);
            var newInfo = new List<DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information>();
            foreach (XmlNode information in report_head_headline_information_s)
            {
                var report_head_headline_information_item_s = information.SelectNodes("xmlns_ib:Item", nsmgr);
                var newItems = new List<DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item>();
                foreach (XmlNode item in report_head_headline_information_item_s)
                {
                    var item_kind = item.SelectSingleNode("xmlns_ib:Kind", nsmgr);
                    var item_lastKind = item.SelectSingleNode("xmlns_ib:LastKind", nsmgr);
                    var item_areas = item.SelectSingleNode("xmlns_ib:Areas", nsmgr);
                    var item_area_s = item_areas.SelectNodes("xmlns_ib:Area", nsmgr);
                    var newAreas = new List<DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item.C_Areas.C_Area>();
                    foreach (XmlNode area in item_area_s)
                        newAreas.Add(new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item.C_Areas.C_Area
                        {
                            Name = area.SelectSingleNode("xmlns_ib:Name", nsmgr).InnerText,
                            Code = area.SelectSingleNode("xmlns_ib:Code", nsmgr).InnerText,
                        });
                    newItems.Add(new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item
                    {
                        Kind = new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item.C_Kind
                        {
                            Name = item_kind.SelectSingleNode("xmlns_ib:Name", nsmgr).InnerText,
                            Code = item_kind.SelectSingleNode("xmlns_ib:Code", nsmgr).InnerText
                        },
                        LastKind = new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item.C_LastKind
                        {
                            Name = item_lastKind.SelectSingleNode("xmlns_ib:Name", nsmgr).InnerText,
                            Code = item_lastKind.SelectSingleNode("xmlns_ib:Code", nsmgr).InnerText
                        },
                        Areas = new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information.C_Item.C_Areas
                        {
                            A_CodeType = item_areas.Attributes["codeType"].Value,
                            Areas = [.. newAreas]
                        }
                    });
                }

                newInfo.Add(new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline.C_Information
                {
                    A_Type = information.Attributes["type"].Value,
                    Item = [.. newItems]
                });
            }

            var report_body = report.SelectSingleNode("xmlns_se:Body", nsmgr);


            var data = new DataClasses.JMA.EarthquakeEarlyWarning
            {
                Control = new DataClasses.JMA.EqVol_Common.C_Control
                {
                    Title = report_control.SelectSingleNode("xmlns_jmx:Title", nsmgr).InnerText,
                    AnnouncementDateTime = DateTime.Parse(report_control.SelectSingleNode("xmlns_jmx:DateTime", nsmgr).InnerText),
                    Status = report_control.SelectSingleNode("xmlns_jmx:Status", nsmgr).InnerText,
                    EditorialOffice = report_control.SelectSingleNode("xmlns_jmx:EditorialOffice", nsmgr).InnerText,
                    PublishingOffice = report_control.SelectSingleNode("xmlns_jmx:PublishingOffice", nsmgr).InnerText
                },
                Head = new DataClasses.JMA.EarthquakeEarlyWarning.C_Head
                {
                    Title = report_head.SelectSingleNode("xmlns_ib:Title", nsmgr).InnerText,
                    ReportDateTime = DateTime.Parse(report_head.SelectSingleNode("xmlns_ib:ReportDateTime", nsmgr).InnerText),
                    TargetDateTime = DateTime.Parse(report_head.SelectSingleNode("xmlns_ib:TargetDateTime", nsmgr).InnerText),
                    EventID = report_head.SelectSingleNode("xmlns_ib:EventID", nsmgr).InnerText,
                    InfoType = report_head.SelectSingleNode("xmlns_ib:InfoType", nsmgr).InnerText,
                    Serial = report_head.SelectSingleNode("xmlns_ib:Serial", nsmgr).InnerText,
                    InfoKind = report_head.SelectSingleNode("xmlns_ib:InfoKind", nsmgr).InnerText,
                    InfoKindVersion = report_head.SelectSingleNode("xmlns_ib:InfoKindVersion", nsmgr).InnerText,
                    Headline = new DataClasses.JMA.EarthquakeEarlyWarning.C_Head.C_Headline
                    {
                        Text = report_head_headline.SelectSingleNode("xmlns_ib:Text", nsmgr).InnerText,
                        Information = [.. newInfo]
                    }
                }
            };
        }

        internal static int? socketId = null;

        /// <summary>
        /// WebSocketでデータを受信します。
        /// </summary>
        /// <returns>(なし)</returns>
        public async Task Get()
        {
            while (true)
                try
                {
                    using (ClientWebSocket client = new())
                    {
                    connect:
                        var (url, socketId) = await ConnectDMDSS.GetWebSocketUrlID("AKe.wwF_Lx5WaSO_7GXSt8Ttvud0rJabS3Odkwf1wDO9Mli8");
                        await client.ConnectAsync(new Uri(url), CancellationToken.None);
                        ConWrite("[Get]接続しました");
                        while (client.State == WebSocketState.Open)
                        {
                            byte[] buffer = new byte[256 * 1024];//分割されるからこんなに要らないかも
                            int bytesRead = 0;
                            while (true)//受信
                            {
                                var segment = new ArraySegment<byte>(buffer, bytesRead, buffer.Length - bytesRead);
                                WebSocketReceiveResult result = await client.ReceiveAsync(segment, CancellationToken.None);
                                if (result.MessageType == WebSocketMessageType.Close)
                                {
                                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                                    ConWrite("[Get]切断されました。再接続します。");
                                    goto connect;
                                }
                                else if (result.MessageType != WebSocketMessageType.Text)//あとBinaryしかない
                                {
                                    ConWrite($"[Get]未対応のタイプです(WebSocketMessageType.{result.MessageType})", ConsoleColor.Red);
                                    continue;
                                }
                                bytesRead += result.Count;
                                if (result.EndOfMessage) break;
                            }
                            string jsonText = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            if (jsonText == null) continue;
                            if (jsonText == string.Empty) continue;
                            if (File.Exists("log-all"))//エラー出ても保存できるように臨時
                                WriteLog(@$"output\json-all\" + DateTime.Now.ToString("yyyyMM\\dd\\HH\\yyyyMMddHHmmss.ffff") + ".json", jsonText);
                            var json = JsonNode.Parse(jsonText);
                            if (json == null) continue;
                            var type = (string?)json["type"];
                            ConWrite($"[Get]Received  type:{type}", ConsoleColor.Green);
                            try
                            {
                                switch (type)
                                {
                                    case "ping":
                                        var pong = new DataClasses.DMDSS.WebSocketV2_Response_PingPong() { Type = "pong", PingId = (string)json["pingId"] };
                                        var pongSt = JsonSerializer.Serialize(pong);
                                        await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(pongSt)), WebSocketMessageType.Text, true, CancellationToken.None);
                                        ConWrite($"[Get]Sent  {pongSt}", ConsoleColor.DarkGreen);
                                        break;
                                    case "data":
                                        WriteLog(@$"output\json-data\" + DateTime.Now.ToString("yyyyMM\\dd\\HH\\yyyyMMddHHmmss.ffff") + ".json", jsonText);
                                        break;
                                    default:
                                        WriteLog(@$"output\json\" + DateTime.Now.ToString("yyyyMM\\dd\\HH\\yyyyMMddHHmmss.ffff") + ".json", jsonText);
                                        break;
                                }

                            }
                            catch (Exception ex)
                            {
                                ConWrite($"[Get](JSON分析失敗)", ex);
                                Directory.CreateDirectory($"Log\\Error\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}");
                                File.WriteAllText($"Log\\Error\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}\\{DateTime.Now:yyyyMMddHHmmss.ffff}.txt", $"{ex}");
                                continue;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ConWrite($"[Get]", ex);
                    if (!(ex.Message.Contains("リモート サーバーに接続できません。") || ex.Message.Contains("内部 WebSocket エラーが発生しました。")))//変える必要
                        WriteLog(@"output\Error\" + DateTime.Now.ToString("yyyyMM\\dd\\yyyyMMddHHmmss.ffff") + ".txt", ex);
                    await Task.Delay(10000);
                    ConWrite("[Get]切断されました。再接続します。");
                }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socketId != null)
            {
                var closeCheck = await ConnectDMDSS.CloseWebSocket((int)socketId);
                if (closeCheck == null)
                    ConWrite("[Form1_FormClosing]正常に切断しました。");
                else
                    ConWrite("[Form1_FormClosing]切断に失敗しました。" + closeCheck, ConsoleColor.Red);
            }
        }
    }
}
