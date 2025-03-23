
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
        /// WebSocket�Ńf�[�^����M���܂��B
        /// </summary>
        /// <returns>(�Ȃ�)</returns>
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
                        ConWrite("[Get]�ڑ����܂���");
                        while (client.State == WebSocketState.Open)
                        {
                            byte[] buffer = new byte[256 * 1024];//��������邩�炱��Ȃɗv��Ȃ�����
                            int bytesRead = 0;
                            while (true)//��M
                            {
                                var segment = new ArraySegment<byte>(buffer, bytesRead, buffer.Length - bytesRead);
                                WebSocketReceiveResult result = await client.ReceiveAsync(segment, CancellationToken.None);
                                if (result.MessageType == WebSocketMessageType.Close)
                                {
                                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                                    ConWrite("[Get]�ؒf����܂����B�Đڑ����܂��B");
                                    goto connect;
                                }
                                else if (result.MessageType != WebSocketMessageType.Text)//����Binary�����Ȃ�
                                {
                                    ConWrite($"[Get]���Ή��̃^�C�v�ł�(WebSocketMessageType.{result.MessageType})", ConsoleColor.Red);
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
                                ConWrite($"[Get](JSON���͎��s)", ex);
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
                    if (!(ex.Message.Contains("�����[�g �T�[�o�[�ɐڑ��ł��܂���B") || ex.Message.Contains("���� WebSocket �G���[���������܂����B")))
                    {
                        Directory.CreateDirectory($"Log\\Error\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}");
                        File.WriteAllText($"Log\\Error\\{DateTime.Now:yyyyMM}\\{DateTime.Now:dd}\\{DateTime.Now:yyyyMMddHHmmss.ffff}.txt", $"{ex}");
                    }
                    await Task.Delay(10000);
                    ConWrite("[Get]�ؒf����܂����B�Đڑ����܂��B");
                }
        }


    }
}
