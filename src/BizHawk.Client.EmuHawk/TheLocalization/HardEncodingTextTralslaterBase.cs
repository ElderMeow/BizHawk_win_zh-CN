using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BizHawk.Client.EmuHawk
{
	internal class HardEncodingTextTralslaterBase
	{
#if DEBUG
		HashSet<string> untranslated = new HashSet<string>();
		internal void collectUntranslated(string text)
		{
			untranslated.Add(text);
		}
#endif
		~HardEncodingTextTralslaterBase()
		{
#if DEBUG
			foreach (var kv in untranslated)
			{
				Console.WriteLine("未翻译的文本：\t\"" + kv + "\" ！");
			}
#endif
		}

		// 将根据系统的 cultureName 字段应用对应的翻译器。
		// The corresponding translator will be applied according to the cultureName.
		internal string cultureName = "default";

		// The dictionary used to translate. 字典，文字对照表。
		protected ConcurrentDictionary<string, string> textTranlateDictionary = new ConcurrentDictionary<string, string>();

		// Translate a plain text. 翻译一条纯文本。
		public virtual string TranslateText(string text, string context = null)
		{
			string key = context == null ? text : $"<[{context}]>:{text}";
			if (textTranlateDictionary.TryGetValue(key, out var translatedString)) // If there is pre-translated text in the dictionary, 如果字典中存在翻译前的文本，
			{
				return translatedString; //take out the translated text from it. 则从中取出翻译后的文本。
			}
#if DEBUG
			if (!string.IsNullOrWhiteSpace(key))
			{
				collectUntranslated(key.Replace("\"", "\\\""));
				// Console.WriteLine("没有翻译的文本： \"" + text.Replace("\"", "\\\"") + "\"");
			}
#endif
			return text; // Otherwise, non translate.
		}

		public virtual string TranslateKeyDisplayString(string bindstring)
		{
			var keys = bindstring.Split('+');
			List<string> translatedKeys = new List<string>();
			foreach (var key in keys)
			{
				if (textTranlateDictionary.TryGetValue($"<[keyname]>:{key}", out var translatedKey)) // If there is pre-translated text in the dictionary, 如果字典中存在翻译前的文本，
				{
					translatedKeys.Add(translatedKey); //take out the translated text from it. 则从中取出翻译后的文本。
				}
				else
				{
#if DEBUG
					collectUntranslated($"<[keyname]>:{key}");
					// Console.WriteLine("没有翻译的按键名： " + $"<[keyname]>:{bindstring}");
#endif
					translatedKeys.Add(key); // Otherwise, non translate.
				}
			}
			return string.Join("+", translatedKeys); // Otherwise, non translate.
		}

		// Translate a format string. 翻译一条格式化字符串。
		public virtual string TranslateFormatString(string formatString, params object[] args)
		{
			if (textTranlateDictionary.TryGetValue(formatString, out var translatedString)) // If there is pre-translated text in the dictionary, 如果字典中存在翻译前的文本，
			{
				return string.Format(translatedString, args); //take out the translated text from it. 则从中取出翻译后的文本。
			}
#if DEBUG
			if (!string.IsNullOrWhiteSpace(formatString))
			{
				collectUntranslated(formatString.Replace("\"", "\\\""));
				// Console.WriteLine("没有翻译的格式串： \"" + formatString.Replace("\"", "\\\"") + "\"");
			}
#endif
			return string.Format(formatString, args); // Otherwise, non translate.
		}

		// 要使用的像素字体 The customized font of the language
		public string CustomizedPixelFontPathAndFirstName = null;

	}
}
