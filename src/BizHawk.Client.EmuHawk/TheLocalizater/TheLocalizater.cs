using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BizHawk.Client.EmuHawk
{
	internal static class TheLocalizater
	{
		// Translate a plain text. 翻译一条纯文本。
		public static string TranslateText(string text)
		{
			// TODO: your translate implementation.
			return "T_" + text;
		}

		// Translate a format string. 翻译一条格式化字符串。
		public static string TranslateFormatString(string formatString, params object[] args)
		{
			// TODO: your translate implementation.
			return "T_" + string.Format(formatString, args);
		}
	}
}
