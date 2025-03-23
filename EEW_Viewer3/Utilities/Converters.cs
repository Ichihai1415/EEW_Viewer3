using System.Text;

namespace EEW_Viewer3.Utilities
{
    /// <summary>
    /// 各種変換クラス
    /// </summary>
    public class Converters
    {
        /// <summary>
        /// 文字列をBase64に変換します。
        /// </summary>
        /// <param name="text">変換する文字列</param>
        /// <returns>変換された文字列</returns>
        public static string String2Base64(string text) => Convert.ToBase64String(Encoding.UTF8.GetBytes(text));

        /// <summary>
        /// Base64を文字列に変換します。
        /// </summary>
        /// <param name="base64">変換するbase64の文字列</param>
        /// <returns>変換された文字列</returns>
        public static string Base642String(string base64) => Encoding.UTF8.GetString(Convert.FromBase64String(base64));


        public static string GetBasicBase64(string apiKey) => String2Base64(apiKey + ":");


    }
}
