using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace EEW_Viewer3.Utilities
{
    /// <summary>
    /// Project DM(Disaster Mitigation)-Data Send Service 接続関連クラス
    /// </summary>
    internal class ConnectDMDSS//todo:実装が雑なのでちゃんと作る
    {
        /// <summary>
        /// Socket Start v2 : WebSocket v2 にアクセスするURLとSocketIDを取得します。
        /// </summary>
        /// <remarks>権限にsocket.start, eew.get.forecastが必要です。</remarks>
        /// <param name="apiKey">APIキー</param>
        /// <returns>WebSocketのURL</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<(string Url, int SocketId)> GetWebSocketUrlID(string apiKey)
        {
            var reqBody = new DataClasses.DMDSS.SocketV2_SocketStartV2_Request_RequestBody()
            {
                Classifications = ["eew.forecast"],
                Types = ["VXSE45"]
            };

            var req = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.dmdata.jp/v2/socket"),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(reqBody), Encoding.UTF8, "application/json")
            };
            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", Converters.GetBasicBase64(apiKey));

            var res = await Form1.client.SendAsync(req);
            if (res.Content != null)
            {
                var resSt = await res.Content.ReadAsStringAsync();
                var resData = JsonSerializer.Deserialize<DataClasses.DMDSS.SocketV2_SocketStartV2_Response_Marge>(resSt);
                if (resData.Websocket != null)
                    return (resData.Websocket.Url, resData.Websocket.Id);
            }
            throw new Exception("Failed");
        }

        /// <summary>
        /// Socket Close v2 : WebSocket v2 に接続中のWebSocketを終了します。
        /// </summary>
        /// <remarks>権限にsocket.closeが必要です。</remarks>
        /// <param name="socketId"></param>
        /// <returns>[status: ok 成功時には何も返しません。]レスポンスデータがない場合<see cref="null"/>、status: errorの場合エラー内容</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string?> CloseWebSocket(int socketId)
        {
            var res = await Form1.client.DeleteAsync("https://api.dmdata.jp/v2/socket/" + socketId);
            if (res.StatusCode == HttpStatusCode.NotFound) throw new Exception("WebSocketの切断に失敗しました。", new ArgumentException("Socket IDが正しくありません(404 Socket ID not found.)。"));
            if (res == null) return null;
            var resSt = await res.Content.ReadAsStringAsync();
            if (resSt == null) return null;
            if (resSt == string.Empty) return null;
            var resData = JsonNode.Parse(resSt);
            if ((string)resData["status"] == "error") return (string?)resData["error"]["message"];
            throw new Exception("未実装データあるいは処理ミスです。");
        }


    }
}
