namespace BizHawk.Client.EmuHawk
{
	public static class TheLocalizater
	{
		// Translate a plain text. 翻译一条纯文本。
		public static string TranslateText(string text)
		{
			// TODO: your translate implementation.
			return "T_" + text;
		}

		public static string TranslateShortcutKeyDisplayString(string bindstring)
		{
			// TODO: your translate implementation.
			return "TK_" + bindstring;
		}

		// Translate a format string. 翻译一条格式化字符串。
		public static string TranslateFormatString(string formatString, params object[] args)
		{
			// TODO: your translate implementation.
			return "T_" + string.Format(formatString, args);
		}
	}
}
