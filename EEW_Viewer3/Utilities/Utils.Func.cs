namespace EEW_Viewer3.Utilities
{
    internal partial class Utils
    {
        /// <summary>
        /// コンソールのデフォルトの色
        /// </summary>
        public static readonly ConsoleColor defaultColor = Console.ForegroundColor;

        /// <summary>
        /// コンソールにデフォルトの色で出力します。
        /// </summary>
        /// <param name="text">出力するテキスト</param>
        /// <param name="withLine">改行するか</param>
        public static void ConWrite(string text, bool withLine = true)
        {
            ConWrite(text, defaultColor, withLine);
        }

        /// <summary>
        /// 例外のテキストを赤色で出力します。
        /// </summary>
        /// <param name="loc">場所([ConWrite]など)</param>
        /// <param name="ex">出力する例外</param>
        public static void ConWrite(string loc, Exception ex)
        {
            ConWrite(loc + ex.ToString(), ConsoleColor.Red);
        }

        /// <summary>
        /// コンソールに色付きで出力します。色は変わったままとなります。
        /// </summary>
        /// <param name="text">出力するテキスト</param>
        /// <param name="color">表示する色</param>
        /// <param name="withLine">改行するか</param>
        public static void ConWrite(string text, ConsoleColor color, bool withLine = true)
        {
            Console.ForegroundColor = color;
            Console.Write(DateTime.Now.ToString("HH:mm:ss.ffff "));
            if (withLine)
                Console.WriteLine(text);
            else
                Console.Write(text);
        }

        /// <summary>
        /// ログを書き込みます。
        /// </summary>
        /// <param name="path">出力パス</param>
        /// <param name="text">出力テキスト</param>
        /// <param name="conWrite">ログ(<c>ConWrite("[WriteLog]" + path, ConsoleColor.Green);</c>)をコンソールに表示するか</param>
        public static void WriteLog(string path, string text, bool conWrite = false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, text);
            if (conWrite)
                ConWrite("[WriteLog]" + path, ConsoleColor.Green);
        }

        /// <summary>
        /// 例外ログを書き込みます。
        /// </summary>
        /// <param name="path">出力パス</param>
        /// <param name="ex">出力例外</param>
        /// <param name="conWrite">コンソールに表示するか</param>
        public static void WriteLog(string path, Exception ex, bool conWrite = false)
        {
            WriteLog(path, ex.ToString(), conWrite);
        }

    }
}
