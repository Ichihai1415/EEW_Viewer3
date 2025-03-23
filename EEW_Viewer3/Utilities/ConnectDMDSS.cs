using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EEW_Viewer3.Utilities
{
    internal class ConnectDMDSS
    {

        public static async Task<string> GetWebSocketUrl(string apiKey)
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
                    return resData.Websocket.Url;
            }
            throw new Exception("Failed");
        }

    }
}
