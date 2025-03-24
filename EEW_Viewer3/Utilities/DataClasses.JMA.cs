namespace EEW_Viewer3.Utilities
{
    public partial class DataClasses
    {
        /// <summary>
        /// 気象庁データのスキーム
        /// </summary>
        public class JMA
        {
            /// <summary>
            /// 地震火山関連共通
            /// </summary>
            public class EqVol_Common
            {
                /*地震火山関連_解説資料.pdf
Control【管理部】（1 回） 
本情報の配信に関連する情報を記載する。 
1．Title【情報名称】（1 回） 
本要素は、「独立した情報単位」判別のキーとしても用いられる（（ⅲ）共通別紙ア．「地震火
山関連XML電文の「独立した情報単位」の運用」参照）。 
2．DateTime【発表時刻】（1 回） 
ISO 8601 の規格に従い、気象庁システムからの発信時刻を記載する。この値は秒値まで有
効である。 
3．Status【運用種別】（1 回，値：“通常”/“訓練”/“試験”） 
通常の運用で発表する情報には“通常”を記載する。 
事前に日時を定めて行う業務訓練等で発表する情報には“訓練”を記載する。 
定期または臨時に電文疎通確認等を目的として発表する緊急地震速報の配信テスト電文に
は“試験”を記載する。 
本要素は、「独立した情報単位」判別のキーとしても用いられる（（ⅲ）共通別紙ア．「地震火
山関連XML電文の「独立した情報単位」の運用」参照）。 
4．EditorialOffice【編集官署名】（1 回） 
本要素は、「独立した情報単位」判別のキーとしても用いられるが、地震・津波に関連する情
報、南海トラフ地震に関連する情報、北海道・三陸沖後発地震注意情報及び地震・津波に関
するお知らせについては、システム障害発生等により一連の情報であっても編集官署が切り
替わる場合があることに留意が必要である。地震・津波に関連する情報等のこうした取扱につ
いては、（ⅲ）共通別紙ア．「地震火山関連 XML 電文の「独立した情報単位」の運用」を参照
すること。 
5．PublishingOffice【発表官署名】（1 回） 
発表官署名を記載する。 
                 */
                /// <summary>
                /// 【管理部】（1 回）
                /// </summary>
                /// <remarks>本情報の配信に関連する情報を記載する。</remarks>
                public required C_Control Control { get; set; }

                /// <summary>
                /// 【管理部】（1 回）
                /// </summary>
                /// <remarks>本情報の配信に関連する情報を記載する。</remarks>
                public class C_Control
                {
                    /// <summary>
                    /// 【情報名称】（1 回）
                    /// </summary>
                    /// <remarks>本要素は、「独立した情報単位」判別のキーとしても用いられる（（ⅲ）共通別紙ア．「地震火山関連XML電文の「独立した情報単位」の運用」参照）。 </remarks>
                    public required string Title { get; set; }
                    /// <summary>
                    /// 【発表時刻】（1 回）
                    /// </summary>
                    /// <remarks>ISO 8601 の規格に従い、気象庁システムからの発信時刻を記載する。この値は秒値まで有効である。</remarks>
                    public required DateTime AnnouncementDateTime { get; set; }
                    /// <summary>
                    /// 【運用種別】（1 回，値：“通常”/“訓練”/“試験”）
                    /// </summary>
                    /// <remarks>通常の運用で発表する情報には“通常”を記載する。事前に日時を定めて行う業務訓練等で発表する情報には“訓練”を記載する。定期または臨時に電文疎通確認等を目的として発表する緊急地震速報の配信テスト電文には“試験”を記載する。本要素は、「独立した情報単位」判別のキーとしても用いられる（（ⅲ）共通別紙ア．「地震火山関連XML電文の「独立した情報単位」の運用」参照）。</remarks>
                    public required string Status { get; set; }
                    /// <summary>
                    /// 【編集官署名】（1 回）
                    /// </summary>
                    /// <remarks>本要素は、「独立した情報単位」判別のキーとしても用いられるが、地震・津波に関連する情報、南海トラフ地震に関連する情報、北海道・三陸沖後発地震注意情報及び地震・津波に関するお知らせについては、システム障害発生等により一連の情報であっても編集官署が切り替わる場合があることに留意が必要である。地震・津波に関連する情報等のこうした取扱については、（ⅲ）共通別紙ア．「地震火山関連 XML 電文の「独立した情報単位」の運用」を参照すること。</remarks>
                    public required string EditorialOffice { get; set; }
                    /// <summary>
                    /// 【発表官署名】（1 回）
                    /// </summary>
                    /// <remarks>発表官署名を記載する。</remarks>
                    public required string PublishingOffice { get; set; }
                }
                /*地震火山関連_解説資料.pdf
Ⅰ．（ⅱ）ヘッダ部 
Head【ヘッダ部】（1回） 
本情報の見出しを記載する。 
1．Title【標題】（1 回） 
情報の標題を記載する。 
震源・震度に関する情報において、近地地震の場合には“震源・震度情報”、遠地地震の場
合には“遠地地震に関する情報”と記載する。 
津波警報・注意報・予報については、発表する情報に含まれる津波予報等の種類の総和表
現を記載する。なお、津波警報・注意報を全解除し、全ての津波予報区等で津波予報（若干
の海面変動）又は津波なしとなる場合は、事例に示すとおり“津波予報”と記載する。 
各地の満潮時刻と津波到達予想時刻を発表する津波情報については“各地の満潮時刻・
津波到達予想時刻に関する情報”を、津波の観測値を発表する津波情報については“津波観
測に関する情報”を記載する。両者をひとつの津波情報電文で発表する場合は、本要素の中
に二つの標題を半角スペースで区切って併記する。 
南海トラフ地震に関連する情報においては、情報名称（Control/Title）が”南海トラフ地震臨
時情報”の場合は、”南海トラフ地震臨時情報”に続けて情報種別番号名
（Body/EarthquakeInfo/InfoSerial/Name）の内容を付記する（例：”南海トラフ地震臨時情報
（巨大地震警戒）”）。また、情報名称（Control/Title）が”南海トラフ地震関連解説情報”の場
合は、”南海トラフ地震関連解説情報”と標記し、情報番号（Head/Serial）に値が記載されてい
る場合に限り、一連の情報番号を付記する（例：”南海トラフ地震関連解説情報（第○号）”）。 
火山に関連する情報においては、火山名と情報の種別を記載する。 
事例１（津波注意報と津波予報を発表する場合） 
<Title>津波注意報・津波予報</Title> 
事例２（津波注意報を全解除し、津波予報（若干の海面変動）が残る場合） 
<Title>津波予報</Title> 
事例４（大津波警報、津波警報、津波注意報、津波予報を発表する場合） 
<Title>大津波警報・津波警報・津波注意報・津波予報</Title> 
事例３（津波注意報を全解除し、全ての津波予報区で津波なしとなる場合） 
<Title>津波予報</Title> 
Ⅰ－2 
2．ReportDateTime【発表時刻】（1 回） 
発表官署が本情報を発表した時刻を記載する。 
緊急地震速報（警報）、緊急地震速報（地震動予報）、緊急地震速報（予報）、及び緊急地
震速報の配信テスト電文については秒値まで、その他の地震・津波に関する情報、南海トラフ
地震に関する情報、北海道・三陸沖後発地震注意情報及び火山に関連する情報については、
分値まで有効である。 
3．TargetDateTime【基点時刻】（1 回） 
情報の内容が発現・発効する基点時刻を記載する。 
震度速報については最初に地震波を自動検知した観測点における地震波の検知時刻を、
地震情報（顕著な地震の震源要素更新のお知らせ）については震源要素を切り替えた時刻を、
津波の観測値を発表する津波情報、沖合の津波観測に関する情報については津波の観測
状況を確定した時刻を記載する。火山現象に関する海上警報については火山活動の観測時
刻、噴火に関する火山観測報、噴火速報、推定噴煙流向報については報じる現象の発現時
刻、降灰予報については情報の対象となる時間帯の基点時刻を記載する。その他の地震・津
波・火山に関連する情報については、ヘッダ部の発表時刻（Head/ReportDateTime）の値を記
載する。 
なお、緊急地震速報（警報）、緊急地震速報（地震動予報）、緊急地震速報（予報）、及び緊
急地震速報の配信テスト電文については秒値まで、その他の地震・津波に関する情報、南海
トラフ地震に関する情報、北海道・三陸沖後発地震注意情報及び火山に関連する情報につ
いては、分値まで有効である。ただし、噴火に関する火山観測報、噴火速報、推定噴煙流向
報については、基本的に分値まで有効であるが、TargetDTDubious が出現する場合は、それ
で示すあいまいさに応じた単位までが有効、発現時刻が不明の場合には xsi:nil=“true”属性
値により空要素となる。 
事例（噴火に関する火山観測報において、本要素が空要素として出現する場合） 
<TargetDateTime xsi:nil=”true” /> 
4. TargetDTDubious【基点時刻のあいまいさ】 
（0 回/1回, 値：“頃”/“年頃”/“月頃”/“日頃”/“時頃”/“分頃”/“秒頃”） 
噴火に関する火山観測報、噴火速報、推定噴煙流向報で用いる場合があり、報じる現象の
発現時刻にあいまいさがある場合に記載する。 
例えば“日頃”のときは年月日までが有効となる。具体的な精度の有効な範囲は、内容部の
EventDateTime 及び EventDateTimeUTC の@significant に記載する。 
5．ValidDateTime【失効時刻】（0 回/1 回） 
Ⅰ－3 
津波警報・注意報・予報の電文及び降灰予報の電文において情報の失効時刻を記載する。 
津波警報・注意報・予報の電文については、津波予報（若干の海面変動）のみ発表の場合
や、津波警報・注意報解除後に津波予報（若干の海面変動）のみが残る場合に、その失効時
刻を記載する。 
降灰予報については、それぞれの情報における失効時刻を記載し、降灰予報（定時）は基
点時刻から18 時間後、降灰予報（速報）は基点時刻から1 時間後、降灰予報（詳細）は基点
時刻から概ね6時間後となる。 
6．EventID【識別情報】（1回） 
地震・津波に関連する情報については、ある特定の地震を識別するための地震識別番号
（14 桁の数字）を記載する。津波に関連する情報では、当該警報等に寄与している地震の地
震識別番号を記載するため、１つの電文に複数の地震識別番号が出現する場合もある。詳細
については、（ⅲ）共通別紙イ．「地震・津波に関連する情報のEventID要素の運用」を参照。 
南海トラフ地震に関連する情報及び北海道・三陸沖後発地震注意情報については、任意の
識別番号（14 桁の数字）を記載する。詳細については、（ⅲ）共通別紙エ．「南海トラフ地震に
関連する情報における EventID 要素及び Serial 要素の運用」及び（ⅲ）共通別紙オ．「北海
道・三陸沖後発地震注意情報におけるEventID要素及びSerial要素の運用」を参照。 
火山に関連する情報については、３桁の火山番号を記載する。ただし、噴火に関する火山
観測報及び噴火速報、推定噴煙流向報については、ReportDateTime と火山番号を“_”で連
結して記載する。 
地震・津波に関するお知らせや火山に関するお知らせについては、情報発表日時分（14 桁
の数字）を記載する。 
7．InfoType【情報形態】（1回） 
情報を発表する場合は“発表”を、「独立した情報単位」において直前の時点で発表されて
いる Control/DateTime の最も新しい電文を訂正する場合は“訂正”を、「独立した情報単位」
全体を取り消す場合は“取消”を記載する。取消電文の運用については、（ⅲ）共通別紙ウ．
「取消電文の運用」を参照。 
8．Serial【情報番号】（1 回） 
続報を発表し、内容を更新する情報については、情報番号を記載する。続報を発表する度
に情報番号を更新するが、取消報の場合は、番号は更新しない。訂正報の場合は訂正する
直近の情報の情報番号を記載する。 
南海トラフ地震に関連する情報については、続報を発表する情報で情報番号を記載する。
詳細については、（ⅲ）共通別紙エ．「南海トラフ地震に関連する情報における EventID 要素
及びSerial 要素の運用」を参照。 
Ⅰ－4 
※なお、同一種別の情報における最新情報の検索にあたっては、本要素ではなく管理部の
発表時刻（Control/DateTime）を参照すること。 
9．InfoKind【スキーマの運用種別情報】（1回） 
10．InfoKindVersion【スキーマの運用種別情報のバージョン番号】（1回） 
11．Headline【見出し要素】（1 回） 
子要素にText及びInformationをもつ。 
11-1．Text【見出し文】（1回） 
見出し文を自由文形式で記載する。 
11-2．Information【見出し防災気象情報事項】（0回以上） 
地震火山関連XML電文では、情報によって本要素の運用が異なる。このため、以下のとお
り個別に解説する。 
津波に関連する情報については、11-2(1)にて解説する。 
緊急地震速報については、11-2(2)にて解説する。 
地震情報等については、11-2(3)にて解説する。 
南海トラフ地震に関連する情報では、本要素は出現しない。 
北海道・三陸沖後発地震注意情報では、本要素は出現しない。 
地震・津波に関するお知らせでは、本要素は出現しない。 
火山に関連する情報については、11-2(4)にて解説する。 
火山に関するお知らせでは、本要素は出現しない。 
なお、情報形態（Head/InfoType）が“取消”の場合、情報名称に関わらず本要素は出現しな
い（（ⅲ）共通別紙ウ．「取消電文の運用」を参照）。 
                 */

                /// <summary>
                /// 【ヘッダ部】（1回）
                /// </summary>
                /// <remarks>本情報の見出しを記載する。</remarks>
                public required C_Head Head { get; set; }

                /// <summary>
                /// 【ヘッダ部】（1回）
                /// </summary>
                /// <remarks>本情報の見出しを記載する。</remarks>
                public class C_Head
                {
                    /// <summary>
                    /// 【標題】（1 回）
                    /// </summary>
                    /// <remarks>情報の標題を記載する。</remarks>
                    public required string Title { get; set; }

                    /// <summary>
                    /// 【発表時刻】（1 回）
                    /// </summary>
                    /// <remarks>発表官署が本情報を発表した時刻を記載する。</remarks>
                    public required DateTime ReportDateTime { get; set; }

                    /// <summary>
                    /// 【基点時刻】（1 回）
                    /// </summary>
                    /// <remarks>情報の内容が発現・発効する基点時刻を記載する。</remarks>
                    public required DateTime TargetDateTime { get; set; }

                    /// <summary>
                    /// 【基点時刻のあいまいさ】（0 回/1回, 値：“頃”/“年頃”/“月頃”/“日頃”/“時頃”/“分頃”/“秒頃”）
                    /// </summary>
                    public string? TargetDTDubious { get; set; }
                    /// <summary>
                    /// 【失効時刻】（0 回/1 回）
                    /// </summary>
                    /// <remarks>津波警報・注意報・予報の電文及び降灰予報の電文において情報の失効時刻を記載する。</remarks>
                    public DateTime? ValidDateTime { get; set; }

                    /// <summary>
                    /// 【識別情報】（1回）
                    /// </summary>
                    /// <remarks>地震・津波に関連する情報については、ある特定の地震を識別するための地震識別番号（14 桁の数字）を記載する。津波に関連する情報では、当該警報等に寄与している地震の地震識別番号を記載するため、１つの電文に複数の地震識別番号が出現する場合もある。詳細については、（ⅲ）共通別紙イ．「地震・津波に関連する情報のEventID要素の運用」を参照。</remarks>
                    public required string EventID { get; set; }

                    /// <summary>
                    /// 【情報形態】（1回）
                    /// </summary>
                    /// <remarks>情報を発表する場合は“発表”を、「独立した情報単位」において直前の時点で発表されている Control/DateTime の最も新しい電文を訂正する場合は“訂正”を、「独立した情報単位」全体を取り消す場合は“取消”を記載する。取消電文の運用については、（ⅲ）共通別紙ウ．「取消電文の運用」を参照。</remarks>
                    public required string InfoType { get; set; }

                    /// <summary>
                    /// 【情報番号】（1 回）
                    /// </summary>
                    /// <remarks>続報を発表し、内容を更新する情報については、情報番号を記載する。続報を発表する度に情報番号を更新するが、取消報の場合は、番号は更新しない。訂正報の場合は訂正する直近の情報の情報番号を記載する。</remarks>
                    public required string Serial { get; set; }

                    /// <summary>
                    /// 【スキーマの運用種別情報】（1回）
                    /// </summary>
                    public required string InfoKind { get; set; }

                    /// <summary>
                    /// 【スキーマの運用種別情報のバージョン番号】（1回）
                    /// </summary>
                    public required string InfoKindVersion { get; set; }

                    /// <summary>
                    /// 【見出し要素】（1 回）
                    /// </summary>
                    /// <remarks>子要素にText及びInformationをもつ。</remarks>
                    public required C_Headline Headline { get; set; }

                    /// <summary>
                    /// 【見出し要素】（1 回）
                    /// </summary>
                    /// <remarks>子要素にText及びInformationをもつ。</remarks>
                    public class C_Headline
                    {
                        /// <summary>
                        /// 【見出し文】（1回）
                        /// </summary>
                        /// <remarks>見出し文を自由文形式で記載する。</remarks>
                        public required string Text { get; set; }

                        /// <summary>
                        /// 【見出し防災気象情報事項】（0回以上）
                        /// </summary>
                        /// <remarks>地震火山関連XML電文では、情報によって本要素の運用が異なる。</remarks>
                        public C_Information[]? Information { get; set; }

                        /// <summary>
                        /// 【見出し防災気象情報事項】（0回以上）
                        /// </summary>
                        /// <remarks>地震火山関連XML電文では、情報によって本要素の運用が異なる。</remarks>
                        public abstract class C_Information
                        {

                        }
                    }
                }
            }

            /*地震火山関連_解説資料.pdf
○津波警報・注意報・予報の場合 
津波警報等の発表状況に応じて本要素の出現回数が決まる（下表参照）。なお、発表してい
る全ての警報・注意報・予報の種類の個数だけ本要素が出現するわけではないことに留意が
必要である（例：津波警報を発表している津波予報区等がある場合は、津波注意報を発表し
ている津波予報区等があっても、津波注意報のための本要素は出現しない）。 
子要素として、KindとAreasをもつ。 
大津波警報 津波警報 津波 
Item 要素の
出現回数 Kind/Name要素の 内容 
注意報 
○ ○ ○ ２ “大津波警報” 
“津波警報” 
○ ○ × ２ “大津波警報” 
“津波警報” 
○ × ○ １ “大津波警報” 
○ × × １ “大津波警報” 
× 
○ ○ １ “津波警報” 
× 
○ × １ “津波警報” 
× 
× 
○ １ “津波注意報” 
（注）表中の○は発表あり、×は発表なしをあらわす。 
○沖合の津波観測に関する情報の場合 
Ⅰ－6 
1 回のみ出現する。子要素として、KindとAreasをもつ。 
11-2(1)-1-1．Kind【防災気象情報要素】（1回） 
○津波警報・注意報・予報の場合 
津波警報等の種類を記載する。子要素にNameとCodeをもつ。 
○沖合の津波観測に関する情報の場合 
子要素にNameをもつ。 
11-2(1)-1-1-1．Name【防災気象情報要素名】（1回） 
○津波警報・注意報・予報の場合 
津波警報等の名称を記載する。 
○沖合の津波観測に関する情報の場合 
本要素の値は“沖合の津波観測に関する情報”となる。 
11-2(1)-1-1-2．Code【防災気象情報要素コード】（0回/1回）  
○津波警報・注意報・予報の場合 
上記Name の内容に対応するコード（“警報等情報要素／津波警報・注意報・予報”）を記載
する。 
○沖合の津波観測に関する情報の場合 
本要素は出現しない。 
11-2(1)-1-2．Areas【対象地域・地点】（1 回）  
○津波警報・注意報・予報の場合 
津波警報等の対象となる津波予報区、津波予報区結合表現、又は領域表現を記載する。 
子要素にAreaをもつ。 
○沖合の津波観測に関する情報の場合 
大津波警報・津波警報に相当する高い津波が観測された沖合の潮位観測点を記載する。 
子要素にAreaをもつ。 
11-2(1)-1-2-1．Area【対象地域・地点】（1 回以上）  
○津波警報・注意報・予報の場合 
Kind の内容に対応する津波警報等の対象となる、津波予報区、津波予報区結合表現、又
は領域表現の数と同数出現する。 
子要素にNameとCodeをもつ。 
○沖合の津波観測に関する情報の場合 
大津波警報・津波警報に相当する高い津波が観測された沖合の潮位観測点又は観測点名
Ⅰ－7 
称を簡略化した表現（複数の観測点で同じ表現となる場合は1回だけ記載する。）の数と同数
出現する。 
子要素にNameとCodeをもつ。 
11-2(1)-1-2-1-1．Name【対象地域・地点名称】（1回） 
○津波警報・注意報・予報の場合 
津波予報区、津波予報区結合表現、又は領域表現を記載する。 
○沖合の津波観測に関する情報の場合 
沖合の潮位観測点又は観測点名称を簡略化した表現（複数の観測点で同じ表現となる場
合は1回だけ記載する。）を記載する。 
11-2(1)-1-2-1-2．Code【対象地域・地点コード】（1回）  
○津波警報・注意報・予報の場合 
上記Nameの内容に対応するコード（“津波予報区”）を記載する。 
○沖合の津波観測に関する情報の場合 
上記Name の内容に対応するコード（“潮位観測点”）を記載する。“潮位観測点”コード表に
は、各観測点を示すコードと、観測点名称を簡略化した表現（複数の観測点を代表する地点
として抜粋して用いられる観測点名）を示すコードが含まれており、簡略化した観測点名称に
対しては、その名称に対応するコードを記載する。この簡略化した観測点名称は、「ヘッダ部」
（Head）に記載する場合のみ使用し、「内容部」（Body）では使用しない。このヘッダ部に出現
する簡略化した観測点名称は、電文の内容を簡潔に伝えることを目的としたものであり、実際
にどの観測点で観測したかを知るためには、内容部を参照することを想定している。 
津波警報・注意報・予報におけるInformationの構造 
Information @type=”津波予報領域表現” 
└─Item（1回/2回） 
├─Kind（1回） 
│  ├─Name（1回） 
│  └─Code（1回） 
└─Areas @codeType="津波予報区"（1回） 
└─Area（1回以上） 
├─Name（1回） 
└─Code（1回） 
津波警報・注意報・予報におけるInformationの出現例 
<Information type="津波予報領域表現"> 
Ⅰ－8 
 
Ⅰ－9 
 
<Item> 
<Kind> 
<Name>津波注意報</Name>  
<Code>62</Code>  
</Kind> 
<Areas codeType="津波予報区"> 
<Area> 
<Name>伊豆諸島</Name>  
<Code>320</Code>  
</Area> 
<Area> 
<Name>静岡県</Name>  
<Code>380</Code>  
</Area> 
</Areas> 
</Item> 
</Information> 
 
沖合の津波観測に関する情報におけるInformationの構造 
Information @type="沖合の津波観測に関する情報" 
└─Item（1回） 
   ├─Kind（1回） 
   │  └─Name（1回） 
   └─Areas @codeType="潮位観測点"（1回） 
      └─Area（1回以上） 
         ├─Name（1回） 
        └─Code（1回） 
 
沖合の津波観測に関する情報におけるInformationの出現例 
<Information type="沖合の津波観測に関する情報"> 
<Item> 
<Kind> 
<Name>沖合の津波観測に関する情報</Name>  
</Kind> 
<Areas codeType="潮位観測点"> 
<Area> 
<Name>岩手釜石沖</Name>  
<Code>21090</Code>  
</Area> 
<Area> 
<Name>岩手宮古沖</Name>  
<Code>21091</Code>  
</Area> 
</Areas> 
</Item> 
</Information> 
             */


            public class Tsunami : EqVol_Common
            {

            }

            /*地震火山関連_解説資料.pdf
緊急地震速報におけるHead/Headline/Informationの解説 
11-2(2)．Information【見出し防災気象情報事項】（0回/3回） 
本要素は緊急地震速報（警報）及び緊急地震速報（地震動予報）のみに出現し、緊急地震
速報(予報)及び緊急地震速報の配信テスト電文には出現しない。また、情報形態
（Head/InfoType）が“取消”の場合も出現しない。 
緊急地震速報(警報)及び緊急地震速報（地震動予報）で本要素が出現する場合には、
@type が“緊急地震速報(地方予報区)”、 “緊急地震速報(府県予報区)”、及び“緊急地震速
報(細分区域)”である本要素が各々１回ずつ出現する。各々の Information 要素は子要素とし
てItem をもつ。 
11-2(2)-1．Item【個々の防災気象情報要素】（1回/2回） 
緊急地震速報(警報)の発表状況を記載する。子要素として、Kind、LastKind及びAreasをも
つ。警報では本要素は原則として１回のみの出現だが、新たに警報対象となる区域がある場
合には、当該警報の電文において本要素は２回出現する（下表参照）。 
Item の 
出現回数 
区域※の変化 － 
Kind/Name 
の内容 
LastKind/Name 
の内容 
最初の 
警報 
１ 
“緊急地震速報（警報）” “なし” 
変化がない場合 
１ 
“緊急地震速報（警報）” “緊急地震速報（警報）” 
続報の 
警報 
“緊急地震速報（警報）” “なし” 
増える場合 ２ 
※当該Itemの親要素Information の@typeで示す警報対象区域 
“緊急地震速報（警報）” “緊急地震速報（警報）” 
11-2(2)-1-1．Kind【防災気象情報要素】（1回） 
子要素にNameとCodeをもつ。 
11-2(2)-1-1-1．Name【防災気象情報要素名】（1回） 
防災気象情報名を記載する。現行の運用では、とりうる値としては“緊急地震速報(警報)”の
みである（11-2(2)-1 の表参照）。 
11-2(2)-1-1-2．Code【防災気象情報要素コード】（1回）  
上記Nameの内容に対応するコード（“警報等情報要素／緊急地震速報”）を記載する。 
11-2(2)-1-2．LastKind【直前の防災気象情報要素】（1回） 
Ⅰ－11 
子要素にNameとCodeをもつ。 
11-2(2)-1-2-1．Name【防災気象情報要素名】（1回） 
防災気象情報名を記載する。現行の運用では、とりうる値としては“緊急地震速報(警報)”又
は“なし”である（11-2(2)-1の表参照）。 
11-2(2)-1-2-2．Code【防災気象情報要素コード】（1回）  
上記Nameの内容に対応するコード（“警報等情報要素／緊急地震速報”）を記載する。 
11-2(2)-1-3．Areas【対象地域・地点】（1 回）  
Kind 及び LastKind の防災気象情報名の組み合わせに該当する区域を記載する。
Information/@type の値に応じて本要素の@codeType が“緊急地震速報／地方予報区”、 
“緊急地震速報／府県予報区”、又は“地震情報／細分区域”に設定される。 
子要素にAreaをもつ。 
11-2(2)-1-3-1．Area【対象地域・地点】（1 回以上）  
子要素にNameとCodeをもつ。 
11-2(2)-1-3-1-1．Name【対象地域・地点名称】（1回） 
Areas/@codeType の値に応じて地方予報区、府県予報区又は細分区域のいずれかを記載
する。 
11-2(2)-1-3-1-2．Code【対象地域・地点コード】（1回）  
上記Name の内容に対応するコードを記載する。参照するコードはAreas/@codeType に記
載されている。 
緊急地震速報(警報)における Information の構造（Information/@type=“緊急地震速報(地方
予報区)”の場合のみを示す。@typeが異なる値を持つInformationについても、構造は同じで
ある。） 
Information @type="緊急地震速報(地方予報区)" 
└─Item（1回/2回） 
├─Kind（1回） 
│  ├─Name（1回） 
│  └─Code（1回） 
├─LastKind（1回） 
│  ├─Name（1回） 
Ⅰ－12 
 
Ⅰ－13 
 
   │  └─Code（1回） 
   └─Areas @codeType="緊急地震速報／地方予報区"（1回） 
      └─Area（1回以上） 
         ├─Name（1回） 
         └─Code（1回） 
 
緊急地震速報(警報)におけるInformationの出現例 
事例： （最初の緊急地震速報（警報）の事例） 
<Information type="緊急地震速報（地方予報区）"> 
<Item> 
<Kind> 
<Name>緊急地震速報（警報）</Name>  
<Code>31</Code>  
</Kind> 
<LastKind> 
<Name>なし</Name>  
<Code>00</Code>  
</LastKind> 
<Areas codeType="緊急地震速報／地方予報区"> 
<Area> 
<Name>東海</Name>  
<Code>9936</Code>  
</Area> 
<Area> 
<Name>甲信</Name>  
<Code>9935</Code>  
</Area> 
</Areas> 
</Item> 
</Information> 
<Information type="緊急地震速報（府県予報区）"> 
<Item> 
<Kind> 
<Name>緊急地震速報（警報）</Name>  
<Code>31</Code>  
</Kind> 
 
Ⅰ－14 
 
<LastKind> 
<Name>なし</Name>  
<Code>00</Code>  
</LastKind> 
<Areas codeType="緊急地震速報／府県予報区"> 
<Area> 
<Name>静岡</Name>  
<Code>9220</Code>  
</Area> 
<Area> 
<Name>山梨</Name>  
<Code>9190</Code>  
</Area> 
</Areas> 
</Item> 
</Information> 
<Information type="緊急地震速報（細分区域）"> 
<Item> 
<Kind> 
<Name>緊急地震速報（警報）</Name>  
<Code>31</Code>  
</Kind> 
<LastKind> 
<Name>なし</Name>  
<Code>00</Code>  
</LastKind> 
<Areas codeType="地震情報／細分区域"> 
<Area> 
<Name>静岡県東部</Name>  
<Code>441</Code>  
</Area> 
<Area> 
<Name>山梨県中・西部</Name>  
<Code>411</Code>  
</Area> 
<Area> 
<Name>山梨県東部・富士五湖</Name>  
<Code>412</Code>  
</Area> 
<Area> 
<Name>静岡県伊豆</Name>  
<Code>440</Code>  
</Area> 
<Area> 
<Name>静岡県中部</Name>  
<Code>442</Code>  
</Area> 
<Area> 
<Name>静岡県西部</Name>  
<Code>443</Code>  
</Area> 
</Areas> 
</Item> 
</Information>
             */

            /*//継承確認用
            void A()
            {
                var a = new EarthquakeEarlyWarning() { Head=new EarthquakeEarlyWarning.C_Head() { EventID= } };
            }*/

            /// <summary>
            /// 緊急地震速報
            /// </summary>
            public class EarthquakeEarlyWarning : EqVol_Common
            {
                /// <inheritdoc />
                public new class C_Head : EqVol_Common.C_Head
                {
                    /// <inheritdoc />
                    public new class C_Headline : EqVol_Common.C_Head.C_Headline
                    {
                        /// <summary>
                        /// 【見出し防災気象情報事項】（0回/3回）
                        /// </summary>
                        /// <remarks>本要素は緊急地震速報（警報）及び緊急地震速報（地震動予報）のみに出現し、緊急地震速報(予報)及び緊急地震速報の配信テスト電文には出現しない。また、情報形態（Head/InfoType）が“取消”の場合も出現しない。 緊急地震速報(警報)及び緊急地震速報（地震動予報）で本要素が出現する場合には、@type が“緊急地震速報(地方予報区)”、 “緊急地震速報(府県予報区)”、及び“緊急地震速報(細分区域)”である本要素が各々１回ずつ出現する。各々の Information 要素は子要素としてItem をもつ。 </remarks>
                        public new C_Information[]? Information { get; set; }

                        /// <summary>
                        /// 【見出し防災気象情報事項】（0回/3回）
                        /// </summary>
                        /// <remarks>本要素は緊急地震速報（警報）及び緊急地震速報（地震動予報）のみに出現し、緊急地震速報(予報)及び緊急地震速報の配信テスト電文には出現しない。また、情報形態（Head/InfoType）が“取消”の場合も出現しない。 緊急地震速報(警報)及び緊急地震速報（地震動予報）で本要素が出現する場合には、@type が“緊急地震速報(地方予報区)”、 “緊急地震速報(府県予報区)”、及び“緊急地震速報(細分区域)”である本要素が各々１回ずつ出現する。各々の Information 要素は子要素としてItem をもつ。 </remarks>
                        public new class C_Information
                        {
                            /// <summary>
                            /// <see cref="C_Information"/>@type
                            /// </summary>
                            /// <remarks>“緊急地震速報(地方予報区)”、 “緊急地震速報(府県予報区)”、及び“緊急地震速報(細分区域)”である本要素が各々１回ずつ出現する。</remarks>
                            public required string A_Type { get; set; }

                            /// <summary>
                            /// 【個々の防災気象情報要素】（1回/2回） 
                            /// </summary>
                            /// <remarks>緊急地震速報(警報)の発表状況を記載する。子要素として、Kind、LastKind及びAreasをもつ。警報では本要素は原則として１回のみの出現だが、新たに警報対象となる区域がある場合には、当該警報の電文において本要素は２回出現する（下表参照）。</remarks>
                            public required C_Item[] Item { get; set; }

                            /// <summary>
                            /// 【個々の防災気象情報要素】（1回/2回） 
                            /// </summary>
                            /// <remarks>緊急地震速報(警報)の発表状況を記載する。子要素として、Kind、LastKind及びAreasをもつ。警報では本要素は原則として１回のみの出現だが、新たに警報対象となる区域がある場合には、当該警報の電文において本要素は２回出現する（下表参照）。</remarks>
                            public class C_Item
                            {
                                /// <summary>
                                /// 【防災気象情報要素】（1回）
                                /// </summary>
                                /// <remarks>子要素にNameとCodeをもつ。 </remarks>
                                public required C_Kind Kind { get; set; }

                                /// <summary>
                                /// 【防災気象情報要素】（1回）
                                /// </summary>
                                /// <remarks>子要素にNameとCodeをもつ。 </remarks>
                                public class C_Kind
                                {
                                    /// <summary>
                                    /// 【防災気象情報要素名】（1回） 
                                    /// </summary>
                                    /// <remarks>防災気象情報名を記載する。現行の運用では、とりうる値としては“緊急地震速報(警報)”のみである（11-2(2)-1 の表参照）。</remarks>
                                    public required string Name { get; set; }

                                    /// <summary>
                                    /// 【防災気象情報要素コード】（1回）
                                    /// </summary>
                                    /// <remarks>上記Nameの内容に対応するコード（“警報等情報要素／緊急地震速報”）を記載する。</remarks>
                                    public required string Code { get; set; }
                                }

                                /// <summary>
                                /// 【直前の防災気象情報要素】（1回）
                                /// </summary>
                                /// <remarks>子要素にNameとCodeをもつ。</remarks>
                                public required C_LastKind LastKind { get; set; }

                                /// <summary>
                                /// 【直前の防災気象情報要素】（1回）
                                /// </summary>
                                /// <remarks>子要素にNameとCodeをもつ。</remarks>
                                public class C_LastKind
                                {
                                    /// <summary>
                                    /// 【防災気象情報要素名】（1回）
                                    /// </summary>
                                    /// <remarks>防災気象情報名を記載する。現行の運用では、とりうる値としては“緊急地震速報(警報)”又は“なし”である（11-2(2)-1の表参照）。 </remarks>
                                    public required string Name { get; set; }

                                    /// <summary>
                                    /// 【防災気象情報要素コード】（1回）
                                    /// </summary>
                                    /// <remarks>上記Nameの内容に対応するコード（“警報等情報要素／緊急地震速報”）を記載する。 </remarks>
                                    public required string Code { get; set; }
                                }

                                /// <summary>
                                /// 【対象地域・地点】（1 回）
                                /// </summary>
                                /// <remarks>Kind 及び LastKind の防災気象情報名の組み合わせに該当する区域を記載する。Information/@type の値に応じて本要素の@codeType が“緊急地震速報／地方予報区”、 “緊急地震速報／府県予報区”、又は“地震情報／細分区域”に設定される。 子要素にAreaをもつ。 </remarks>
                                public required C_Areas Areas { get; set; }

                                /// <summary>
                                /// 【対象地域・地点】（1 回）
                                /// </summary>
                                /// <remarks>Kind 及び LastKind の防災気象情報名の組み合わせに該当する区域を記載する。Information/@type の値に応じて本要素の@codeType が“緊急地震速報／地方予報区”、 “緊急地震速報／府県予報区”、又は“地震情報／細分区域”に設定される。 子要素にAreaをもつ。 </remarks>
                                public class C_Areas
                                {
                                    /// <summary>
                                    /// @codeType 
                                    /// </summary>
                                    /// <remarks>“緊急地震速報／地方予報区”、“緊急地震速報／府県予報区”、又は“地震情報／細分区域”に設定される。</remarks>
                                    public required string A_CodeType { get; set; }

                                    /// <summary>
                                    /// 【対象地域・地点】（1 回以上）  
                                    /// </summary>
                                    /// <remarks>子要素にNameとCodeをもつ。 </remarks>
                                    public required C_Area[] Areas { get; set; }

                                    /// <summary>
                                    /// 【対象地域・地点】（1 回以上）  
                                    /// </summary>
                                    /// <remarks>子要素にNameとCodeをもつ。 </remarks>
                                    public class C_Area
                                    {
                                        /// <summary>
                                        /// 【対象地域・地点名称】（1回） 
                                        /// </summary>
                                        /// <remarks>Areas/@codeType の値に応じて地方予報区、府県予報区又は細分区域のいずれかを記載する。</remarks>
                                        public required string Name { get; set; }

                                        /// <summary>
                                        /// 【対象地域・地点コード】（1回）
                                        /// </summary>
                                        /// <remarks>上記Name の内容に対応するコードを記載する。参照するコードはAreas/@codeType に記載されている。</remarks>
                                        public required string Code { get; set; }
                                    }
                                }
                            }
                        }
                    }
                }



            }

            /*地震火山関連_解説資料.pdf
地震情報等におけるHead/Headline/Information の解説 
11-2(3)．Information【見出し防災気象情報事項】（0回以上） 
震度速報では、@type が“震度速報”である本要素が１回出現する。情報形態
（Head/InfoType）が“取消”の場合は出現しない。 
地震情報(震源・震度に関する情報)では、@type が“震源・震度に関する情報（細分区域）”、
“震源・震度に関する情報（市町村等）”である本要素が各々１回ずつ出現する。なお、以下の
場合は本要素は出現しない。 
・観測された震度が全て２以下だった場合 
・震度が観測されなかった場合（遠地地震の場合など） 
・情報形態（Head/InfoType）が“取消”の場合 
長周期地震動に関する観測情報では、@type が“長周期地震動に関する観測情報（細分
区域）”である本要素が１回出現する。なお、以下の場合は本要素は出現しない。 
・情報形態（Head/InfoType）が“取消”の場合 
地震情報(震源に関する情報)、地震情報(地震の活動状況等に関する情報)、地震情報(地
震回数に関する情報)、及び地震情報(顕著な地震の震源要素更新のお知らせ)には、本要素
は出現しない。 
11-2(3)-1．Item【個々の防災気象情報要素】（1回以上） 
本要素は、Information/@type の値や観測された最大震度により出現回数が決まる。 
Information/@type が“震度速報”又は“震源・震度に関する情報(細分区域)”の場合は、観
測された震度のうち、震度３以上の震度階級の数だけ本要素が出現する。 
Information/@type が“長周期地震動に関する観測情報（細分区域）”の場合は、観測された
長周期地震動階級の数だけ本要素が出現する。 
Information/@type が“震源・震度に関する情報(市町村等)”の場合、当面は下表に示す震
度階級の要素が出現する。また、基準となる震度以上と考えられるが情報発表時点で震度が
入電していない市町村がある場合は、その旨を記載するための要素が追加される。当面は震
度５弱を基準とし、震度５弱以上と考えられるが震度が入電していない市町村を、“震度５弱以
上未入電”の要素に記載する。 
子要素として、Kind及びAreasをもつ。 
観測された最大震度 
震度６弱以上 
Item に記載する震度階級 
観測された震度のうち、震度５弱以上の階級のもの 
震度５強又は震度５弱 
震度４又は震度３ 
観測された震度のうち、震度４以上の階級のもの 
観測された震度のうち、震度３以上の階級のもの 
11-2(3)-1-1．Kind【防災気象情報要素】（1回） 
Ⅰ－16 
子要素にNameをもつ。 
11-2(3)-1-1-1．Name【防災気象情報要素名】（1 回，とりうる値：“震度７”、 “震度６強”、 
“震度６弱”、 “震度５強”、 “震度５弱”、 “震度４”、 “震度３”、 “震度５弱以
上未入電” 、“長周期地震動階級４”、“長周期地震動階級３” 、“長周期地震
動階級２” 、“長周期地震動階級１”） 
観測された震度、長周期地震動階級等を記載する。 
Information/@type が“震源・震度に関する情報(市町村等)”の場合は、11-2(3)-1 の表に示
す震度等が記載の対象となる。 
11-2(3)-1-2．Areas【対象地域・地点】（1 回）  
区域を記載する。Information/@type の値に応じて、@codeType が“地震情報／細分区域”
又は“気象・地震・火山情報／市町村等”に設定される。 
子要素にAreaをもつ。 
11-2(3)-1-2-1．Area【対象地域・地点】（1 回以上）  
子要素にNameとCodeをもつ。 
11-2(3)-1-2-1-1．Name【対象地域・地点名称】（1回） 
Areas/@codeType の値に応じて、Kind に記載されている震度、長周期地震動階級を観測し
た細分区域又は市町村等のいずれかを記載する（市町村等を記載する場合であって、Kind
の内容が“震度５弱以上未入電”の場合は、震度５弱以上未入電と推定される市町村等を記
載する）。 
11-2(3)-1-2-1-2．Code【対象地域・地点コード】（1回）  
上記Nameの内容に対応するコードを記載する。参照するコードはAreas/@codetypeに記載
されている。 
Information @type=“震度速報”の構造（@type=“震源・震度に関する情報(細分区域)”、“震
源・震度に関する情報(市町村等)”、又は"長周期地震動に関する観測情報（細分区域）"であ
る場合も構造は同じ） 
Information @type="震度速報" 
└─Item（1回以上） 
├─Kind（1回） 
│  └─Name（1回） 
└─Areas @codeType="地震情報／細分区域"（1回） 
Ⅰ－17 
└─Area（1回以上） 
├─Name（1回） 
└─Code（1回） 
震度速報におけるInformationの出現例 
<Information type="震度速報"> 
<Item> 
<Kind> 
<Name>震度４</Name> 
</Kind> 
<Areas codeType="地震情報／細分区域"> 
<Area> 
<Name>静岡県中部</Name> 
<Code>442</Code> 
</Area> 
<Area> 
<Name>静岡県西部</Name> 
<Code>443</Code> 
</Area> 
</Areas> 
</Item> 
<Item> 
<Kind> 
<Name>震度３</Name> 
</Kind> 
<Areas codeType="地震情報／細分区域"> 
<Area> 
<Name>静岡県伊豆</Name> 
<Code>440</Code> 
</Area> 
<Area> 
<Name>静岡県東部</Name> 
<Code>441</Code> 
</Area> 
</Areas> 
</Item> 
Ⅰ－18 
 
Ⅰ－19 
 
</Information> 
 
震源・震度に関する情報におけるInformationの出現例 
<Information type="震源・震度に関する情報(細分区域)"> 
 <Item> 
  <Kind> 
   <Name>震度４</Name> 
  </Kind> 
  <Areas codeType="地震情報／細分区域"> 
   <Area> 
    <Name>静岡県中部</Name> 
    <Code>442</Code> 
   </Area> 
   <Area> 
    <Name>静岡県西部</Name> 
    <Code>443</Code> 
   </Area> 
  </Areas> 
 </Item> 
 <Item> 
  <Kind> 
   <Name>震度３</Name> 
  </Kind> 
  <Areas codeType="地震情報／細分区域"> 
   <Area> 
    <Name>静岡県伊豆</Name> 
    <Code>440</Code> 
   </Area> 
   <Area> 
    <Name>静岡県東部</Name> 
    <Code>441</Code> 
   </Area> 
  </Areas> 
 </Item> 
</Information> 
<Information type="震源・震度に関する情報(市町村等)"> 
<Item> 
<Kind> 
<Name>震度４</Name> 
</Kind> 
<Areas codeType="気象・地震・火山情報／市町村等"> 
<Area> 
<Name>●●市</Name> 
<Code>0000000</Code> 
</Area> 
<Area> 
<Name>▲▲町</Name> 
<Code>1111111</Code> 
</Area> 
</Areas> 
</Item> 
<Item> 
<Kind> 
<Name>震度３</Name> 
</Kind> 
<Areas codeType="気象・地震・火山情報／市町村等"> 
<Area> 
<Name>■■区</Name> 
<Code>2222222</Code> 
</Area> 
<Area> 
<Name>××市</Name> 
<Code>3333333</Code> 
</Area> 
</Areas> 
</Item> 
</Information> 
長周期地震動に関する観測情報におけるInformationの出現例 
<Information type="長周期地震動に関する観測情報（細分区域）"> 
<Item> 
<Kind> 
Ⅰ－20 
<Name>長周期地震動階級２</Name> 
</Kind> 
<Areas codeType="地震情報／細分区域"> 
<Area> 
<Name>宮城県北部</Name> 
<Code>220</Code> 
</Area> 
</Areas> 
</Item> 
<Item> 
<Kind> 
<Name>長周期地震動階級１</Name> 
</Kind> 
<Areas codeType="地震情報／細分区域"> 
<Area> 
<Name>青森県津軽北部</Name> 
<Code>200</Code> 
</Area> 
<Area> 
<Name>青森県三八上北</Name> 
<Code>202</Code> 
</Area> 
<Area> 
<Name>岩手県内陸北部</Name> 
<Code>212</Code> 
</Area> 
<Area> 
<Name>岩手県内陸南部</Name> 
<Code>213</Code> 
</Area> 
</Areas> 
</Item> 
</Information> 
             */


        }
    }
}
