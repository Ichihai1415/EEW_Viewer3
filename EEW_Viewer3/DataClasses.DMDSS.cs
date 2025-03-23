using System.Text.Json.Serialization;

namespace EEW_Viewer3
{
    public partial class DataClasses
    {
        public class DMDSS
        {
            /// <summary>
            /// Socket Start v2　リクエスト　リクエストボディ(JSON)
            /// </summary>
            /// <remarks><see href="https://dmdata.jp/docs/reference/api/v2/socket.start#%E3%83%AA%E3%82%AF%E3%82%A8%E3%82%B9%E3%83%88%E3%83%9C%E3%83%87%E3%82%A3json"/></remarks>
            public class SocketStartV2_Request_RequestBody
            {
                /// <summary>
                /// Array<String> WebSocketで取得する配信区分を指定。電文データ 区分(API名)を指定、ファイル形式データは指定できない
                /// </summary>
                [JsonPropertyName("classifications")]
                public required string[] Classifications { get; set; }
                /// <summary>
                /// Array<String> データ種類コードを指定。データ種類コードの前に「!」を付記することによって、配信しないように設定することができる 例："!VXSE44" 最大30個まで指定可能
                /// </summary>
                [JsonPropertyName("types")]
                public string[]? Types { get; set; }
                /// <summary>
                /// String テスト電文を受け取るか指定。受け取る場合は including にする。注意：XML電文以外のテスト配信は no 時も配信されます。本文中を参照するようにしてください。
                /// </summary>
                /// <remarks>デフォルト: no</remarks>
                [JsonPropertyName("test")]
                public string? Test { get; set; }
                /// <summary>
                /// String アプリケーション名を指定。最大24バイトまで
                /// </summary>
                [JsonPropertyName("appName")]
                public string? AppName { get; set; }
                /// <summary>
                /// String データフォーマットの指定。生電文: raw、JSON化データ: json
                /// </summary>
                /// <remarks>デフォルト: raw</remarks>
                [JsonPropertyName("formatMode")]
                public string? FormatMode { get; set; }
            }

            /// <summary>
            /// Socket Start v2　レスポンス　を統合したもの
            /// </summary>
            /// <remarks><see href="https://dmdata.jp/docs/reference/api/v2/socket.start#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9"/></remarks>
            public class SocketStartV2_Response_Marge
            {
                /// <summary>
                /// [共通] String API処理ID
                /// </summary>
                [JsonPropertyName("responseId")]
                public required string ResponseId { get; set; }

                /// <summary>
                /// [共通] ISO8601Time API処理時刻
                /// </summary>
                [JsonPropertyName("responseTime")]
                public required DateTime ResponseTime { get; set; }

                /// <summary>
                /// [共通] String 成功時は ok、失敗時（エラー）は error
                /// </summary>
                [JsonPropertyName("status")]
                public required string Status { get; set; }

                /// <summary>
                /// [status: ok] String WebSocketに接続するためのticket
                /// </summary>
                [JsonPropertyName("ticket")]
                public string? Ticket { get; set; }

                /// <summary>
                /// [status: ok] Object WebSocketへの接続情報
                /// </summary>
                [JsonPropertyName("websocket")]
                public SocketStartV2_Response_StatusOK.C_Websocket? Websocket { get; set; }

                /// <summary>
                /// [status: ok] Array<String> WebSocketで受け取る配信区分
                /// </summary>
                [JsonPropertyName("classifications")]
                public string[]? Classifications { get; set; }

                /// <summary>
                /// [status: ok] String including の時のみ、XML電文のテストをWebsocketで受け取る
                /// </summary>
                [JsonPropertyName("test")]
                public string? Test { get; set; }

                /// <summary>
                /// [status: ok] Array<String>|Null WebSocketで受け取るデータ種類コードリスト。Null 時は受け取る配信区分の全部を受け取る
                /// </summary>
                [JsonPropertyName("types")]
                public string[]? Types { get; set; }

                /// <summary>
                /// [status: ok] Array<String> WebSocketで受け取る情報フォーマット
                /// </summary>
                [JsonPropertyName("formats")]
                public string[]? Formats { get; set; }

                /// <summary>
                /// [status: ok] String|Null リクエストで指定したアプリ名
                /// </summary>
                [JsonPropertyName("appName")]
                public string? AppName { get; set; }

                /// <summary>
                /// [status: error] Object エラー情報。
                /// </summary>
                [JsonPropertyName("error")]
                public SocketStartV2_Response_StatusError.C_Error? Error { get; set; }
            }

            #region 通常参照しない(SocketStartV2_Response_StatusOK/SocketStartV2_Response_StatusError)
            /// <summary>
            /// Socket Start v2　レスポンス　status: ok
            /// </summary>
            /// <remarks><see href="https://dmdata.jp/docs/reference/api/v2/socket.start#status-ok"/></remarks>
            public class SocketStartV2_Response_StatusOK
            {
                /// <summary>
                /// String API処理ID
                /// </summary>
                [JsonPropertyName("responseId")]
                public required string ResponseId { get; set; }

                /// <summary>
                /// ISO8601Time API処理時刻
                /// </summary>
                [JsonPropertyName("responseTime")]
                public required DateTime ResponseTime { get; set; }

                /// <summary>
                /// String 成功時は ok、失敗時（エラー）は error
                /// </summary>
                [JsonPropertyName("status")]
                public required string Status { get; set; }

                /// <summary>
                /// String WebSocketに接続するためのticket
                /// </summary>
                [JsonPropertyName("ticket")]
                public required string Ticket { get; set; }

                /// <summary>
                /// Object WebSocketへの接続情報
                /// </summary>
                [JsonPropertyName("websocket")]
                public required C_Websocket Websocket { get; set; }

                /// <summary>
                /// Array<String> WebSocketで受け取る配信区分
                /// </summary>
                [JsonPropertyName("classifications")]
                public required string[] Classifications { get; set; }

                /// <summary>
                /// String including の時のみ、XML電文のテストをWebsocketで受け取る
                /// </summary>
                [JsonPropertyName("test")]
                public required string Test { get; set; }

                /// <summary>
                /// Array<String>|Null WebSocketで受け取るデータ種類コードリスト。Null 時は受け取る配信区分の全部を受け取る
                /// </summary>
                [JsonPropertyName("types")]
                public required string[] Types { get; set; }

                /// <summary>
                /// Array<String> WebSocketで受け取る情報フォーマット
                /// </summary>
                [JsonPropertyName("formats")]
                public required string[] Formats { get; set; }

                /// <summary>
                /// String|Null リクエストで指定したアプリ名
                /// </summary>
                [JsonPropertyName("appName")]
                public required string AppName { get; set; }

                /// <summary>
                /// WebSocketへの接続情報
                /// </summary>
                public class C_Websocket
                {
                    /// <summary>
                    /// Integer|String<Integer> WebSocketID
                    /// </summary>
                    [JsonPropertyName("id")]
                    public required int Id { get; set; }

                    /// <summary>
                    /// String WebSocketの接続先URLでticket付き
                    /// </summary>
                    [JsonPropertyName("url")]
                    public required string Url { get; set; }

                    /// <summary>
                    /// Array<String> WebSocketのProtocolで配列の要素は dmdata.v2 一つで固定
                    /// </summary>
                    [JsonPropertyName("protocol")]
                    public required string[] Protocol { get; set; }

                    /// <summary>
                    /// String|Null リクエストで指定したアプリ名
                    /// </summary>
                    [JsonPropertyName("expiration")]
                    public required int Expiration { get; set; }
                }

            }

            /// <summary>
            /// Socket Start v2　レスポンス　status: error
            /// </summary>
            /// <remarks><see href="https://dmdata.jp/docs/reference/api/v2/socket.start#status-error"/></remarks>
            public class SocketStartV2_Response_StatusError
            {
                /// <summary>
                /// String API処理ID
                /// </summary>
                [JsonPropertyName("responseId")]
                public required string ResponseId { get; set; }

                /// <summary>
                /// ISO8601Time API処理時刻
                /// </summary>
                [JsonPropertyName("responseTime")]
                public required DateTime ResponseTime { get; set; }

                /// <summary>
                /// String 成功時は ok、失敗時（エラー）は error
                /// </summary>
                [JsonPropertyName("status")]
                public required string Status { get; set; }

                /// <summary>
                /// Object WebSocketへの接続情報
                /// </summary>
                [JsonPropertyName("error")]
                public required C_Error Error { get; set; }

                /// <summary>
                /// WebSocketへの接続情報
                /// </summary>
                public class C_Error
                {
                    /// <summary>
                    /// String エラーメッセージ、標準エラーおよび別表参照
                    /// </summary>
                    [JsonPropertyName("message")]
                    public required string Message { get; set; }

                    /// <summary>
                    /// Integer HTTPステータスコード
                    /// </summary>
                    [JsonPropertyName("code")]
                    public required int Code { get; set; }
                    /*
                     * ステータスコード	エラーメッセージ	説明
                     * 400	The body of the request is not json.	リクエストボディにJSON形式のデータがない
                     * 400	At least one element of `classifications` is required.	配信区分が指定されていない
                     * 400	The `types` is not a string or has more than 30 elements.	データ種類コードに不正な文字列があるか、30個以上指定されている
                     * 400	The `appName` is up to 24 bytes.	appNameに文字列でないか、24バイト以上の文字列が入力されている
                     * 400	You have entered a string that is not defined in `formatMode`.	formatModeにrawかjson以外が指定されている
                     * 402	No contract.	有効な契約がない
                     * 409	The maximum number of simultaneous connections is full.	アカウントの有効な接続数に達して新たにWebSocketに接続できない
                     */
                }
            }
            #endregion



        }
    }
}
