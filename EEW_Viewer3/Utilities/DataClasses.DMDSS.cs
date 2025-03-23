using System.Text.Json.Serialization;

namespace EEW_Viewer3.Utilities
{
    public partial class DataClasses
    {
        /// <summary>
        /// Project DM(Disaster Mitigation)-Data Send Service データのクラス
        /// </summary>
        public class DMDSS
        {
            /// <summary>
            /// Socket Start v2　リクエスト　リクエストボディ(JSON)
            /// </summary>
            /// <remarks><see href="https://dmdata.jp/docs/reference/api/v2/socket.start#%E3%83%AA%E3%82%AF%E3%82%A8%E3%82%B9%E3%83%88%E3%83%9C%E3%83%87%E3%82%A3json"/></remarks>
            public class SocketV2_SocketStartV2_Request_RequestBody
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
            public class SocketV2_SocketStartV2_Response_Marge
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
                public SocketV2_SocketStartV2_Response_StatusOK.C_Websocket? Websocket { get; set; }

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
                public SocketV2_SocketStartV2_Response_StatusError.C_Error? Error { get; set; }
            }

            #region 通常参照しない(SocketV2_SocketStartV2_Response_StatusOK/SocketV2_SocketStartV2_Response_StatusError)
            /// <summary>
            /// Socket Start v2　レスポンス　status: ok
            /// </summary>
            /// <remarks><see href="https://dmdata.jp/docs/reference/api/v2/socket.start#status-ok"/></remarks>
            public class SocketV2_SocketStartV2_Response_StatusOK
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
            public class SocketV2_SocketStartV2_Response_StatusError
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

            /// <summary>
            /// WebSocket v2 レスポンス　type: ping/type: pong
            /// </summary>
            public class WebSocketV2_Response_PingPong
            {
                /// <summary>
                /// <c>ping</c>/<c>pong</c>
                /// </summary>
                [JsonPropertyName("type")]
                public required string Type { get; set; }

                /// <summary>
                /// 64byteまでの文字列、(送信の場合)または送信しなくてもよい。
                /// </summary>
                [JsonPropertyName("pingId")]
                public string? PingId { get; set; }
            }

            /// <summary>
            /// WebSocket v2 レスポンス　type: data
            /// </summary>
            public class WebSocketV2_Response_Data
            {
                /// <summary>
                /// String データを示す data で固定
                /// </summary>
                [JsonPropertyName("type")]
                public required string Type { get; set; }

                /// <summary>
                /// String バージョンを示す、作成処理の変更で予告なく変更となる場合がある
                /// </summary>
                [JsonPropertyName("version")]
                public required string Version { get; set; }

                /// <summary>
                /// String 配信データを区別するユニーク384bitハッシュ
                /// </summary>
                [JsonPropertyName("id")]
                public required string Id { get; set; }

                /// <summary>
                /// 配信区分により変化。取りうる値は eew.forecast, eew.warning, eew.realtime, telegram.earthquake, telegram.volcano, telegram.weather, telegram.scheduled
                /// </summary>
                [JsonPropertyName("classification")]
                public required string Classification { get; set; }

                /// <summary>
                /// Array<Object> 通過情報
                /// </summary>
                [JsonPropertyName("passing")]
                public required C_Passing[] Passing { get; set; }

                /// <summary>
                /// Object ヘッダ情報
                /// </summary>
                [JsonPropertyName("head")]
                public required C_Head Head { get; set; }

                /// <summary>
                /// Object XML電文Control,Head情報
                /// </summary>
                /// <remarks>format=xml または format=json時</remarks>
                [JsonPropertyName("xmlReport")]
                public C_XmlReport? XmlReport { get; set; }

                /// <summary>
                /// String|Null bodyフィールドの表現形式を示す。xml、a/n、binary は気象庁が定めたフォーマット、json は本サービスが独自に定めたフォーマット
                /// </summary>
                [JsonPropertyName("format")]
                public string? Format { get; set; }

                /// <summary>
                /// String|Null bodyフィールドの圧縮形式を示す。gzipまたはzip、非圧縮時はnullを格納する
                /// </summary>
                [JsonPropertyName("compression")]
                public string? Compression { get; set; }

                /// <summary>
                /// String|Null bodyフィールドのエンコーディング形式を示す。base64または、utf-8を格納する
                /// </summary>
                /// <remarks>「compression が、gzip, zip時には常に base64 とする。」と表外にあるが記述がないため推測</remarks>
                [JsonPropertyName("encoding")]
                public string? Encoding { get; set; }

                /// <summary>
                /// String 本文
                /// </summary>
                /// <remarks>「※2 形式は format を参照すること。」とあるが</remarks>
                [JsonPropertyName("body")]
                public required string Body { get; set; }

                /// <summary>
                /// Array<Object> 通過情報
                /// </summary>
                public class C_Passing
                {
                    /// <summary>
                    /// String 通過場所の名前
                    /// </summary>
                    [JsonPropertyName("name")]
                    public required string Name { get; set; }

                    /// <summary>
                    /// ISO8601Time 通過した時間
                    /// </summary>
                    [JsonPropertyName("time")]
                    public required DateTime Time { get; set; }
                }

                /// <summary>
                /// Object ヘッダ情報
                /// </summary>
                public class C_Head
                {
                    /// <summary>
                    /// String データ種類コード
                    /// </summary>
                    [JsonPropertyName("type")]
                    public required string Type { get; set; }

                    /// <summary>
                    /// String 発表英字官署名
                    /// </summary>
                    [JsonPropertyName("author")]
                    public required string Author { get; set; }

                    /// <summary>
                    /// String 対象観測地点コード
                    /// </summary>
                    /// <remarks>内容による　※1 将来の予約拡張。</remarks>
                    [JsonPropertyName("target")]
                    public string? Target { get; set; }

                    /// <summary>
                    /// String 基点時刻（ISO8601拡張形式）
                    /// </summary>
                    [JsonPropertyName("time")]
                    public DateTime Time { get; set; }

                    /// <summary>
                    /// String|Null 指定コード WMO全球通信システム(GTS)で定義されている符号で、遅延報・訂正報に付加する。通常は Null とする ※4 指定コードは、3桁の英大文字を使い、下の通りとする
                    /// </summary>
                    /// <remarks>遅延報	RRA, RRB, RRC, ... RRX / 訂正報	CCA, CCB, CCC, ... CCX / 修正報	AAA, AAB, AAC, ... AAX 、 RRY, RRZ, CCY, CCZ, AAY, AAZ は、システム障害時等でのみ使用。</remarks>
                    [JsonPropertyName("designation")]
                    public string? Designation { get; set; }

                    /// <summary>
                    /// Boolean 訓練、試験等のテスト等電文かどうかを示す。注意：XML電文以外のテスト配信は常に false になります。本文中を参照するようにしてください。
                    /// </summary>
                    [JsonPropertyName("test")]
                    public bool Test { get; set; }

                    /// <summary>
                    /// Boolean XML電文かどうかを示す
                    /// </summary>
                    /// <remarks>内容による　「※2 形式は format を参照すること。」とあるが<see cref="Body"/>か？</remarks>
                    [JsonPropertyName("xml")]
                    public bool Xml { get; set; }
                }

                /// <summary>
                /// Object XML電文Control,Head情報
                /// </summary>
                /// <remarks>format=xml または format=json時  リファレンスに詳細記述無しのためすべてnullable、xmlコメントなし</remarks>
                public class C_XmlReport
                {
                    /// <summary>
                    /// Object XML電文Control情報
                    /// </summary>
                    [JsonPropertyName("control")]
                    public C_Control? Control { get; set; }

                    /// <summary>
                    /// Object XML電文Head情報
                    /// </summary>
                    [JsonPropertyName("head")]
                    public C_Head2? Head { get; set; }

                    /// <summary>
                    /// Object XML電文Control情報
                    /// </summary>
                    public class C_Control
                    {
                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("title")]
                        public string? Title { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("dateTime")]
                        public DateTime? DateTime { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("status")]
                        public string? Status { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("editorialOffice")]
                        public string? EditorialOffice { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("publishingOffice")]
                        public string? PublishingOffice { get; set; }
                    }

                    /// <summary>
                    /// Object XML電文Head情報
                    /// </summary>
                    public class C_Head2
                    {
                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("title")]
                        public string? Title { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("reportDateTime")]
                        public DateTime? ReportDateTime { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("targetDateTime")]
                        public DateTime? TargetDateTime { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("eventId")]
                        public string? EventId { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("serial")]
                        public string? Serial { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("infoType")]
                        public string? InfoType { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("infoKind")]
                        public string? InfoKind { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("infoKindVersion")]
                        public string? InfoKindVersion { get; set; }

                        /// <summary>
                        /// 
                        /// </summary>
                        [JsonPropertyName("headline")]
                        public string? Headline { get; set; }
                    }
                }
            }

            /// <summary>
            /// WebSocket v2 レスポンス　type: error
            /// </summary>
            public class WebSocketV2_Response_Error
            {
                /// <summary>
                /// String エラーを示す error で固定
                /// </summary>
                [JsonPropertyName("type")]
                public required string Type { get; set; }

                /// <summary>
                /// String エラーメッセージ
                /// </summary>
                [JsonPropertyName("error")]
                public required string Error { get; set; }

                /// <summary>
                /// Integer エラーコード、<see cref="ErrorCodeString"/>参照
                /// </summary>
                [JsonPropertyName("code")]
                public required int Code { get; set; }

                /// <summary>
                /// Boolean true 時はWebSocketをその時点で終了します
                /// </summary>
                [JsonPropertyName("close")]
                public required bool Close { get; set; }
            }

            /// <summary>
            /// WebSocket v2 レスポンス　エラーコードと説明
            /// </summary>
            public static readonly Dictionary<int, string> ErrorCodeString = new()
            {
                { 4400, "WebSocket開始時、必要なパラメータが指定されていない場合" },
                { 4404, "WebSocket開始時、有効なticketが指定されていない場合" },
                { 4409, "WebSocket開始時、接続できる接続数に達している場合" },
                { 4503, "サーバー内部エラーでサーバーアプリケーションの再起動を実施する場合" },
                { 4640, "ユーザーが Pong を送信したとき、 pingId が一致しなかった場合" },
                { 4641, "ユーザーが不正なデータを送信した場合（JSON以外など）" },
                { 4808, "ユーザーが明示的にWebSocketを終了するよう操作があった場合" },
                { 4807, "ユーザーが接続中の契約区分を解約したときに、ほかに接続中の区分がない場合" }
            };

        }
    }
}
