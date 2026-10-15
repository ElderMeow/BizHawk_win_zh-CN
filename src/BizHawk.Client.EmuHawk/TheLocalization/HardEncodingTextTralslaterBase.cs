using System.Collections.Generic;

namespace BizHawk.Client.EmuHawk
{
	internal class HardEncodingTextTralslaterBase
	{
		// 将根据系统的 cultureName 字段应用对应的翻译器。
		// The corresponding translator will be applied according to the cultureName.
		internal string cultureName = "default";

		// The dictionary used to translate. 字典，文字对照表。
		protected Dictionary<string, string> textTranlateDictionary = new Dictionary<string, string>();

		// Translate a plain text. 翻译一条纯文本。
		public virtual string TranslateText(string text, string context = null)
		{
			string key = context == null ? text : $"<[{context}]>:{text}";
			if (textTranlateDictionary.TryGetValue(key, out var translatedString)) // If there is pre-translated text in the dictionary, 如果字典中存在翻译前的文本，
			{
				return translatedString; //take out the translated text from it. 则从中取出翻译后的文本。
			}
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
			return string.Format(formatString, args); // Otherwise, non translate.
		}

		// 要使用的像素字体 The customized font of the language
		public string CustomizedPixelFontPathAndFirstName = null;

	}
}
