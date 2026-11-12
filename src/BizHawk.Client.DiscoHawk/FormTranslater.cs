using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizHawk.Client.DiscoHawk
{
	internal static class FormTranslater
	{
		public static void TramslateFormWithJsonFile(Form form, string jsonFileName)
		{
			string jsonFullPath = Path.Combine(AppContext.BaseDirectory, "dll", "dictionarys", jsonFileName);
			if (!File.Exists(jsonFullPath))
			{
				Console.WriteLine($"Can not find json file: {jsonFullPath}");
				return;
			}
			TranslateFormWithJsonString(form, File.ReadAllText(jsonFullPath));
		}
		public static void TranslateFormWithJsonString(Form form, string jsonString)
		{
			JArray data = (JArray)JsonConvert.DeserializeObject<JObject>(jsonString).GetValue("items");
			if (data == null) { return; }
			foreach (JObject item in data)
			{
				string path = item.GetValue("path").Value<string>();
				var obj = findObject(form, path);
				if (obj != null)
				{
					JsonConvert.PopulateObject(item.GetValue("data").ToString(), obj);
				}
				else
				{
					Console.WriteLine($"Can not find object: {path}");
				}
			}
		}

		private static object findObject(object root, string path)
		{
			BindingFlags bflags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

			if (root == null || string.IsNullOrWhiteSpace(path)) return root;
			var segements = path.Split('.');
			object cur = root;

			foreach (string seg in segements)
			{
				var info = parseSegment(seg);
				if (!info.HasValue || cur == null) return null;
				var (kind, name) = info.Value;

				switch (kind)
				{
					case ChildType.Property:
						var prop = cur.GetType().GetProperty(name, bflags);
						if (prop != null)
						{
							cur = prop.GetValue(cur);
							break;
						}
						var field = cur.GetType().GetField(name, bflags);
						if (field != null)
						{
							cur = field.GetValue(cur);
							break;
						}
						return null;

					case ChildType.SubObject:
						var strIndexer = cur.GetType().GetProperty("Item", new[] { typeof(string) });
						if (strIndexer == null) return null;
						cur = strIndexer.GetValue(cur, new object[] { name });
						break;

					case ChildType.NumIndexed:
						if (!int.TryParse(name, out int idx)) return null;
						var intIndexer = cur.GetType().GetProperty("Item", new[] { typeof(int) });
						if (intIndexer == null) return null;
						cur = intIndexer.GetValue(cur, new object[] { idx });
						break;
				}
			}
			return cur;
		}

		private enum ChildType
		{
			Property,
			SubObject,
			NumIndexed,
		}
		const string PtyPrefix = "[pty]";
		const string ObjPrefix = "[obj]";
		const string IdxPrefix = "[idx]";

		private static (ChildType Kind, string Name)? parseSegment(string seg)
		{
			if (seg.StartsWith(PtyPrefix)) { return (ChildType.Property, seg[PtyPrefix.Length..]); }
			if (seg.StartsWith(ObjPrefix)) { return (ChildType.SubObject, seg[ObjPrefix.Length..]); }
			if (seg.StartsWith(IdxPrefix)) { return (ChildType.NumIndexed, seg[IdxPrefix.Length..]); }
			return null;
		}
	}
}
