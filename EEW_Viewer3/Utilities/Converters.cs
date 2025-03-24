using System.IO.Compression;
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
        public static string Base642String(string base64, bool isGZip = false)
        {
            return isGZip ? Encoding.UTF8.GetString(GZipExtract(Convert.FromBase64String(base64))) : Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }

        public static string GetBasicBase64(string apiKey) => String2Base64(apiKey + ":");

        /// <summary>
        /// WebSocketで受信した本文を可読文字列に変換します。
        /// </summary>
        /// <param name="data"><see cref="DataClasses.DMDSS.WebSocketV2_Response_Data.Body"/></param>
        /// <param name="compression"><see cref="DataClasses.DMDSS.WebSocketV2_Response_Data.Compression"/></param>
        /// <param name="encoding"><see cref="DataClasses.DMDSS.WebSocketV2_Response_Data.Encoding"/> ※compression が、gzip, zip時には常に base64 とする。</param>
        /// <returns>変換された文字列</returns>
        /// <exception cref="NotImplementedException</exception>
        public static string ExtractDataString(string data, string? compression, string encoding = "base64")
        {
            string extracted = compression switch
            {
                null => data,
                "gzip" => encoding switch
                {
                    "base64" => Base642String(data, true),
                    _ => throw new NotImplementedException(""),
                },
                _ => throw new NotImplementedException(""),
            };
            return extracted;
        }

        /// <summary>
        /// GZipを展開します。
        /// </summary>
        /// <remarks>参考: <see href="https://kagasu.hatenablog.com/entry/2016/10/26/034311"/></remarks>
        /// <param name="bytes">gzip<see cref="byte[]"/></param>
        /// <returns>展開後の<see cref="byte[]"/></returns>
        public static byte[] GZipExtract(byte[] bytes)
        {
            var buffer = new byte[1024];
            using var ms = new MemoryStream();
            using (var gzipStream = new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress))
                while (true)
                {
                    var readSize = gzipStream.Read(buffer, 0, buffer.Length);
                    if (readSize == 0) break;
                    ms.Write(buffer, 0, readSize);
                }
            return ms.ToArray();
        }


    }
}
