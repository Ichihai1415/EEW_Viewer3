
using EEW_Viewer3.Utilities;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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
            await Get();
        }


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
                        string url = await ConnectDMDSS.GetWebSocketUrl("AKe.wwF_Lx5WaSO_7GXSt8Ttvud0rJabS3Odkwf1wDO9Mli8");
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
                                if (result.EndOfMessage)
                                    break;
                            }
                            string jsonText = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            if (jsonText == null)
                                continue;
                            if (jsonText == string.Empty)
                                continue;
                            if (true)//output
                            {
                                Directory.CreateDirectory($"output\\json\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}\\{DateTime.Now:HH}");
                                File.WriteAllText($"output\\json\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}\\{DateTime.Now:HH}\\{DateTime.Now:yyyyMMddHHmmss.ffff}.json", jsonText);
                            }
                            JsonNode? json;
                            try
                            {
                                json = JsonNode.Parse(jsonText);
                                var type = (string?)json["type"];
                                ConWrite($"[Get]Received  type:{type}", ConsoleColor.Green);
                                switch (type)
                                {
                                    case "ping":
                                        var pong = new DataClasses.DMDSS.WebSocketV2_Response_PingPong() { Type = "pong", PingId = (string)json["pingId"] };
                                        var pongSt = JsonSerializer.Serialize(pong);
                                        await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(pongSt)), WebSocketMessageType.Text, true, CancellationToken.None);
                                        ConWrite($"[Get]Sent  {pongSt}", ConsoleColor.DarkGreen);
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
                    if (!(ex.Message.Contains("リモート サーバーに接続できません。") || ex.Message.Contains("内部 WebSocket エラーが発生しました。")))
                    {
                        Directory.CreateDirectory($"Log\\Error\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}");
                        File.WriteAllText($"Log\\Error\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}\\{DateTime.Now:yyyyMMddHHmmss.ffff}.txt", $"{ex}");
                    }
                    await Task.Delay(10000);
                    ConWrite("[Get]切断されました。再接続します。");
                }
        }


    }
}
