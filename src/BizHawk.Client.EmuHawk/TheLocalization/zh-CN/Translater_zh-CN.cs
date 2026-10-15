using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace BizHawk.Client.EmuHawk.zh_CN
{
	internal class Translater_zh_CN : HardEncodingTextTralslaterBase
	{
		protected Dictionary<string, string> untranslated = new Dictionary<string, string>();
		internal void collectUntranslated(string text)
		{
			untranslated[text] = "";
		}

		public static void SaveTranslationDict(Dictionary<string, string> dict, string fileName)
		{
			string fileFullName = Path.Combine(AppContext.BaseDirectory, "dll", "TheLocalization", "zh-CN", fileName);
			string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
			File.WriteAllText(fileFullName, json);
		}

		public static void LoadTranslationDict(string fileName, ref Dictionary<string, string> targetDict)
		{
			string fileFullName = Path.Combine(AppContext.BaseDirectory, "dll", "TheLocalization", "zh-CN", fileName);
			if (!File.Exists(fileFullName))
				return;

			string json = File.ReadAllText(fileFullName);
			var loaded = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
			if (loaded == null) return;

			foreach (var kv in loaded)
			{
				targetDict[kv.Key] = kv.Value;
			}
		}

		public Translater_zh_CN()
		{
			cultureName = "zh-CN";

			// ====================================================

			// InitTranslatedText();
			LoadTranslationDict("TextTranslateDictionary.json", ref textTranlateDictionary);
		}

		~Translater_zh_CN()
		{
			foreach (var kv in untranslated)
			{
				Console.WriteLine("发现未翻译的文本：\t\"" + kv.Key + "\" ！");
			}
			// SaveTranslationDict(textTranlateDictionary, "TextTranslateDictionary.json");
			SaveTranslationDict(untranslated, "UntranslatedTexts.json");
		}

		// Translate a plain text. 翻译一条纯文本。
		public override string TranslateText(string text, string context = null)
		{
			string key = context == null ? text : $"<[{context}]>:{text}";
			if (textTranlateDictionary.TryGetValue(key, out var translatedString)) // If there is pre-translated text in the dictionary, 如果字典中存在翻译前的文本，
			{
				return translatedString; //take out the translated text from it. 则从中取出翻译后的文本。
			}
			if (!string.IsNullOrWhiteSpace(key))
			{
				collectUntranslated(key.Replace("\"", "\\\""));
			}
			return text; // Otherwise, non translate.
		}

		public override string TranslateKeyDisplayString(string bindstring)
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
					collectUntranslated($"<[keyname]>:{key}");
					translatedKeys.Add(key); // Otherwise, non translate.
				}
			}
			return string.Join("+", translatedKeys); // Otherwise, non translate.
		}

		// Translate a format string. 翻译一条格式化字符串。
		public override string TranslateFormatString(string formatString, params object[] args)
		{
			if (textTranlateDictionary.TryGetValue(formatString, out var translatedString)) // If there is pre-translated text in the dictionary, 如果字典中存在翻译前的文本，
			{
				return string.Format(translatedString, args); //take out the translated text from it. 则从中取出翻译后的文本。
			}
			if (!string.IsNullOrWhiteSpace(formatString))
			{
				collectUntranslated(formatString.Replace("\"", "\\\""));
			}
			return string.Format(formatString, args); // Otherwise, non translate.
		}


		/* 第一批导出和翻译 老东西了
		private void InitTranslatedText()
		{

			// AVOut/AVSync.cs
			textTranlateDictionary["Only async mode is supported, set async mode before passing in the sound provider"] = "仅支持异步模式，请在传入声音提供程序之前设置异步模式";
			textTranlateDictionary["Must set params first!"] = "必须先设置参数！";
			textTranlateDictionary["Only sync mode is supported, set sync mode before passing in the sound provider"] = "仅支持同步模式，请在传入声音提供程序之前设置同步模式";
			textTranlateDictionary["Only 16 bit audio is supported!"] = "仅支持 16 位音频！";
			textTranlateDictionary["Must call AddAV()!"] = "必须调用 AddAV()！";

			// AVOut/AviWriter.cs
			textTranlateDictionary["{0} only takes its own {1}s!"] = "{0} 只接受它自己的 {1}！";
			textTranlateDictionary["Reached maximum names"] = "已达到名称数量上限";
			textTranlateDictionary["AVIFIL32 Thread died:\n\n{0}"] = "AVIFIL32 线程已终止：\n\n{0}";
			textTranlateDictionary["Tried to start recording an AVI with no video codec token set"] = "在未设置视频编解码器令牌的情况下尝试开始录制 AVI";
			textTranlateDictionary["AVI Worker thread died!"] = "AVI 工作线程已终止！";
			textTranlateDictionary["only 8/16 bits audio are supported by {0} and you chose: {1}"] = "{0} 仅支持 8/16 位音频，而您选择的是：{1}";
			textTranlateDictionary["only 1/2 channels audio are supported by {0} and you chose: {1}"] = "{0} 仅支持 1/2 声道音频，而您选择的是：{1}";
			textTranlateDictionary["Couldnt open dest path for avi file: {0}"] = "无法打开 AVI 文件的目标路径：{0}";
			textTranlateDictionary["Failed opening raw video stream. Not sure how this could happen"] = "打开原始视频流失败。不清楚这怎么会发生";
			textTranlateDictionary["Failed opening raw audio stream. Not sure how this could happen"] = "打开原始音频流失败。不清楚这怎么会发生";
			textTranlateDictionary["File must be opened before acquiring a codec token (or else the stream formats wouldnt be known)"] = "必须先打开文件才能获取编解码器令牌（否则无法得知流格式）";
			textTranlateDictionary["set a video codec token before opening the streams!"] = "在打开流之前先设置视频编解码器令牌！";
			textTranlateDictionary["Failed making compressed video stream"] = "创建压缩视频流失败";
			textTranlateDictionary["Failed setting compressed video stream input format"] = "设置压缩视频流输入格式失败";
			textTranlateDictionary["Failed setting raw audio stream input format"] = "设置原始音频流输入格式失败";
			textTranlateDictionary["video buffer changed between start and now"] = "视频缓冲区从开始到现在发生了变化";
			textTranlateDictionary["No default {0} in config!"] = "配置中没有默认的 {0}！";

			// AVOut/FFmpegDownloaderForm.cs
			textTranlateDictionary["BizHawk relies on a specific version of FFmpeg. No other version will do. The wrong version will be ignored. There is no way to override this behavior."] = "BizHawk 依赖于特定版本的 FFmpeg，其他版本都不行。版本不正确将被忽略，且无法覆盖此行为。";
			textTranlateDictionary["\n\nThe required version could not be found."] = "\n\n找不到所需版本。";
			textTranlateDictionary["\n\n(Linux user: If installing manually, you can use a symlink.)"] = "\n\n(Linux 用户：如果是手动安装，可以使用符号链接。)";
			textTranlateDictionary["\n\nUse this dialog to download it automatically, or download it yourself from the URL below and place it in the specified location."] = "\n\n使用此对话框自动下载，或者自行从下方 URL 下载后放入指定位置。";

			// AVOut/FFmpegWriter.cs
			textTranlateDictionary["unexpected ffmpeg death:\n{0}"] = "ffmpeg 意外终止：\n{0}";
			textTranlateDictionary["Exception! ffmpeg history:\n{0}"] = "异常！ffmpeg 历史记录：\n{0}";
			textTranlateDictionary["{0} can only take its own codec tokens!"] = "{0} 只能接受它自己的编解码器令牌！";
			textTranlateDictionary["Sampling depth must be 16 bits!"] = "采样深度必须为 16 位！";

			// AVOut/FFmpegWriterForm.cs
			textTranlateDictionary["Lossless UT video and uncompressed audio in an AVI container. Compatible with AVISource(), if UT Video decoder is installed. Fast, but low compression."] = "AVI 容器中的无损 UT 视频和未压缩音频。若安装了 UT Video 解码器，则兼容 AVISource()。速度快，但压缩率低。";
			textTranlateDictionary["Lossless FFV1 video and uncompressed audio in an AVI container. Compatible with AVISource(), if ffmpeg based decoder is installed. Slow, but high compression."] = "AVI 容器中的无损 FFV1 视频和未压缩音频。若安装了基于 ffmpeg 的解码器，则兼容 AVISource()。速度慢，但压缩率高。";
			textTranlateDictionary["Lossless AVC video and uncompressed audio in an AVI container. High speed and compression, compatible with AVISource() if x264vfw or ffmpeg based decoder is installed. Seeking may be unstable."] = "AVI 容器中的无损 AVC 视频和未压缩音频。速度快、压缩率高，若安装了 x264vfw 或基于 ffmpeg 的解码器，则兼容 AVISource()。拖动定位可能不稳定。";
			textTranlateDictionary["Uncompressed video and audio in an AVI container. Very large, don't use!"] = "AVI 容器中的未压缩视频和音频。体积非常大，不要使用！";
			textTranlateDictionary["Lossless AVC video and uncompressed audio in a Matroska container."] = "Matroska 容器中的无损 AVC 视频和未压缩音频。";
			textTranlateDictionary["AVC video and Vorbis audio in a Matroska container."] = "Matroska 容器中的 AVC 视频和 Vorbis 音频。";
			textTranlateDictionary["AVC video and AAC audio in an MP4 container."] = "MP4 容器中的 AVC 视频和 AAC 音频。";
			textTranlateDictionary["VP8 video and Vorbis audio in a WebM container."] = "WebM 容器中的 VP8 视频和 Vorbis 音频。";
			textTranlateDictionary["Theora video and Vorbis audio in an Ogg container."] = "Ogg 容器中的 Theora 视频和 Vorbis 音频。";
			textTranlateDictionary["Xvid video and MP3 audio in an AVI container."] = "AVI 容器中的 Xvid 视频和 MP3 音频。";
			textTranlateDictionary["AVC video and AAC audio in a QuickTime container."] = "QuickTime 容器中的 AVC 视频和 AAC 音频。";
			textTranlateDictionary["AVC video and AAC audio in a Flash Video container."] = "Flash Video 容器中的 AVC 视频和 AAC 音频。";
			textTranlateDictionary["[Custom]"] = "[自定义]";
			textTranlateDictionary["Write your own ffmpeg command. For advanced users only."] = "自行编写 ffmpeg 命令。仅供高级用户使用。";

			// AVOut/GifWriter.cs
			textTranlateDictionary["{0} only takes its own tokens!"] = "{0} 只接受它自己的令牌！";

			// AVOut/GifWriterForm.cs
			textTranlateDictionary["Auto"] = "自动";
			textTranlateDictionary["Fastest"] = "最快";
			textTranlateDictionary["{0} FPS"] = "{0} FPS";

			// AVOut/JMDForm.cs
			textTranlateDictionary["Number of compression threads: {0}"] = "压缩线程数：{0}";
			textTranlateDictionary["Compression Level: NONE"] = "压缩级别：无";
			textTranlateDictionary["Compression Level: {0}"] = "压缩级别：{0}";

			// AVOut/JMDWriter.cs
			textTranlateDictionary["{0} must be writable!"] = "{0} 必须可写！";
			textTranlateDictionary["length cannot be less than 0!"] = "长度不能小于 0！";
			textTranlateDictionary["JMD Timestamp problem?"] = "JMD 时间戳有问题？";
			textTranlateDictionary["codec token must be of right type"] = "编解码器令牌类型必须正确";
			textTranlateDictionary["JMD Worker Thread died:\n\n{0}"] = "JMD 工作线程已终止：\n\n{0}";

			// AVOut/NutMuxer.cs
			textTranlateDictionary["unsigned must be non-negative"] = "无符号值必须为非负数";
			textTranlateDictionary["Can't write data after end of relevance!"] = "在相关数据结束后无法写入数据！";
			textTranlateDictionary["Can't write audio after end of relevance!"] = "在相关数据结束后无法写入音频！";

			// AVOut/NutWriter.cs
			textTranlateDictionary["Audio depth must be 16 bit!"] = "音频深度必须为 16 位！";

			// AVOut/SynclessRecorder.cs
			textTranlateDictionary["Invalid len"] = "无效的 len";

			// AVOut/VideoWriterChooserForm.cs
			textTranlateDictionary["Size:\r\n{0}x{1}"] = "尺寸：\r\n{0}x{1}";
			textTranlateDictionary["Size must be positive!"] = "尺寸必须为正数！";
			textTranlateDictionary["Size must be numeric!"] = "尺寸必须为数字！";

			// AVOut/WavWriter.cs
			textTranlateDictionary["Bad samplerate/numchannels"] = "采样率/声道数不正确";
			textTranlateDictionary["Iterator was empty!"] = "迭代器为空！";
			textTranlateDictionary["Only support 16bit audio!"] = "仅支持 16 位音频！";

			// ArchiveChooser.cs
			textTranlateDictionary["Error parsing RegEx: {0}"] = "解析正则表达式出错：{0}";
			textTranlateDictionary["Could not find search text"] = "找不到搜索文本";

			// BizBoxInfoControl.cs
			textTranlateDictionary["authors: {0}"] = "作者：{0}";
			textTranlateDictionary["(Ported)"] = "(移植)";

			// CoreFeatureAnalysis.cs
			textTranlateDictionary["Core Features"] = "核心功能";
			textTranlateDictionary[" (UNRELEASED)"] = "(未发布)";
			textTranlateDictionary["Total: {0} Released: {1} Profiled: {2}"] = "总计：{0} 已发布：{1} 已分析：{2}";

			// CustomControls/ExceptionBox.cs
			textTranlateDictionary["Done!"] = "完成！";
			textTranlateDictionary["ERROR!"] = "错误！";

			// CustomControls/FolderBrowserDialogEx.cs
			textTranlateDictionary["Please select a folder below:"] = "请在下方选择一个文件夹：";

			// CustomControls/InputRoll/InputRoll.cs
			textTranlateDictionary["Shift click logic for individual cells has not yet implemented"] = "针对单个单元格的 Shift 点击逻辑尚未实现";

			// CustomControls/InputRoll/RollColumns.cs
			textTranlateDictionary["A column with this name already exists."] = "已存在同名的列。";

			// CustomControls/InputWidget.cs
			textTranlateDictionary["Binds the Escape key"] = "绑定 Escape 键";
			textTranlateDictionary["Binds the left mouse button"] = "绑定鼠标左键";
			textTranlateDictionary["Binds the middle mouse button"] = "绑定鼠标中键";
			textTranlateDictionary["Binds the right mouse button"] = "绑定鼠标右键";
			textTranlateDictionary["Binds the mouse auxiliary button 1"] = "绑定鼠标附加键 1";
			textTranlateDictionary["Binds the mouse auxiliary button 2"] = "绑定鼠标附加键 2";

			// CustomControls/MsgBox.cs
			textTranlateDictionary["Button Text is null"] = "按钮文本为空";
			textTranlateDictionary["Invalid number of buttons. Must be between 1 and 3."] = "按钮数量无效。必须介于 1 到 3 之间。";
			textTranlateDictionary["OK"] = "确定";

			// DownloaderForm.cs
			textTranlateDictionary["Download {0}"] = "下载 {0}";
			textTranlateDictionary["download failed (pre-chmod validation)"] = "下载失败（chmod 前验证）";
			textTranlateDictionary["download failed (post-chmod validation)"] = "下载失败（chmod 后验证）";
			textTranlateDictionary["Downloading..."] = "正在下载...";
			textTranlateDictionary["FAILED - Download Again"] = "失败 - 重新下载";

			// Extensions/ControlExtensions.cs
			textTranlateDictionary["Columns"] = "列";
			textTranlateDictionary["{0} ({1})"] = "{0} ({1})";

			// Extensions/ToolExtensions.cs
			textTranlateDictionary["None"] = "无";
			textTranlateDictionary["this will probably never appear but I can't be bothered checking --yoshi"] = "这条大概永远不会出现，但我懒得去查了 --yoshi";
			textTranlateDictionary["&Copy Canonical Path"] = "复制规范路径(&C)";
			textTranlateDictionary["Copy Archive Path"] = "复制归档路径";
			textTranlateDictionary["Open &Archive"] = "打开归档(&A)";
			textTranlateDictionary["&Copy Path"] = "复制路径(&C)";
			textTranlateDictionary["&Explore"] = "浏览(&E)";
			textTranlateDictionary["Copy &File"] = "复制文件(&F)";
			textTranlateDictionary["&Shell Context Menu"] = "&Shell 上下文菜单";
			textTranlateDictionary["-Missing-"] = "-缺失-";
			textTranlateDictionary["&Remove"] = "移除(&R)";
			textTranlateDictionary["&Clear"] = "清除(&C)";
			textTranlateDictionary["&Clear Moved/Deleted"] = "清除已移动/已删除(&C)";
			textTranlateDictionary["&Unfreeze"] = "解冻(&U)";
			textTranlateDictionary["&Freeze"] = "冻结(&F)";
			textTranlateDictionary["&Autoload {0}"] = "自动加载 {0}(&A)";
			textTranlateDictionary["&Recent Settings..."] = "最近设置(&R)...";
			textTranlateDictionary["Number of recent files to track"] = "最近文件的数量";
			textTranlateDictionary["File not found"] = "找不到文件";
			textTranlateDictionary["Could not open {0}"] = "无法打开 {0}";
			textTranlateDictionary["Could not open {0}\nRemove from list?"] = "无法打开 {0}\n是否从列表中移除？";

			// FormBase.cs
			textTranlateDictionary["window title can only be changed by calling {0} (which calls {1} getter)"] = "窗口标题只能通过调用 {0} 来更改（它会调用 {1} 的 getter）";
			textTranlateDictionary["you have to implement this; the Designer prevents this from being an abstract method"] = "你必须实现此方法；设计器不允许把它做成抽象方法";

			// LogWindow.cs
			textTranlateDictionary["Log Window"] = "日志窗口";

			// MainForm.Debug.cs
			textTranlateDictionary["Debug RC Hash"] = "调试 RC 哈希";
			textTranlateDictionary["Open Dummy Modal Dialog"] = "打开虚拟模态对话框";
			textTranlateDictionary["This message is meaningless.\nPress\"OK\" to continue."] = "此消息毫无意义。\n按\"确定\"继续。";
			textTranlateDictionary["Queue Dummy OSD Message"] = "排队虚拟 OSD 消息";
			textTranlateDictionary["Firmware"] = "固件";
			textTranlateDictionary["RCheevos"] = "RCheevos";
			textTranlateDictionary["WinForms/UI"] = "WinForms/UI";
			textTranlateDictionary["Debug SameBoy States"] = "调试 SameBoy 进度";
			textTranlateDictionary["&Debug Utilities"] = "调试工具(&D)";

			// MainForm.Events.cs
			textTranlateDictionary["Automatic Alpha Sanitizer"] = "自动 Alpha 清理器";
			textTranlateDictionary["Open Advanced"] = "高级打开";
			textTranlateDictionary["Failed to flush saveram!"] = "刷写 RAM 失败！";
			textTranlateDictionary["Thanks for using BizHawk!  The emulation core you have selected "] = "感谢使用 BizHawk！您选择的模拟核心 ";
			textTranlateDictionary["is currently BETA-status.  We appreciate your help in testing BizHawk. "] = "目前处于 BETA 状态。我们感谢您协助测试 BizHawk。";
			textTranlateDictionary["You can record a movie on this core if you'd like to, but expect to "] = "如果您愿意，可以在此核心上录制影片，但请预期会 ";
			textTranlateDictionary["encounter bugs and sync problems.  Continue?"] = "遇到 bug 和同步问题。是否继续？";
			textTranlateDictionary["Most of these options will cause crashes on Linux."] = "这些选项中的大多数会导致 Linux 崩溃。";
			textTranlateDictionary["A/V instability warning"] = "音视频不稳定警告";
			textTranlateDictionary["Est. {0} since power-on"] = "开机后估计 {0}";
			textTranlateDictionary["(none)"] = "(无)";
			textTranlateDictionary["Forget Trusted Tools"] = "忘记受信任的工具";
			textTranlateDictionary["Forget trusted ext. tools?"] = "忘记受信任的外部工具？";
			textTranlateDictionary["This will cause the warning about running third-party code to show again for all the ext. tools you've previously loaded.\n"] = "这会让之前加载过的所有外部工具再次显示运行第三方代码的警告。\n";
			textTranlateDictionary["(If a tool has been loaded this session, the warning may not appear until EmuHawk is restarted.)"] = "(如果本会话中已加载过某工具，警告可能要到重启 EmuHawk 后才会出现。)";
			textTranlateDictionary["Current core does not support input polling. TAStudio can't be used."] = "当前核心不支持输入轮询，无法使用 TAStudio。";
			textTranlateDictionary["This will reload the rom without saving. Launch TAStudio anyway?"] = "这会在不保存的情况下重新加载 ROM。仍要启动 TAStudio 吗？";
			textTranlateDictionary["Confirmation"] = "确认";
			textTranlateDictionary["View Subtitles"] = "查看字幕";
			textTranlateDictionary["View Comments"] = "查看注释";
			textTranlateDictionary["Edit Subtitles"] = "编辑字幕";
			textTranlateDictionary["Edit Comments"] = "编辑注释";
			textTranlateDictionary["Redo Save to slot {0}"] = "重做保存到进度槽 {0}";
			textTranlateDictionary["Undo Save to slot {0}"] = "撤销保存到进度槽 {0}";
			textTranlateDictionary["Undo Savestate"] = "撤销进度";
			textTranlateDictionary["Hide Menu"] = "隐藏菜单";
			textTranlateDictionary["Show Menu"] = "显示菜单";
			textTranlateDictionary["Failed to swap state files."] = "交换进度文件失败。";
			textTranlateDictionary["Version {0} is now available. Would you like to open the BizHawk homepage?\r\n\r\nClick \"No\" to hide the update notification for this version."] = "版本 {0} 现已可用。是否打开 BizHawk 主页？\r\n\r\n单击\"否\"可隐藏此版本的更新通知。";
			textTranlateDictionary["New Version Available"] = "有新版本可用";

			// MainForm.Movie.cs
			textTranlateDictionary["Cheats warning"] = "作弊警告";
			textTranlateDictionary["Continue playback with cheats enabled?\nChoosing \"No\" will disable cheats but not remove them."] = "在启用作弊的情况下继续播放？\n选择\"否\"将禁用作弊但不会删除它们。";
			textTranlateDictionary["Movie/Platform Mismatch"] = "影片与平台不匹配";
			textTranlateDictionary["Movie is in playback mode"] = "影片处于播放模式";
			textTranlateDictionary["Movie is in record mode"] = "影片处于录制模式";
			textTranlateDictionary["No movie is active"] = "没有活动的影片";
			textTranlateDictionary["Failed to save movie.\n{0}\n{1}"] = "保存影片失败。\n{0}\n{1}";
			textTranlateDictionary["Error"] = "错误";
			textTranlateDictionary["Replaying movie file in read-only mode"] = "以只读模式重放影片文件";

			// MainForm.VSystem.cs
			textTranlateDictionary["Disk{0}"] = "磁盘{0}";
			textTranlateDictionary[" Settings"] = " 设置";
			textTranlateDictionary[" Controller Settings"] = " 控制器设置";
			textTranlateDictionary["Insert {0}"] = "插入 {0}";
			textTranlateDictionary["Upload Failed"] = "上传失败";
			textTranlateDictionary["Invalid file format. Reason: {0} \nForce transfer? This may cause the calculator to crash."] = "文件格式无效。原因：{0} \n强制传输？这可能导致计算器崩溃。";
			textTranlateDictionary["Settings..."] = "设置";
			textTranlateDictionary["{0} Settings"] = "{0} 设置";
			textTranlateDictionary["Controller Settings..."] = "控制器设置";
			textTranlateDictionary["Filter Settings..."] = "滤镜设置";
			textTranlateDictionary["Circular Analog Range"] = "圆形模拟摇杆范围";
			textTranlateDictionary["Controller Configuration..."] = "控制器配置";
			textTranlateDictionary["Options..."] = "选项";
			textTranlateDictionary["Skip BIOS intro (When Applicable)"] = "跳过 BIOS 开场(可用时)";
			textTranlateDictionary["Use the Super Game Module"] = "使用 Super Game Module";
			textTranlateDictionary["Core Emulation Settings..."] = "核心模拟设置";
			textTranlateDictionary["Audio Settings..."] = "音频设置";
			textTranlateDictionary["Non-Sync Settings..."] = "非同步设置";
			textTranlateDictionary["Palette..."] = "调色板";
			textTranlateDictionary["Video Plugins..."] = "视频插件";
			textTranlateDictionary["Mupen Style Lag Frames"] = "Mupen 风格延迟帧数";
			textTranlateDictionary["Use Expansion Slot"] = "使用扩展插槽";
			textTranlateDictionary["VS Settings..."] = "VS 设置";
			textTranlateDictionary["Advanced Settings..."] = "高级设置";
			textTranlateDictionary["Graphics Settings..."] = "图形设置";
			textTranlateDictionary["Controller / Memcard Settings..."] = "控制器/记忆卡设置";
			textTranlateDictionary["Options (as NTSC)..."] = "选项(NTSC 模式)";
			textTranlateDictionary["Options (as PAL)..."] = "选项(PAL 模式)";
			textTranlateDictionary["Choose Custom Palette..."] = "选择自定义调色板";
			textTranlateDictionary["Joystick Configuration..."] = "摇杆配置";

			// MainForm.cs
			textTranlateDictionary["Rewinder is capturing states"] = "倒带器正在捕获进度";
			textTranlateDictionary["{0}&{1}x"] = "{0}&{1}x";
			textTranlateDictionary["GB in SGB"] = "SGB 中的 GB";
			textTranlateDictionary["Set Libretro Core..."] = "设置 Libretro 核心...";
			textTranlateDictionary["Recent"] = "历史";
			textTranlateDictionary["(N/A)"] = "(不适用)";
			textTranlateDictionary["For Consoles"] = "主机";
			textTranlateDictionary["For Handhelds"] = "掌机";
			textTranlateDictionary["For Computers"] = "计算机";
			textTranlateDictionary["Other"] = "其他";
			textTranlateDictionary["Core Settings"] = "核心设置";
			textTranlateDictionary["Export Hard Disk Drive..."] = "导出硬盘驱动器...";
			textTranlateDictionary["(Dismiss Menu)"] = "(关闭菜单)";
			textTranlateDictionary["Warning"] = "警告";
			textTranlateDictionary["Couldn't initialize sound device! Try changing the output method in Sound config."] = "无法初始化声音设备！请尝试在声音配置中更改输出方式。";
			textTranlateDictionary["Initialization Error"] = "初始化错误";
			textTranlateDictionary["Failed to load {0} specified on commandline"] = "无法加载命令行中指定的 {0}";
			textTranlateDictionary["Failed to load movie {0} specified on commandline"] = "无法加载命令行中指定的影片 {0}";
			textTranlateDictionary["Quick reminder: Your copy of Windows 11 (build {0}) is no longer supported by Microsoft.\nEmuHawk will probably continue working, but please update to 24H2 for increased security."] = "温馨提示：您的 Windows 11 副本(内部版本 {0})已不再受微软支持。\nEmuHawk 可能仍能继续工作，但请更新到 24H2 以获得更高的安全性。";
			textTranlateDictionary["Quick reminder: Your copy of Windows 10 (build {0}) is no longer supported by Microsoft.\nEmuHawk will probably continue working, but please update to 22H2 for increased security."] = "温馨提示：您的 Windows 10 副本(内部版本 {0})已不再受微软支持。\nEmuHawk 可能仍能继续工作，但请更新到 22H2 以获得更高的安全性。";
			textTranlateDictionary["Quick reminder: Windows {0} is no longer supported by Microsoft.\nEmuHawk will probably continue working, but please get a new operating system for increased security (either Windows 10+ or a GNU+Linux distro)."] = "温馨提示：Windows {0} 已不再受微软支持。\nEmuHawk 可能仍能继续工作，但请更换新的操作系统以获得更高的安全性(Windows 10+ 或 GNU+Linux 发行版)。";
			textTranlateDictionary["{0}\n\nSkip this reminder from now on?"] = "{0}\n\n从现在起跳过此提示？";
			textTranlateDictionary["Really quit?"] = "确定要退出吗？";
			textTranlateDictionary["You are currently recording A/V.\nChoose \"Yes\" to finalise it and quit EmuHawk.\nChoose \"No\" to cancel shutdown and continue recording."] = "您当前正在录制音视频。\n选择\"是\"以完成录制并退出 EmuHawk。\n选择\"否\"以取消关闭并继续录制。";
			textTranlateDictionary["Failed to save config file."] = "保存配置文件失败。";
			textTranlateDictionary["Native Lua dynamic library was unable to be loaded. "] = "无法加载原生 Lua 动态库。";
			textTranlateDictionary["Make sure Lua is installed with your package manager."] = "请确保已通过包管理器安装 Lua。";
			textTranlateDictionary["This library is provided in the dll/ folder, try redownloading BizHawk to fix this error."] = "该库位于 dll/ 文件夹中，请尝试重新下载 BizHawk 以修复此错误。";
			textTranlateDictionary["Lua Load Error"] = "Lua 加载错误";
			textTranlateDictionary["Cheats are currently active"] = "作弊当前已激活";
			textTranlateDictionary["Verified good dump"] = "已验证的良好转储";
			textTranlateDictionary["Warning: Bad ROM Dump"] = "警告：不良 ROM 转储";
			textTranlateDictionary["Homebrew ROM"] = "自制 ROM";
			textTranlateDictionary["Translated ROM"] = "翻译版 ROM";
			textTranlateDictionary["Hacked ROM"] = "修改版 ROM";
			textTranlateDictionary["Warning: Overdump"] = "警告：过量转储";
			textTranlateDictionary["Warning: Unknown ROM"] = "警告：未知 ROM";
			textTranlateDictionary["Warning: Imperfect emulation"] = "警告：不完全模拟";
			textTranlateDictionary["Warning: Unemulated features"] = "警告：未模拟的功能";
			textTranlateDictionary["Warning: The game does not work"] = "警告：游戏无法运行";
			textTranlateDictionary["Warning: ROM of Unknown Character"] = "警告：性质不明的 ROM";
			textTranlateDictionary["Multi-disk bundler"] = "多碟打包器";
			textTranlateDictionary["The autosaved SaveRAM is more recent than the normal SaveRAM.\n"] = "自动保存的存档内存比普通存档内存更新。\n";
			textTranlateDictionary["This could happen due to a crash or because files were manually modified.\n"] = "这可能是由于崩溃或手动修改文件所致。\n";
			textTranlateDictionary["Do you want to load the autosave instead of the older SaveRAM file?"] = "是否加载自动保存而不是较旧的存档内存文件？";
			textTranlateDictionary["Load autosaved SaveRAM?"] = "加载自动保存的存档内存？";
			textTranlateDictionary["&Settings"] = "设置(&S)";
			textTranlateDictionary["Emulator Paused"] = "模拟器已暂停";
			textTranlateDictionary["Emulator is turbo seeking to frame {0} click to stop seek"] = "模拟器正在快速定位到帧 {0}，点击可停止定位";
			textTranlateDictionary["Emulator is playing to frame {0} click to stop seek"] = "模拟器正在播放到帧 {0}，点击可停止定位";
			textTranlateDictionary["Exception on drag and drop:\n{0}"] = "拖放时发生异常：\n{0}";
			textTranlateDictionary["No sync settings found, using currently configured settings for this core."] = "找不到同步设置，将使用此核心当前已配置的设置。";
			textTranlateDictionary["No sync settings found"] = "找不到同步设置";
			textTranlateDictionary["Link connection is currently {0}"] = "连接目前为 {0}";
			textTranlateDictionary["Core is producing audio, live playback at {0}% volume"] = "核心正在产生音频，以 {0}% 音量实时播放";
			textTranlateDictionary["Core is not producing audio"] = "核心未产生音频";
			textTranlateDictionary["Key priority: Allow both hotkeys and controller buttons"] = "按键优先级：快捷键和按键同级";
			textTranlateDictionary["Key priority: Controller buttons will override hotkeys"] = "按键优先级：按键将覆盖快捷键";
			textTranlateDictionary["Key priority: Hotkeys will override controller buttons"] = "按键优先级：快捷键将覆盖按键";
			textTranlateDictionary["(ported) "] = "(移植的)";
			textTranlateDictionary["how is an A/V recording starting with no game loaded? please report this including as much detail as possible"] = "在没有加载游戏的情况下怎么会开始音视频录制？请尽可能详细地报告此问题";
			textTranlateDictionary["A/V capture in progress"] = "音视频捕获进行中";
			textTranlateDictionary["Video dumping died:\n\n{0}"] = "视频转储已终止：\n\n{0}";
			textTranlateDictionary["Missing Firmware!"] = "缺少固件！";
			textTranlateDictionary["{0}\n\nOpen the firmware manager now?"] = "{0}\n\n现在打开固件管理器？";
			textTranlateDictionary["load error"] = "加载错误";
			textTranlateDictionary["{0} load error"] = "{0} 加载错误";
			textTranlateDictionary["Can't load a file via Libretro until a core is specified"] = "在指定核心之前无法通过 Libretro 加载文件";
			textTranlateDictionary["No such core"] = "没有此核心";
			textTranlateDictionary["Failed to save cheats."] = "保存作弊码失败。";
			textTranlateDictionary["Failed to save movie."] = "保存影片失败。";
			textTranlateDictionary["Failed to clear SRAM."] = "清除 SRAM 失败。";
			textTranlateDictionary["Failed flushing the game's Save RAM to your disk."] = "将游戏的 RAM 刷写到磁盘时失败。";
			textTranlateDictionary["Failed to auto-save state."] = "自动保存进度失败。";
			textTranlateDictionary["Conversion error"] = "转换错误";
			textTranlateDictionary["While the {0} core is faster, it is not nearly as accurate as {1}.{2}It is recommended that you switch to the {3} core for movie recording.{4}Switch to {5}?"] = "虽然 {0} 核心速度更快，但精度远不及 {1}。{2}建议切换到 {3} 核心进行影片录制。{4}切换到 {5}？";
			textTranlateDictionary["Accuracy Warning"] = "精度警告";
			textTranlateDictionary["Switch"] = "切换";
			textTranlateDictionary["Continue"] = "继续";
			textTranlateDictionary["Unable to save state."] = "无法保存进度。";
			textTranlateDictionary["file picker called with {0} set to a non-dir"] = "调用文件选择器时 {0} 被设置为非目录";
			textTranlateDictionary["file picker called with {0} set to a nonexistent path"] = "调用文件选择器时 {0} 被设置为不存在的路径";
			textTranlateDictionary["Dump Status Report{0}..."] = "转储状态报告 {0}";
			textTranlateDictionary["Loaded core: {0} ({1})"] = "加载的内核 {0} ({1})";
			textTranlateDictionary["Tool Box"] = "工具箱";

			// OpenAdvancedChooser.cs
			textTranlateDictionary["Couldn't load the selected Libretro core for analysis. It won't be available.\n\nError:\n\n{0}"] = "无法加载所选的 Libretro 核心用于分析。它将不可用。\n\n错误：\n\n{0}";

			// Program.cs
			textTranlateDictionary["EmuHawk requires a 64 bit environment in order to run! EmuHawk will now close."] = "EmuHawk 需要 64 位环境才能运行！EmuHawk 现在将关闭。";
			textTranlateDictionary["One or more of the BizHawk.* assemblies have the wrong version!\n(Did you attempt to update by overwriting an existing install?)"] = "一个或多个 BizHawk.* 程序集版本不正确！\n(您是否尝试通过覆盖现有安装来更新？)";
			textTranlateDictionary["Mismatched version in config file"] = "配置文件中的版本不匹配";
			textTranlateDictionary["It appears your config file (config.ini) is corrupted; an exception was thrown while loading it."] = "您的配置文件 (config.ini) 似乎已损坏；加载时抛出了异常。";
			textTranlateDictionary["On closing this warning, EmuHawk will delete your config file and generate a new one. You can go make a backup now if you'd like to look into diffs."] = "关闭此警告后，EmuHawk 将删除您的配置文件并生成新的文件。如果您想查看差异，可以现在去备份。";
			textTranlateDictionary["The caught exception was:"] = "捕获的异常为：";
			textTranlateDictionary["Initialization of Display Method failed; falling back to {0}"] = "显示方式初始化失败；回退到 {0}";
			textTranlateDictionary["Initialization of Direct3D11 Display Method failed; falling back to {0}"] = "Direct3D11 显示方式初始化失败；回退到 {0}";
			textTranlateDictionary["Initialization of OpenGL Display Method failed; falling back to {0}"] = "OpenGL 显示方式初始化失败；回退到 {0}";
			textTranlateDictionary["SetDllDirectoryW failed with error code {0}, this is fatal. EmuHawk will now close."] = "SetDllDirectoryW 失败，错误代码 {0}，这是致命错误。EmuHawk 现在将关闭。";
			textTranlateDictionary["This EmuHawk is privileged"] = "此 EmuHawk 以特权身份运行";
			textTranlateDictionary["EmuHawk detected it {0}.\n"] = "EmuHawk 检测到它 {0}。\n";
			textTranlateDictionary["Regularly using {0} for things other than system administration makes it easier to hack you.\n"] = "经常将 {0} 用于系统管理之外的事务会让您更容易被入侵。\n";
			textTranlateDictionary["If you're certain, you may continue anyway (and without support).\n"] = "如果您确定，仍可继续（但不提供支持）。\n";
			textTranlateDictionary["You'll find a flag \"{0}\" in the config file, which disables this warning."] = "您可以在配置文件中找到标志 \"{0}\"，该标志可禁用此警告。";
			textTranlateDictionary["EmuHawk has thrown a fatal exception and is about to close.\nA movie has been detected. Would you like to try to save?\n(Note: Depending on what caused this error, this may or may not succeed)"] = "EmuHawk 已抛出致命异常，即将关闭。\n检测到影片。是否尝试保存？\n（注意：取决于导致此错误的原因，此操作可能成功也可能失败）";
			textTranlateDictionary["Fatal error: {0}"] = "致命错误：{0}";

			// RetroAchievements/RAIntegration.Update.cs
			textTranlateDictionary["An update is required to use RetroAchievements. Do you want to download the update now?"] = "使用 RetroAchievements 需要更新。是否立即下载更新？";
			textTranlateDictionary["Update"] = "更新";
			textTranlateDictionary["An optional update is available for RetroAchievements. Do you want to download the update now?"] = "RetroAchievements 有可选更新。是否立即下载更新？";
			textTranlateDictionary["Failed to fetch update information, cannot start RetroAchievements."] = "获取更新信息失败，无法启动 RetroAchievements。";
			textTranlateDictionary["Exception {0} occurred when fetching update information, cannot start RetroAchievements."] = "获取更新信息时发生异常 {0}，无法启动 RetroAchievements。";

			// RetroAchievements/RAIntegration.cs
			textTranlateDictionary["Shutdown RetroAchievements"] = "关闭 RetroAchievements";
			textTranlateDictionary["Autostart RetroAchievements"] = "自动启动 RetroAchievements";
			textTranlateDictionary["{0} Disabling hardcore mode."] = "{0} 正在禁用硬核模式。";
			textTranlateDictionary["Loading savestates is not allowed in hardcore mode."] = "硬核模式下不允许加载进度。";
			textTranlateDictionary["Failed to reboot core."] = "重启核心失败。";

			// RetroAchievements/RAIntegrationDownloaderForm.cs
			textTranlateDictionary["untrusted hostname"] = "不受信任的主机名";

			// RetroAchievements/RCheevos.cs
			textTranlateDictionary["Login"] = "登录";
			textTranlateDictionary["Logout"] = "注销";
			textTranlateDictionary["Enable Achievements"] = "启用成就";
			textTranlateDictionary["Enable Leaderboard Notifications"] = "启用排行榜通知";
			textTranlateDictionary["Enable Rich Presence"] = "启用丰富状态";
			textTranlateDictionary["Enable Hardcore Mode"] = "启用硬核模式";
			textTranlateDictionary["Enable Sound Effects"] = "启用音效";
			textTranlateDictionary["Test Unofficial Achievements"] = "测试非官方成就";
			textTranlateDictionary["View Game Info"] = "查看游戏信息";
			textTranlateDictionary["View Achievement List"] = "查看成就列表";
			textTranlateDictionary["View Leaderboard List"] = "查看排行榜列表";
			textTranlateDictionary["rc_runtime_alloc returned NULL!"] = "rc_runtime_alloc 返回了 NULL！";
			textTranlateDictionary["Loading a quicksave is not allowed in hardcode mode. Abort loading state?"] = "硬核模式下不允许加载快速存档。是否中止加载进度？";
			textTranlateDictionary["_memFunctions must have less than 256 memory banks"] = "_memFunctions 的内存块数量必须少于 256";
			textTranlateDictionary["Requested {0} in {1}"] = "在 {1} 中请求了 {0}";

			// RetroAchievements/RCheevosLoginForm.cs
			textTranlateDictionary["Login successful"] = "登录成功";
			textTranlateDictionary["Login failed"] = "登录失败";

			// RetroAchievements/RetroAchievements.GameVerification.cs
			textTranlateDictionary["Could not find first data track for hashing"] = "找不到用于哈希的第一个数据轨道";
			textTranlateDictionary["Malformed key list"] = "键列表格式错误";
			textTranlateDictionary["Invalid key length"] = "无效的键长度";
			textTranlateDictionary["Couldn't find requested keys"] = "找不到请求的键";

			// RetroAchievements/RetroAchievements.Hardcore.cs
			textTranlateDictionary["All loaded games were not verified."] = "所有已加载的游戏均未验证。";
			textTranlateDictionary["Playing a movie while in hardcore mode is not allowed."] = "硬核模式下不允许播放影片。";
			textTranlateDictionary["Using cheat codes while in hardcore mode is not allowed."] = "硬核模式下不允许使用作弊码。";
			textTranlateDictionary["Slow motion in hardcore mode is not allowed."] = "硬核模式下不允许使用慢动作。";
			textTranlateDictionary["Using {0} in hardcore mode is not allowed."] = "硬核模式下不允许使用 {0}。";
			textTranlateDictionary["Using external tools in hardcore mode is not allowed."] = "硬核模式下不允许使用外部工具。";
			textTranlateDictionary["Using subframes in hardcore mode is not allowed."] = "硬核模式下不允许使用子帧。";
			textTranlateDictionary["Using MAME in hardcore mode is not allowed."] = "硬核模式下不允许使用 MAME。";
			textTranlateDictionary["Disabling {0}'s graphics layers in hardcore mode is not allowed."] = "硬核模式下不允许禁用 {0} 的图形图层。";
			textTranlateDictionary["Disabling GambatteLink's graphics layers in hardcore mode is not allowed."] = "硬核模式下不允许禁用 GambatteLink 的图形图层。";
			textTranlateDictionary["Disabling Gambatte's graphics layers in hardcore mode is not allowed."] = "硬核模式下不允许禁用 Gambatte 的图形图层。";
			textTranlateDictionary["Disabling DSi NAND clear in hardcore mode is not allowed."] = "硬核模式下不允许禁用 DSi NAND 清除。";
			textTranlateDictionary["Disabling Skip Firmware in DSi mode in hardcore mode is not allowed."] = "硬核模式下不允许在 DSi 模式中禁用跳过固件。";
			textTranlateDictionary["Disabling {0}'s {1} in hardcore mode is not allowed."] = "硬核模式下不允许禁用 {0} 的 {1}。";

			// RetroAchievements/RetroAchievements.Memory.cs
			textTranlateDictionary["Invalid {0}"] = "无效的 {0}";
			textTranlateDictionary["bankSize is too big!"] = "bankSize 过大！";

			// RetroAchievements/RetroAchievements.cs
			textTranlateDictionary["In order to use RetroAchievements, some information needs to be sent to retroachievements.org:\n"] = "为了使用 RetroAchievements，需要向 retroachievements.org 发送一些信息：\n";
			textTranlateDictionary["\n\u2022 Your RetroAchievements username and password (first login) or token (subsequent logins)."] = "\n\u2022 您的 RetroAchievements 用户名和密码(首次登录)或令牌(后续登录)。";
			textTranlateDictionary["\n\u2022 The hash of the game(s) you have loaded into BizHawk. (for game identification + achievement unlock + leaderboard submission)"] = "\n\u2022 您已加载到 BizHawk 中的游戏的哈希值。(用于游戏识别 + 成就解锁 + 排行榜提交)";
			textTranlateDictionary["\n\u2022 The RetroAchievements game ID(s) of the game(s) you have loaded into BizHawk. (for game information + achievement definitions + leaderboard definitions + rich presence definitions + code notes + achievement badges + user unlocks + leaderboard submission + ticket submission)"] = "\n\u2022 您已加载到 BizHawk 中的游戏的 RetroAchievements 游戏 ID。(用于游戏信息 + 成就定义 + 排行榜定义 + 丰富状态定义 + 代码注释 + 成就徽章 + 用户解锁 + 排行榜提交 + 工单提交)";
			textTranlateDictionary["\n\u2022 Rich presence data (periodically sent, derived from emulated game memory)."] = "\n\u2022 丰富状态数据(定期发送，从模拟的游戏内存中导出)。";
			textTranlateDictionary["\n\u2022 Whether or not you are currently in \"Hardcore Mode\" (for achievement unlock)."] = "\n\u2022 您当前是否处于\"硬核模式\"(用于成就解锁)。";
			textTranlateDictionary["\n\u2022 Ticket submission type and message (when submitting tickets with RAIntegration)."] = "\n\u2022 工单提交类型和消息(使用 RAIntegration 提交工单时)。";
			textTranlateDictionary["\n\nDo you agree to send this information to retroachievements.org?"] = "\n\n您是否同意将这些信息发送到 retroachievements.org？";
			textTranlateDictionary["Notice"] = "注意";

			// Sound/Sound.cs
			textTranlateDictionary["Unsupported sync mode."] = "不支持的同步模式。";

			// config/AmstradCPC/AmstradCPCCoreEmulationSettings.cs
			textTranlateDictionary["Approximates what you see on a CPC monitor"] = "近似 CPC 显示器上的效果";
			textTranlateDictionary["The full display area"] = "完整显示区域";

			// config/AmstradCPC/AmstradCPCNonSyncSettings.cs
			textTranlateDictionary["Show all OSD messages"] = "显示所有 OSD 消息";
			textTranlateDictionary["Only show machine/device generated messages"] = "仅显示机器/设备生成的消息";
			textTranlateDictionary["No core-driven OSD messages"] = "不显示核心驱动的 OSD 消息";

			// config/ControllerConfig.cs
			textTranlateDictionary["{0} Configuration"] = "{0} 配置";
			textTranlateDictionary["OK to overwrite defaults for current control scheme?"] = "确定要覆盖当前控制方案的默认值吗？";
			textTranlateDictionary["Save Defaults"] = "保存默认值";

			// config/ControllerConfig/AnalogBindControl.cs
			textTranlateDictionary["Bind!"] = "绑定！";
			textTranlateDictionary["Cancel!"] = "取消！";
			textTranlateDictionary["Sensitivity: {0:P0}"] = "灵敏度：{0:P0}";
			textTranlateDictionary["Deadzone: {0:P0}"] = "死区：{0:P0}";

			// config/ControllerConfig/FeedbackBindControl.cs
			textTranlateDictionary["Unbind!"] = "解绑！";
			textTranlateDictionary["Pre-scaled by: {0:F1}x"] = "预缩放：{0:F1}x";

			// config/ControllerConfig/FeedbacksBindPanel.cs
			textTranlateDictionary["To bind, click \"Bind!\", move an axis (e.g. analog stick) on the desired gamepad, and choose from the dropdown."] = "要绑定，请点击\"绑定！\"，在目标手柄上移动一个轴（例如模拟摇杆），然后从下拉列表中选择。";

			// config/DisplayConfig.cs
			textTranlateDictionary["Window title suffix (static and not):"] = "窗口标题后缀(静态和动态)：";
			textTranlateDictionary["Snowy NullHawk"] = "NullHawk 雪花";
			textTranlateDictionary["Always"] = "总是";
			textTranlateDictionary["During Christmas (Dec. 20th through 26th)"] = "圣诞节期间(12月20日至26日)";
			textTranlateDictionary["Never"] = "从不";
			textTranlateDictionary["Framerate: {0:F1} Hz"] = "帧率：{0:F1} Hz";
			textTranlateDictionary["When no rom loaded, draw \"snow\" (white noise):"] = "未加载 ROM 时绘制\"雪花\"(白噪声)：";
			textTranlateDictionary["Brightness multiplier:"] = "亮度倍数：";
			textTranlateDictionary["RNG bias:"] = "随机数偏差：";
			textTranlateDictionary["{0:P2}"] = "{0:P2}";
			textTranlateDictionary["Thin"] = "细";
			textTranlateDictionary["Thick"] = "粗";

			// config/EmuHawkOptions.cs
			textTranlateDictionary["Enable Wii U/Switch GameCube Adapter Support (via libusb)"] = "启用 Wii U/Switch GameCube 适配器支持(通过 libusb)";
			textTranlateDictionary["Enable Wii U/Switch GameCube Adapter Support (via Zadig/WinUSB)"] = "启用 Wii U/Switch GameCube 适配器支持(通过 Zadig/WinUSB)";
			textTranlateDictionary["Would you like to replace {0},\nand the same for the other modifier keys,\nin existing keybinds for hotkeys and all systems' gamepads?"] = "是否替换 {0}，\n以及其他修饰键，\n在快捷键和所有系统手柄的现有按键绑定中？";
			textTranlateDictionary["Rewrite keybinds now?"] = "立即重写按键绑定？";

			// config/FileExtensionPreferencesPicker.cs
			textTranlateDictionary["Ask me on load"] = "加载时询问";

			// config/FirmwareConfig.cs
			textTranlateDictionary["BAD! Why are you using this file"] = "差！你为什么在使用这个文件";
			textTranlateDictionary["NO: This doesn't work on the core"] = "否：此文件在此核心上无法工作";
			textTranlateDictionary["OK: This works on the core"] = "可：此文件在此核心上可以工作";
			textTranlateDictionary["PERFECT: Ideal for TASing and anything"] = "完美：适用于 TAS 及一切用途";
			textTranlateDictionary["Close Firmware Manager and reload ROM"] = "关闭固件管理器并重新加载 ROM";
			textTranlateDictionary["Close Firmware Manager and reload {0}"] = "关闭固件管理器并重新加载 {0}";
			textTranlateDictionary["No file bound for this firmware!"] = "此固件未绑定任何文件！";
			textTranlateDictionary["You've bound a custom choice here. Hope you know what you're doing."] = "您在此处绑定了自定义选项。希望您清楚自己在做什么。";
			textTranlateDictionary["-custom-"] = "-自定义-";
			textTranlateDictionary["Perfect! This file has been bound to an ideal choice"] = "完美！此文件已绑定到理想选项";
			textTranlateDictionary["Good! This file has been bound to some kind of a decent choice"] = "良好！此文件已绑定到一种还算不错的选择";
			textTranlateDictionary["Bad! This file has been bound to a choice which is known to be bad (details in right-click -> Info)"] = "差！此文件已绑定到已知的不良选项（详细信息请右键 -> 信息）";
			textTranlateDictionary["The file that's specified is missing!"] = "指定的文件缺失！";
			textTranlateDictionary["You've manually specified a firmware file, and we're sure it's wrong. Hope you know what you're doing."] = "您手动指定了一个固件文件，我们确定它是错误的。希望您清楚自己在做什么。";
			textTranlateDictionary["Organize firmware"] = "整理固件";
			textTranlateDictionary["This is going to move/rename every automatically-selected firmware file under your configured Firmware folder to match our recommended organizational scheme (which is not super great right now)."] = "这将移动/重命名您配置的固件文件夹下每一个自动选择的固件文件，以匹配我们推荐的整理方案(目前并不是特别好)。";
			textTranlateDictionary["\nProceed?"] = "\n是否继续？";
			textTranlateDictionary["The selected custom firmware does not reside in the root of the global firmware directory.\nDo you want to copy it there?"] = "所选择的自定义固件不在全局固件目录的根目录下。\n是否将其复制到那里？";
			textTranlateDictionary["Import Custom Firmware"] = "导入自定义固件";
			textTranlateDictionary["There was an issue copying the file. The customization has NOT been set.\n\n{0}"] = "复制文件时出现问题。自定义设置未生效。\n\n{0}";
			textTranlateDictionary["There was an issue during the process. The customization has NOT been set.\n\n{0}"] = "过程中出现问题。自定义设置未生效。\n\n{0}";
			textTranlateDictionary["Error importing these files"] = "导入这些文件时出错";

			// config/GB/ColorChooserForm.cs
			textTranlateDictionary["Error loading .pal file!"] = "加载 .pal 文件出错！";
			textTranlateDictionary["Error saving .pal file!"] = "保存 .pal 文件出错！";

			// config/GB/SameBoyColorChooserForm.cs

			// config/GenericCoreConfig.cs

			// config/HotkeyConfig.cs
			textTranlateDictionary["Save States hotkeys operate with branches when TAStudio is engaged."] = "启用 TAStudio 时，保存进度快捷键将配合分支工作。";

			// config/InputCompositeWidget.cs
			textTranlateDictionary["* Escape clears a key mapping\r\n* Disable Auto Tab to multiply bind"] = "* Escape 键可清除按键映射\r\n* 禁用自动切换以实现多重绑定";
			textTranlateDictionary["Click here for special tricky bindings"] = "点击此处进行特殊的复杂绑定";
			textTranlateDictionary["Current Binding: {0}"] = "当前绑定：{0}";

			// config/Messages/MessageConfig.cs
			textTranlateDictionary["Messages fade after"] = "消息消失于";
			textTranlateDictionary["seconds"] = "秒后";
			textTranlateDictionary["Fps"] = "帧率";
			textTranlateDictionary["Frame Counter"] = "帧数";
			textTranlateDictionary["Lag Counter"] = "延迟帧数";
			textTranlateDictionary["Input Display"] = "输入";
			textTranlateDictionary["Watches"] = "监视";
			textTranlateDictionary["Messages"] = "消息";
			textTranlateDictionary["Rerecords"] = "重录次数";
			textTranlateDictionary["Autohold"] = "挂键";
			textTranlateDictionary["Main Messages"] = "主要消息";
			textTranlateDictionary["Alert Messages"] = "警告消息";
			textTranlateDictionary["Previous Frame Input"] = "前帧输入";
			textTranlateDictionary["Movie Input"] = "影片输入";

			// config/N64/N64ControllerSettingControl.cs
			textTranlateDictionary["Controller {0}"] = "控制器 {0}";

			// config/NES/NESSoundConfig.cs
			textTranlateDictionary["NES Sound Channels"] = "NES 声音通道";

			// config/NES/NESSyncSettingsForm.cs
			textTranlateDictionary["Board Properties are special per-mapper system settings.  They are only useful to advanced users creating Tool Assisted Superplays.  No support will be provided if you break something with them."] = "基板属性是针对 Mapper 的特殊系统设置，仅适合制作 TAS 的高级用户。如果您因使用它们而出现问题，我们将不提供支持。";
			textTranlateDictionary["Help"] = "帮助";

			// config/PSX/PSXHashDiscs.cs
			textTranlateDictionary["PSX Disc Hasher"] = "PSX 光盘哈希工具";

			// config/PSX/PSXOptions.cs
			textTranlateDictionary["Finetuned Display Options will take effect if you OK from PSX Options"] = "如果您从 PSX 选项中点确定，微调后的显示选项将生效";
			textTranlateDictionary[@"These options control BizHawk's Display Options to make it act quite a lot like Mednafen:

{0} = System (Use emulator-recommended AR)
{1} = true (Maintain aspect ratio[letterbox main window as needed])
{2} = bilinear (Like Mednafen)
{3} = false (Generally unwanted with bilinear filtering)

This is a good place to write that Mednafen's default behaviour is fantastic for gaming!
But: 1. we think we improved on it a tiny bit with the tweaked mode
And: 2. It's not suitable for detailed scrutinizing of graphics
"] = @"这些选项控制 BizHawk 的显示选项，使其表现与 Mednafen 非常相似：

{0} = 系统（使用模拟器推荐的宽高比）
{1} = true（保持宽高比 [根据需要为窗口添加黑边]）
{2} = 双线性（类似 Mednafen）
{3} = false（通常与双线性过滤搭配时不需要）

这是个好地方，可以写下：Mednafen 的默认行为对于游戏来说非常棒！
但是：1. 我们认为通过调整模式对它做了一点改进
而且：2. 它不适合对图形进行细致的审查
";

			// config/PathConfig.cs
			textTranlateDictionary["Set the directory for {0}"] = "设置 {0} 的目录";

			// config/RewindConfig.cs
			textTranlateDictionary["{0:n0} frames"] = "{0:n0} 帧";
			textTranlateDictionary["{0:n} minutes"] = "{0:n} 分";

			// config/ZXSpectrum/ZXSpectrumCoreEmulationSettings.cs
			textTranlateDictionary["Original border sizes"] = "原始边框尺寸";
			textTranlateDictionary["All borders 24px"] = "所有边框 24px";
			textTranlateDictionary["No border at all"] = "无边框";
			textTranlateDictionary["All borders 10px"] = "所有边框 10px";
			textTranlateDictionary["No top and bottom border (almost 16:9)"] = "去除上下边框（接近 16:9）";

			// config/ZXSpectrum/ZXSpectrumJoystickSettings.cs
			textTranlateDictionary["Invalid joystick configuration. \nDuplicates have automatically been changed to NULL.\n\nPlease review the configuration"] = "摇杆配置无效。\n重复项已自动改为 NULL。\n\n请检查配置";

			// config/ZXSpectrum/ZXSpectrumNonSyncSettings.cs

			// debug/FirmwareAutopatchDebugToolForm.cs
			textTranlateDictionary["dry run (skip writing to disk)"] = "试运行（跳过写入磁盘）";
			textTranlateDictionary["wrote {0}"] = "已写入 {0}";
			textTranlateDictionary["success"] = "成功";
			textTranlateDictionary["patchset declared with target\nSHA1:{0}\nbut produced\nSHA1:{1}\n(is the patch wrong, or the hash?)"] = "补丁集声明的目标为\nSHA1:{0}\n但产生的结果为\nSHA1:{1}\n(是补丁有误，还是哈希有误？)";
			textTranlateDictionary["patchset declared for base\nSHA1:{0}\nbut\nSHA1:{1}\nwas provided"] = "补丁集声明的基准为\nSHA1:{0}\n但提供的是\nSHA1:{1}";
			textTranlateDictionary["caught {0}:\n{1}"] = "捕获到 {0}：\n{1}";
			textTranlateDictionary["apply"] = "应用";
			textTranlateDictionary["to file"] = "到文件";
			textTranlateDictionary["(browse)"] = "（浏览）";
			textTranlateDictionary["patched files are saved in dir set as \"Temp Files\""] = "已修补的文件保存在设置为\"临时文件\"的目录中";
			textTranlateDictionary["--> patch"] = "--> 打补丁";
			textTranlateDictionary["Manual Firmware Autopatching Tool"] = "固件手动自动打补丁工具";

			// debug/N64RomByteswapToolForm.cs
			textTranlateDictionary["wrote {0}\n{1}"] = "已写入 {0}\n{1}";
			textTranlateDictionary["convert"] = "转换";
			textTranlateDictionary["from <autodetected> (assumes .z64 on fail)"] = "从 <自动检测>（失败时假定为 .z64）";
			textTranlateDictionary["to"] = "到";
			textTranlateDictionary["--> convert"] = "--> 转换";
			textTranlateDictionary["Manual N64 ROM Byteswapping Tool"] = "N64 ROM 手动字节交换工具";

			// debug/N64VideoSettingsFuzzToolForm.cs
			textTranlateDictionary["--> randomise some props"] = "--> 随机化部分属性";
			textTranlateDictionary["--> randomise every prop"] = "--> 随机化所有属性";
			textTranlateDictionary["N64 Video Settings Fuzzer"] = "N64 视频设置模糊测试器";

			// movie/EditCommentsForm.cs

			// movie/EditSubtitlesForm.cs
			textTranlateDictionary["Unable to parse value: {0}"] = "无法解析值：{0}";
			textTranlateDictionary["Parse Error Row {0} Column {1}"] = "解析错误 行 {0} 列 {1}";
			textTranlateDictionary["Could not determine movie fps, export failed."] = "无法确定影片帧率，导出失败。";
			textTranlateDictionary["Subtitles successfully exported to {0}."] = "字幕已成功导出到 {0}。";
			textTranlateDictionary["Success"] = "成功";

			// movie/PlayMovie.cs
			textTranlateDictionary["Unable to load movie {0}"] = "无法加载影片 {0}";
			textTranlateDictionary["{0} {1}"] = "{0} {1}";
			textTranlateDictionary["Expected: {0}\nActual: {1}"] = "预期：{0}\n实际：{1}";
			textTranlateDictionary["Expected: {0}\n Actual: {1}"] = "预期：{0}\n 实际：{1}";
			textTranlateDictionary["Unable to load movie {0}"] = "加载影片 {0} 失败";

			// movie/RecordMovie.cs
			textTranlateDictionary["how is the traditional Record dialog open with no game loaded? please report this including as much detail as possible"] = "在没有加载游戏的情况下怎么会打开传统录制对话框？请尽可能详细地报告此问题";
			textTranlateDictionary["&Cancel"] = "取消(&C)";
			textTranlateDictionary["&OK"] = "确定(&O)";
			textTranlateDictionary["Make default author"] = "设为默认作者";
			textTranlateDictionary["File:"] = "文件：";
			textTranlateDictionary["Author:"] = "作者：";
			textTranlateDictionary["Record From:"] = "录制起始：";
			textTranlateDictionary["Record Movie"] = "录制影片";
			textTranlateDictionary["{0} already exists, overwrite?"] = "{0} 已存在，是否覆盖？";
			textTranlateDictionary["Confirm overwrite"] = "确认覆盖";
			textTranlateDictionary["Please select a movie to record"] = "请选择要录制的影片";
			textTranlateDictionary["File selection error"] = "文件选择错误";

			// tools/BasicBot/BasicBot.cs
			textTranlateDictionary["Basic Bot"] = "基础机器人";
			textTranlateDictionary["In order to use this tool you must be recording a movie."] = "要使用此工具，您必须正在录制影片。";
			textTranlateDictionary["In order to use this tool, U+D/L+R policy in the controller binds dialog must be set to 'Allow'."] = "要使用此工具，控制器绑定对话框中的 U+D/L+R 策略必须设置为\"允许\"。";
			textTranlateDictionary["Replaying"] = "重放中";
			textTranlateDictionary["This file was made for a different system ({0})."] = "此文件是为不同的系统制作的({0})。";
			textTranlateDictionary[" with a different core ({0})"] = " 使用了不同的核心({0})";
			textTranlateDictionary[" with a different version of EmuHawk"] = " 使用了不同版本的 EmuHawk";
			textTranlateDictionary[" with a different core ({0}) on a different version of EmuHawk"] = " 在不同版本的 EmuHawk 上使用了不同的核心({0})";
			textTranlateDictionary["for a different game ({0}){1}"] = "为不同的游戏({0}){1}";
			textTranlateDictionary["This file was made {0}. Load it anyway?"] = "此文件是为 {0} 制作的。仍要加载吗？";
			textTranlateDictionary["Confirm file load"] = "确认加载文件";
			textTranlateDictionary["{0} loaded"] = "已加载 {0}";
			textTranlateDictionary["{0} saved"] = "已保存 {0}";
			textTranlateDictionary["Replay stopped"] = "重放已停止";
			textTranlateDictionary["Running..."] = "运行中...";
			textTranlateDictionary["At least one control must have a probability greater than 0."] = "至少要有一个操作的概率大于 0。";
			textTranlateDictionary["A main value address is required."] = "需要提供一个主值地址。";
			textTranlateDictionary["A frame count greater than 0 is required"] = "帧数需要大于 0";
			textTranlateDictionary["Bot stopped"] = "机器人已停止";
			textTranlateDictionary["Replaying best result"] = "正在重放最佳结果";
			textTranlateDictionary["Botting in progress"] = "机器人运行中";
			textTranlateDictionary["Bot is currently not running"] = "机器人当前未运行";

			// tools/BatchRun.cs
			textTranlateDictionary["Number of files: {0}"] = "文件数：{0}";
			textTranlateDictionary["Old one still running!"] = "旧的还在运行！";
			textTranlateDictionary["No files!"] = "没有文件！";
			textTranlateDictionary["Status: Running..."] = "状态：运行中...";
			textTranlateDictionary["Status: Finished!"] = "状态：已完成！";
			textTranlateDictionary["The Whole Thing Died!"] = "全部任务异常终止！";
			textTranlateDictionary["Deaded!"] = "已终止！";
			textTranlateDictionary["Can't close while task is running!"] = "任务运行时无法关闭！";
			textTranlateDictionary["No results to save!"] = "没有结果可保存！";

			// tools/CDL.cs
			textTranlateDictionary["Code Data Logger"] = "代码数据记录器";
			textTranlateDictionary["Save changes to CDL session?"] = "是否保存对 CDL 会话的更改？";
			textTranlateDictionary["CDL Save"] = "CDL 保存";
			textTranlateDictionary["CDL file does not match emulator's current memory map!"] = "CDL 文件与模拟器当前的内存映射不匹配！";
			textTranlateDictionary["OK to create new CDL?"] = "确定要创建新的 CDL 吗？";
			textTranlateDictionary["Query"] = "询问";
			textTranlateDictionary["OK to load new CDL?"] = "确定要加载新的 CDL 吗？";
			textTranlateDictionary["Failed to save CDL session."] = "保存 CDL 会话失败。";
			textTranlateDictionary["Cannot save with no CDL loaded!"] = "未加载 CDL 时无法保存！";
			textTranlateDictionary["Alert"] = "警告";
			textTranlateDictionary["Cannot append with no CDL loaded!"] = "未加载 CDL 时无法追加！";
			textTranlateDictionary["Cannot clear with no CDL loaded!"] = "未加载 CDL 时无法清除！";
			textTranlateDictionary["OK to clear CDL?"] = "确定要清除 CDL 吗？";
			textTranlateDictionary["Cannot disassemble with no CDL loaded!"] = "未加载 CDL 时无法反汇编！";
			textTranlateDictionary["CDL File @"] = "CDL文件于";
			textTranlateDictionary["Domain"] = "域";
			textTranlateDictionary["Percent"] = "百分比";
			textTranlateDictionary["Mapped"] = "已映射";

			// tools/Cheats/CheatEdit.cs
			textTranlateDictionary["0x{0:X} is not a valid address for the domain {1}"] = "0x{0:X} 不是域 {1} 的有效地址";
			textTranlateDictionary["Index out of range"] = "索引超出范围";


			// tools/Cheats/Cheats.cs
			textTranlateDictionary["Cheats"] = "作弊";
			textTranlateDictionary["{0} {1} {2} active"] = "{0} {1} {2} 已激活";
			textTranlateDictionary["{0} saved."] = "已保存 {0}。";
			textTranlateDictionary["{0} *"] = "{0} *";
			textTranlateDictionary["Big"] = "大端";
			textTranlateDictionary["Little"] = "小端";
			textTranlateDictionary["New Cheat"] = "新建作弊码";
			textTranlateDictionary["Editing Cheat {0} - {1}"] = "正在编辑作弊码 {0} - {1}";
			textTranlateDictionary["Multiple Cheats Selected"] = "已选择多个作弊码";
			textTranlateDictionary["Names"] = "名称";
			textTranlateDictionary["Address"] = "地址";
			textTranlateDictionary["Value"] = "值";
			textTranlateDictionary["Compare"] = "比较";
			textTranlateDictionary["Compare Type"] = "比较类型";
			textTranlateDictionary["On"] = "开";
			textTranlateDictionary["Size"] = "大小";
			textTranlateDictionary["Endian"] = "序";
			textTranlateDictionary["Display Type"] = "显示类型";
			textTranlateDictionary["Cheat codes not currently supported on this system"] = "当前系统不支持作弊码";

			// tools/Debugger/AddBreakpointDialog.cs
			textTranlateDictionary["Add Breakpoint"] = "添加断点";
			textTranlateDictionary["Duplicate Breakpoint"] = "克隆断点";
			textTranlateDictionary["Edit Breakpoint"] = "编辑断点";

			// tools/Debugger/BreakpointControl.cs
			textTranlateDictionary["{0} Total / {1} Active"] = "{0} 总计 / {1} 活动";

			// tools/Debugger/GenericDebugger.cs
			textTranlateDictionary["Debugger"] = "调试器";
			textTranlateDictionary["This core does not currently support disassembling"] = "此核心目前不支持反汇编";
			textTranlateDictionary["This core does not currently implement this feature"] = "此核心目前未实现此功能";
			textTranlateDictionary["This core does not currently support reading registers"] = "此核心目前不支持读取寄存器";
			textTranlateDictionary["This core does not currently support breakpoints"] = "此核心目前不支持断点";

			// tools/ExternalToolManager.cs
			textTranlateDictionary["This tool doesn't work when no rom is loaded"] = "未加载 ROM 时此工具无法工作";
			textTranlateDictionary["This tool doesn't work with this system"] = "此工具不适用于此系统";
			textTranlateDictionary["This tool doesn't work with this game"] = "此工具不适用于此游戏";
			textTranlateDictionary["The IExternalToolForm has conflicting applicability attributes."] = "IExternalToolForm 具有冲突的适用范围属性。";
			textTranlateDictionary["The assembly doesn't contain a class implementing IExternalToolForm and annotated with[ExternalTool]."] = "程序集不包含实现 IExternalToolForm 并带有 [ExternalTool] 标注的类。";
			textTranlateDictionary["Something went wrong while trying to load the assembly."] = "尝试加载程序集时出现问题。";
			textTranlateDictionary["An exception of type {0} was thrown while trying to load the assembly and look for an IExternalToolForm:\n{1}"] = "尝试加载程序集并查找 IExternalToolForm 时抛出了类型为 {0} 的异常：\n{1}";

			// tools/GBA/GBAGPUView.cs
			textTranlateDictionary["GBA GPU Viewer"] = "GBA GPU 查看器";
			textTranlateDictionary["Background 0"] = "背景 0";
			textTranlateDictionary["Background 1"] = "背景 1";
			textTranlateDictionary["Background 2"] = "背景 2";
			textTranlateDictionary["Background 3"] = "背景 3";
			textTranlateDictionary["Background Palettes"] = "背景调色板";
			textTranlateDictionary["Sprite Palettes"] = "精灵调色板";
			textTranlateDictionary["Sprites"] = "精灵";
			textTranlateDictionary["Sprite Tiles (4bpp)"] = "精灵块 (4bpp)";
			textTranlateDictionary["Sprite Tiles (8bpp)"] = "精灵块 (8bpp)";
			textTranlateDictionary["Background Tiles (4bpp)"] = "背景块 (4bpp)";
			textTranlateDictionary["Background Tiles (8bpp)"] = "背景块 (8bpp)";
			textTranlateDictionary["Scanline {0}"] = "扫描线 {0}";
			textTranlateDictionary["CTRL + C: Copy under mouse to clipboard."] = "CTRL + C：将鼠标下方的内容复制到剪贴板。";
			textTranlateDictionary["{0} copied to clipboard."] = "{0} 已复制到剪贴板。";

			// tools/GB/GBGPUView.cs
			textTranlateDictionary["GPU Viewer"] = "GPU 查看器";
			textTranlateDictionary["Palette {0}"] = "调色板 {0}";
			textTranlateDictionary["Color {0}"] = "颜色 {0}";
			textTranlateDictionary["(R,G,B) = ({0},{1},{2})"] = "(R,G,B) = ({0},{1},{2})";
			textTranlateDictionary["Tile #{0} @{1}:{2:x4}"] = "块 #{0} @{1}:{2:x4}";
			textTranlateDictionary["Tile #{0} @{1:x4}"] = "块 #{0} @{1:x4}";
			textTranlateDictionary["{0} Map ({1},{2}) @{3:x4}"] = "{0} 映射 ({1},{2}) @{3:x4}";
			textTranlateDictionary["  Tile #{0} @{1:x4}"] = "  块 #{0} @{1:x4}";
			textTranlateDictionary["  Tile #{0} @{1}:{2:x4}"] = "  块 #{0} @{1}:{2:x4}";
			textTranlateDictionary["  Palette {0}"] = "  调色板 {0}";
			textTranlateDictionary["  Flags {0}{1}{2}"] = "  标志 {0}{1}{2}";
			textTranlateDictionary["Sprite #{0} @{1:x4}"] = "精灵 #{0} @{1:x4}";
			textTranlateDictionary["  (x,y) = ({0},{1})"] = "  (x,y) = ({0},{1})";
			textTranlateDictionary["Details - Background"] = "详情 - 背景";
			textTranlateDictionary["Details - Window"] = "详情 - 窗口";
			textTranlateDictionary["Details - Tiles"] = "详情 - 块";
			textTranlateDictionary["Details - Palette"] = "详情 - 调色板";
			textTranlateDictionary["Details - Sprite"] = "详情 - 精灵";
			textTranlateDictionary["Details - Objects"] = "详情 - 对象";
			textTranlateDictionary["CTRL+C copies the pane under the mouse."] = "CTRL+C 复制鼠标下方的面板。";

			// tools/GB/GBPrinterView.cs
			textTranlateDictionary["Printer Viewer"] = "打印机查看器";

			// tools/GameShark.cs
			textTranlateDictionary["Cheat Code Converter"] = "作弊码转换器";
			textTranlateDictionary["Input Error"] = "输入错误";
			textTranlateDictionary["Are you sure you want to clear this form?"] = "确定要清空此表单吗？";
			textTranlateDictionary["Clear Form"] = "清空表单";

			// tools/Genesis/VDPViewer.cs
			textTranlateDictionary["VDP Viewer"] = "VDP 查看器";

			// tools/HexEditor/HexEditor.cs
			textTranlateDictionary[".tsv --> Clipboard"] = ".tsv --> 剪贴板";
			textTranlateDictionary["Hex Editor"] = "十六进制编辑器";
			textTranlateDictionary["{0} {1}{2}  -  {3} addresses"] = "{0} {1}{2}  -  {3} 个地址";
			textTranlateDictionary["  Typing: ({0})"] = "  键入：({0})";
			textTranlateDictionary[" - Editing Address 0x"] = " - 正在编辑地址 0x";
			textTranlateDictionary[" (Selected 0x{0:X})"] = "(已选择 0x{0:X})";
			textTranlateDictionary["Save as ROM..."] = "保存为 ROM";
			textTranlateDictionary["Save as binary..."] = "保存为二进制";
			textTranlateDictionary["This Memory Domain can't be Poked; so importing can't work"] = "此内存域无法被写入；因此无法导入";
			textTranlateDictionary["Un&freeze Address"] = "解冻地址(&F)";
			textTranlateDictionary["&Freeze Address"] = "冻结地址(&F)";
			textTranlateDictionary["Go to Address"] = "转到地址";
			textTranlateDictionary["Enter a hexadecimal value"] = "输入一个十六进制值";
			textTranlateDictionary["Un&freeze"] = "解冻(&F)";

			// tools/Lua/Libraries/ConsoleLuaLibrary.cs
			textTranlateDictionary["console"] = "控制台";

			// tools/Lua/Libraries/FormsLuaLibrary.cs
			textTranlateDictionary["IDialogParent must implement IWin32Window"] = "IDialogParent 必须实现 IWin32Window";
			textTranlateDictionary["no property with the identifier {0}"] = "没有标识符为 {0} 的属性";

			// tools/Lua/Libraries/TAStudioLuaLibrary.cs
			textTranlateDictionary["tastudio.setplayback() is not allowed during input/memory callbacks"] = "在输入/内存回调期间不允许调用 tastudio.setplayback()";
			textTranlateDictionary["tastudio.applyinputchanges() is not allowed during input/memory callbacks"] = "在输入/内存回调期间不允许调用 tastudio.applyinputchanges()";
			textTranlateDictionary["tastudio.loadbranch() is not allowed during input/memory callbacks"] = "在输入/内存回调期间不允许调用 tastudio.loadbranch()";

			// tools/Lua/LuaCanvas.cs
			textTranlateDictionary["LuaCanvas"] = "Lua 画布";

			// tools/Lua/LuaConsole.cs
			textTranlateDictionary["Copy All Logged Messages to Terminal/stdout"] = "将所有记录的消息复制到终端/stdout";
			textTranlateDictionary["Script"] = "脚本";
			textTranlateDictionary["Path"] = "路径";
			textTranlateDictionary["Lua Console"] = "Lua 控制台";
			textTranlateDictionary["{0} script ({1} active, {2} paused)"] = "{0} 个脚本（{1} 个活动，{2} 个暂停）";
			textTranlateDictionary["{0} scripts"] = "{0} 个脚本";
			textTranlateDictionary["{0} scripts ({1} active, {2} paused)"] = "{0} 个脚本（{1} 个活动，{2} 个暂停）";
			textTranlateDictionary["Lua session could not be saved to {0}"] = "无法将 Lua 会话保存到 {0}";
			textTranlateDictionary["Closing with Unsaved Changes"] = "存在未保存的更改，即将关闭";
			textTranlateDictionary["Save {0} session?"] = "是否保存 {0} 会话？";
			textTranlateDictionary["Failed to save Lua session."] = "保存 Lua 会话失败。";
			textTranlateDictionary["Failed to save {0}"] = "保存 {0} 失败";
			textTranlateDictionary["You are about to overwrite an existing Lua script.\n"] = "您即将覆盖一个现有的 Lua 脚本。\n";
			textTranlateDictionary["Keep in mind the \"New Lua Script\" option is for creating a brand new Lua script, not for opening Lua scripts.\n"] = "请记住，\"新建 Lua 脚本\"选项是用于创建全新的 Lua 脚本，而不是用于打开 Lua 脚本。\n";
			textTranlateDictionary["This warning will not appear again! (the file manager would be warning you about an overwrite anyways)\n"] = "此警告不会再次出现！(文件管理器无论如何都会警告您有关覆盖的问题)\n";
			textTranlateDictionary["Proceed with overwrite?"] = "继续覆盖？";
			textTranlateDictionary["Overwrite"] = "覆盖";
			textTranlateDictionary["Sublime Text 2 (installed)"] = "Sublime Text 2（已安装）";
			textTranlateDictionary["Sublime Text 2 (detected)"] = "Sublime Text 2（已发现）";
			textTranlateDictionary["Sublime Text 2"] = "Sublime Text 2";
			textTranlateDictionary["Notepad++ (installed)"] = "Notepad++（已安装）";
			textTranlateDictionary["Notepad++ (detected)"] = "Notepad++（已发现）";
			textTranlateDictionary["Notepad++"] = "Notepad++";

			// tools/Lua/LuaPictureBox.cs
			textTranlateDictionary["{0}: both {1} must be set to have any effect"] = "{0}：必须同时设置 {1} 才会生效";

			// tools/Macros/MacroInput.cs
			textTranlateDictionary["Macro Input"] = "宏输入";
			textTranlateDictionary["You have unsaved macro(s). Do you wish to save them?"] = "您有未保存的宏。是否要保存它们？";
			textTranlateDictionary["Save?"] = "保存？";
			textTranlateDictionary["Start and end frames must be inside the movie."] = "起始帧和结束帧必须在影片范围内。";
			textTranlateDictionary["Please select a zone first."] = "请先选择一个区域。";

			// tools/MultiDiskBundler/MultiDiskBundler.cs
			textTranlateDictionary["Multi-disk Bundler"] = "多碟打包器";
			textTranlateDictionary["File already exists, overwrite?"] = "文件已存在，是否覆盖？";
			textTranlateDictionary["File exists"] = "文件已存在";
			textTranlateDictionary["Xml Filename can not be blank"] = "XML 文件名不能为空";
			textTranlateDictionary["Rom Names can not be blank"] = "ROM 名称不能为空";
			textTranlateDictionary["System Id can not be blank"] = "系统 ID 不能为空";

			// tools/MultiDiskBundler/MultiDiskFileSelector.cs
			textTranlateDictionary["Using archives with PSX, PCFX or SATURN is not currently recommended/supported."] = "目前不建议/不支持在 PSX、PCFX 或 SATURN 上使用归档。";

			// tools/NES/BarcodeEntry.cs
			textTranlateDictionary["Barcode Entry"] = "条码输入";
			textTranlateDictionary["Invalid: {0}"] = "无效：{0}";

			// tools/NES/NESMusicRipper.cs
			textTranlateDictionary["Music Ripper"] = "音乐提取器";
			textTranlateDictionary["{0} Rows"] = "{0} 行";
			textTranlateDictionary["Start"] = "开始"; // 出现重复
			textTranlateDictionary["Stop"] = "停止";

			// tools/NES/NESNameTableViewer.cs
			textTranlateDictionary["Nametable Viewer"] = "命名表查看器";
			textTranlateDictionary["{0:X4}"] = "{0:X4}";
			textTranlateDictionary["{0:X2}"] = "{0:X2}";

			// tools/NES/NESPPU.cs
			textTranlateDictionary["PPU Viewer"] = "PPU 查看器";
			textTranlateDictionary["Details"] = "详情";
			textTranlateDictionary["Palette: {0}"] = "调色板：{0}";
			textTranlateDictionary["Use CTRL+C to copy the pane under the mouse to the clipboard."] = "使用 CTRL+C 将鼠标下方的面板复制到剪贴板。";
			textTranlateDictionary["Details - Sprites"] = "详情 - 精灵";
			textTranlateDictionary["Number: {0:X2}"] = "编号：{0:X2}";
			textTranlateDictionary["Tile: {0:X2}"] = "块：{0:X2}";
			textTranlateDictionary["Color: {0}"] = "颜色：{0}";
			textTranlateDictionary["Details - Palettes"] = "详情 - 调色板";
			textTranlateDictionary["Address: 0x{0:X4}"] = "地址：0x{0:X4}";
			textTranlateDictionary["Color: 0x{0:X2}"] = "颜色：0x{0:X2}";
			textTranlateDictionary["Offset: {0}"] = "偏移：{0}";
			textTranlateDictionary["Details - Patterns"] = "详情 - 图案";
			textTranlateDictionary["Usage: "] = "Usage: ";
			textTranlateDictionary["Address: {0:X4}"] = "地址：{0:X4}";
			textTranlateDictionary["Table {0}"] = "表 {0}";
			textTranlateDictionary["Tile {0:X2}"] = "块 {0:X2}";

			// tools/PCE/PCEBGViewer.cs
			textTranlateDictionary["Background Viewer"] = "背景查看器";

			// tools/PCE/PCESoundDebugger.cs
			textTranlateDictionary["Sound Debugger"] = "声音调试器";
			textTranlateDictionary["(disabled)"] = "(已禁用)";
			textTranlateDictionary["(noise)"] = "(噪声)";

			// tools/PCE/PCETileViewer.cs
			textTranlateDictionary["Tile Viewer"] = "块查看器";

			// tools/SMS/VDPViewer.cs

			// tools/SNES/SNESGraphicsDebugger.cs
			textTranlateDictionary["Graphics Debugger"] = "图形调试器";
			textTranlateDictionary["Mode 1 BG3 priority toggle bit of $2105 is SET"] = "$2105 的 Mode 1 BG3 优先级切换位为 SET";
			textTranlateDictionary["Mode 1 BG3 priority toggle bit of $2105 is CLEAR"] = "$2105 的 Mode 1 BG3 优先级切换位为 CLEAR";
			textTranlateDictionary["Freeze - Map Entry"] = "冻结 - 映射条目";
			textTranlateDictionary["Freeze - Color"] = "冻结 - 颜色";
			textTranlateDictionary["Freeze - Tile"] = "冻结 - 块";
			textTranlateDictionary["Freeze - OBJ"] = "冻结 - OBJ";

			// tools/TAStudio/BookmarksBranchesBox.cs
			textTranlateDictionary["Add Branch ({0})"] = "添加分支 ({0})";
			textTranlateDictionary["Add Branch"] = "添加分支";
			textTranlateDictionary["Frame"] = "帧";
			textTranlateDictionary["UserText"] = "用户文本";
			textTranlateDictionary["Undo Branch Load"] = "撤销分支加载";
			textTranlateDictionary["Undo Branch Update"] = "撤销分支更新";
			textTranlateDictionary["Undo Branch Text Edit"] = "撤销分支文本编辑";
			textTranlateDictionary["Undo Branch Removal"] = "撤销分支移除";
			textTranlateDictionary["Text for branch {0}"] = "分支 {0} 的文本";
			textTranlateDictionary["Enter a message"] = "输入一条消息";

			// tools/TAStudio/MarkerControl.cs
			textTranlateDictionary["Add Marker to Emulated Frame ({0})"] = "向模拟帧添加标记 ({0})";
			textTranlateDictionary["Add Marker with Text to Emulated Frame ({0} {1})"] = "向模拟帧添加带文本的标记 ({0} {1})";
			textTranlateDictionary["Remove Marker ({0} on marker's frame)"] = "移除标记(标记帧上的 {0})";
			textTranlateDictionary["State"] = "进度";
			textTranlateDictionary["Marker for frame {0}"] = "帧 {0} 的标记";
			textTranlateDictionary["Enter a frame number"] = "输入一个帧编号";

			// tools/TAStudio/PlaybackBox.cs
			textTranlateDictionary["Hotkey: {0}"] = "快捷键：{0}";
			textTranlateDictionary["unbound"] = "未绑定";
			textTranlateDictionary["Hotkey: {0} or {1}"] = "快捷键：{0} 或 {1}";
			textTranlateDictionary[" or "] = " 或 ";
			textTranlateDictionary["\nseek to next marker"] = "\n定位到下一个标记";
			textTranlateDictionary["\nseek to previous marker"] = "\n定位到上一个标记";
			textTranlateDictionary["\nframe advance"] = "\n帧步进";
			textTranlateDictionary["\ngo back 1 step (size of step is configurable in settings)"] = "\n后退 1 步（步长可在设置中配置）";
			textTranlateDictionary["\nWheel is always 1 frame per tick."] = "\n滚轮始终为每格 1 帧。";
			textTranlateDictionary["\ntoggle pause"] = "\n切换暂停";
			textTranlateDictionary["\nWhen enabled, the current emulator frame will be"] = "\n启用后，当前模拟器帧将";
			textTranlateDictionary["\nmade visible every time the current frame changes."] = "\n在当前帧每次变化时显示。";
			textTranlateDictionary["\nWhen enabled and you edit a frame before the current emulator frame,"] = "\n启用后，当您编辑当前模拟器帧之前的帧时，";
			textTranlateDictionary["\nTAStudio will automatically seek back to said emulator frame."] = "\nTAStudio 将自动定位回该模拟器帧。";
			textTranlateDictionary["\nWhen enabled, TAStudio will run the emulator as fast as possible during seeks."] = "\n启用后，TAStudio 在定位期间将尽可能快地运行模拟器。";
			textTranlateDictionary["\nWhen enabled, you can record inputs while unpaused or when frame advancing."] = "\n启用后，您可以在未暂停或帧步进时记录输入。";

			// tools/TAStudio/TAStudio.IControlMainForm.cs
			textTranlateDictionary["This should never be called"] = "此方法永远不应被调用";

			// tools/TAStudio/TAStudio.IToolForm.cs
			textTranlateDictionary["Save {0} project?"] = "是否保存 {0} 项目？";

			// tools/TAStudio/TAStudio.ListView.cs
			textTranlateDictionary["Encountered unrecoverable error while drawing the input roll.\n"] = "绘制输入卷帘时遇到无法恢复的错误。\n";
			textTranlateDictionary["The current movie will be closed without saving.\n"] = "当前影片将在不保存的情况下关闭。\n";
			textTranlateDictionary["The exception was:\n\n{0}"] = "异常为：\n\n{0}";
			textTranlateDictionary["Failed to draw input roll"] = "绘制输入卷帘失败";

			// tools/TAStudio/TAStudio.MenuItems.cs
			textTranlateDictionary["Failed to create movie."] = "创建影片失败。";
			textTranlateDictionary["No SaveRam"] = "没有保存的 RAM";
			textTranlateDictionary["Convert movie"] = "转换影片";
			textTranlateDictionary["This is a regular movie, a new project must be created from it to use in TAStudio\nProceed?"] = "这是一个普通影片，必须在 TAStudio 中从中创建新项目才能使用\n是否继续？";
			textTranlateDictionary["Movie load error"] = "影片加载错误";
			textTranlateDictionary["This is not a BizHawk movie!"] = "这不是 BizHawk 影片！";
			textTranlateDictionary["Failed to save backup."] = "保存备份失败。";
			textTranlateDictionary["Failed to save macro.\n{0}\n{1}"] = "保存宏失败。\n{0}\n{1}";
			textTranlateDictionary["This core requires emulation to be on the last frame when writing the movie, otherwise movie length will appear incorrect."] = "写入影片时，此核心要求模拟必须位于最后一帧，否则影片长度会显示不正确。";
			textTranlateDictionary["Exporting to .bk2..."] = "正在导出为 .bk2...";
			textTranlateDictionary["Failed to save .bk2. {0}\nTry again?"] = "保存 .bk2 失败。{0}\n是否重试？";
			textTranlateDictionary["{0} exported."] = "已导出 {0}。";
			textTranlateDictionary["bk2 export cancelled."] = "bk2 导出已取消。";
			textTranlateDictionary["Go to Frame"] = "转到帧";
			textTranlateDictionary["Jump/Seek to frame index:"] = "跳转/定位到帧索引：";
			textTranlateDictionary["Clone # Times"] = "克隆多次";
			textTranlateDictionary["Insert times to clone:"] = "输入要克隆的次数：";
			textTranlateDictionary["Are you sure you want to add more than 50 markers?"] = "确定要添加超过 50 个标记吗？";
			textTranlateDictionary["Add markers"] = "添加标记";
			textTranlateDictionary["The emulator is not deterministic. It might fail even if the difference isn't enough to cause a desync.\nContinue with check?"] = "模拟器不是确定性的。即使差异不足以导致失同步，也可能失败。\n是否继续检查？";
			textTranlateDictionary["Not Deterministic"] = "非确定性";
			textTranlateDictionary["Bad data between frames {0} and {1}. Save the relevant state (raw data)?"] = "帧 {0} 和 {1} 之间的数据有误。是否保存相关进度(原始数据)？";
			textTranlateDictionary["Integrity Failed!"] = "完整性检查失败！";
			textTranlateDictionary["Integrity Check passed"] = "完整性检查通过";
			textTranlateDictionary["Current roll: #{0}"] = "当前行：#{0}";
			textTranlateDictionary["Keys ({0} - {1})"] = "按键 ({0} - {1})";
			textTranlateDictionary["Change Peripherals..."] = "更改外设...";
			textTranlateDictionary["Changing peripherals/players is done in the core's sync settings (if the core supports different peripherals)."] = "更改外设/玩家是在核心的同步设置中完成的(如果核心支持不同的外设)。";
			textTranlateDictionary["\nAs these can't be changed in the middle of a movie, you'll have to close TAStudio, change the settings, and create a new TAStudio project."] = "\n由于这些无法在影片中途更改，您必须关闭 TAStudio 更改设置，然后创建一个新的 TAStudio 项目。";
			textTranlateDictionary["Attempt to keep old states?"] = "尝试保留旧进度？";
			textTranlateDictionary["Keep old states?"] = "保留旧进度？";

			// tools/TAStudio/TAStudio.Navigation.cs
			textTranlateDictionary["Seeking..."] = "正在定位...";

			// tools/TAStudio/TAStudio.cs
			textTranlateDictionary["Would you like to save the current movie before closing it?"] = "是否要在关闭当前影片之前保存它？";
			textTranlateDictionary["The current movie has unsaved changes. Would you like to save before closing it?"] = "当前影片有未保存的更改。是否要在关闭之前保存？";
			textTranlateDictionary["TAStudio will create a new project file from the current movie.\n\n"] = "TAStudio 将从当前影片创建一个新项目文件。\n\n";
			textTranlateDictionary["Failed to auto-save. {0}\n{1}\n\nTry again?"] = "自动保存失败。{0}\n{1}\n\n是否重试？";
			textTranlateDictionary["Frame#"] = "帧#";
			textTranlateDictionary["how is TAStudio open with no game loaded? please report this including as much detail as possible"] = "在没有加载游戏的情况下怎么会打开 TAStudio？请尽可能详细地报告此问题";
			textTranlateDictionary["Failed to load the movie's client settings. Movie is still usable."] = "加载影片的客户端设置失败。影片仍可使用。";
			textTranlateDictionary["{0}\n{1}\n{2}"] = "{0}\n{1}\n{2}";
			textTranlateDictionary["Saving backup..."] = "正在保存备份...";
			textTranlateDictionary["Saving..."] = "正在保存...";
			textTranlateDictionary["Backup .{0} saved to \"Movie backups\" path."] = "备份 .{0} 已保存到\"影片备份\"路径。";
			textTranlateDictionary["File saved."] = "文件已保存。";
			textTranlateDictionary["Failed to save."] = "保存失败。";
			textTranlateDictionary["TAStudio"] = "TAStudio";
			textTranlateDictionary["TAStudio - {0}*"] = "TAStudio - {0}*";
			textTranlateDictionary["TAStudio - {0}"] = "TAStudio - {0}";
			textTranlateDictionary["Selected: {0} {1}, States: {2}"] = "已选择：{0} {1}，进度：{2}";
			textTranlateDictionary["frame"] = "帧";
			textTranlateDictionary["frames"] = "帧";
			textTranlateDictionary[", Clipboard: {0} {1}"] = "，剪贴板：{0} {1}";
			textTranlateDictionary["Invalid mnemonic string: {0}"] = "无效的助记符字符串：{0}";
			textTranlateDictionary["Paste Input failed!"] = "粘贴输入失败！";
			textTranlateDictionary["Can't build mnemonic map with empty mnemonics cache"] = "助记符缓存为空时无法构建助记符映射";

			// tools/TAStudio/TAStudioColorSettingsForm.cs
			textTranlateDictionary["Cancel"] = "取消";
			textTranlateDictionary["Defaults"] = "默认值";
			textTranlateDictionary["Edit TAStudio Colors"] = "编辑 TAStudio 颜色";

			// tools/TAStudio/TAStudioSettingsForm.cs
			textTranlateDictionary["You have enabled 'bind markers to input' and disabled 'allow editing hidden columns'. This combination is not recommended, and may result in your markers being moved in unexpected ways. Continue?"] = "您已启用\"将标记绑定到输入\"并禁用\"允许编辑隐藏列\"。不建议使用此组合，可能会导致标记以意外方式移动。是否继续？";

			// tools/TI83/TI83KeyPad.cs
			textTranlateDictionary["TI-83 Virtual KeyPad"] = "TI-83 虚拟键盘";

			// tools/ToolManager.cs
			textTranlateDictionary["Type {0} does not implement {1}."] = "类型 {0} 未实现 {1}。";
			textTranlateDictionary["&Close"] = "关闭(&C)";
			textTranlateDictionary["{0} must have menu to bind to! (need {1} or other {2} w/ menu labelled \"Settings\")"] = "{0} 必须有一个可绑定到的菜单！（需要 {1} 或其他带有名为\"设置\"菜单的 {2}）";
			textTranlateDictionary["Save Window &Position"] = "保存窗口位置(&P)";
			textTranlateDictionary["Stay on &Top"] = "保持在顶部(&T)";
			textTranlateDictionary["&Float from Parent"] = "从父窗口浮动(&F)";
			textTranlateDictionary["&Autoload with EmuHawk"] = "随 EmuHawk 自动加载(&A)";
			textTranlateDictionary["Restore &Defaults"] = "恢复默认(&D)";
			textTranlateDictionary["Confirm loading"] = "确认加载";
			textTranlateDictionary["Trust this external tool to run on your device?"] = "信任此外部工具在您的设备上运行？";
			textTranlateDictionary["\nIf you're not 100% sure of what the tool will do, choose \"No\"."] = "\n如果您不完全确定该工具会做什么，请选择\"否\"。";
			textTranlateDictionary["It seems that the object CustomMainForm does not implement {0}. Please review the code."] = "对象 CustomMainForm 似乎未实现 {0}。请检查代码。";
			textTranlateDictionary["No, no, no. Wrong Way !"] = "不，不，不。走错路了！";
			textTranlateDictionary["It seems that the object CustomMainForm does not have a public default constructor. Please review the code."] = "对象 CustomMainForm 似乎没有公共默认构造函数。请检查代码。";
			textTranlateDictionary["It seems that the object CustomMainForm does not exists. Please review the code."] = "对象 CustomMainForm 似乎不存在。请检查代码。";

			// tools/TraceLogger.cs
			textTranlateDictionary["Trace Logger"] = "跟踪记录器";
			textTranlateDictionary["Trace log - logging to file..."] = "跟踪日志 - 正在记录到文件...";
			textTranlateDictionary["Trace log - logging - {0} instructions"] = "跟踪日志 - 记录中 - {0} 条指令";
			textTranlateDictionary["Trace log - logging..."] = "跟踪日志 - 记录中...";
			textTranlateDictionary["Trace log - {0} instructions"] = "跟踪日志 - {0} 条指令";
			textTranlateDictionary["Trace log"] = "跟踪日志";
			textTranlateDictionary["Max lines to display in the window"] = "窗口中显示的最大行数";
			textTranlateDictionary["Log file segment size in megabytes\nSetting 0 disables segmentation"] = "日志文件分片大小（兆字节）\n设置为 0 可禁用分片";
			textTranlateDictionary["Stop &logging"] = "停止记录(&L)";
			textTranlateDictionary["Start &logging"] = "开始记录(&L)";

			// tools/VirtualPads/VirtualpadsTool.cs
			textTranlateDictionary["Virtual Pads"] = "虚拟手柄";
			textTranlateDictionary["Schema warning: Schema entry '{0}':'{1}' will not correspond to any control in definition '{2}'"] = "架构警告：架构条目 '{0}':'{1}' 将不对应于定义 '{2}' 中的任何控件";
			textTranlateDictionary["Dev Warning"] = "开发者警告";

			// tools/Watch/RamPoke.cs
			textTranlateDictionary["RAM Poke does not support mixed types"] = "RAM 写入不支持混合类型";
			textTranlateDictionary["Unsupported Options"] = "不支持的选项";
			textTranlateDictionary["Big Endian"] = "大端";
			textTranlateDictionary["Little Endian"] = "小端";
			textTranlateDictionary["RAM Poke - {0}"] = "RAM 写入 - {0}";
			textTranlateDictionary["An error occured when writing Value."] = "写入值时发生错误。";

			// tools/Watch/RamSearch.cs
			textTranlateDictionary["RAM Search"] = "RAM 搜索";
			textTranlateDictionary["Search restarted"] = "搜索已重新开始";
			textTranlateDictionary["{0} {1} removed"] = "已移除 {0} {1}";
			textTranlateDictionary["{0:n0} addresses"] = "{0:n0} 个地址";
			textTranlateDictionary["Large domain, switching to fast mode"] = "域过大，切换到快速模式";
			textTranlateDictionary["{0} {1} restored"] = "已恢复 {0} {1}";
			textTranlateDictionary["&Unfreeze Address"] = "解冻地址(&F)";

			// tools/Watch/RamWatch.cs
			textTranlateDictionary["RAM Watch"] = "RAM 监视";
			textTranlateDictionary["Purge Duplicate Watches"] = "清除重复的监视项";
			textTranlateDictionary["Purge duplicates?"] = "清除重复项？";
			textTranlateDictionary["This will go through each watch starting from the top,\n"] = "这将从顶部开始遍历每一个监视项，\n";
			textTranlateDictionary["removing it if its (domain & addr & size) has been seen before.\n"] = "如果其(域 & 地址 & 大小)之前已经出现过，则将其移除。\n";
			textTranlateDictionary["Neither the endianness nor display type are considered.\n"] = "既不考虑字节序也不考虑显示类型。\n";
			textTranlateDictionary["Overlapping watches also aren't considered."] = "重叠的监视项也不予考虑。";
			textTranlateDictionary["Save watch file?"] = "是否保存监视文件？";
			textTranlateDictionary["Failed to save watch list."] = "保存监视列表失败。";
			textTranlateDictionary["Edit Separator"] = "编辑分隔符";
			textTranlateDictionary["Separator Text:"] = "分隔符文本：";
			textTranlateDictionary[" watch"] = " 个监视";
			textTranlateDictionary[" watches"] = " 个监视";
			textTranlateDictionary["Prev"] = "前值";
			textTranlateDictionary["Changes"] = "更改";
			textTranlateDictionary["Diff"] = "差异";
			textTranlateDictionary["Type"] = "类型";
			textTranlateDictionary["Notes"] = "注释";

			// tools/Watch/WatchEditor.cs
			textTranlateDictionary["Mem Domain:"] = "内存域：";
			textTranlateDictionary["Address:"] = "地址：";
			textTranlateDictionary["Size:"] = "大小：";
			textTranlateDictionary["Display Type:"] = "显示类型：";
			textTranlateDictionary["Notes:"] = "注释：";
			textTranlateDictionary["New Watch"] = "新建监视";
			textTranlateDictionary["Edit {0}"] = "编辑 {0}";
			textTranlateDictionary["Duplicate Watch"] = "克隆监视";

			// 快捷键
			textTranlateDictionary["General"] = "通用";
			textTranlateDictionary["Frame Advance"] = "单帧步进";
			textTranlateDictionary["Escape"] = "退出";
			textTranlateDictionary["Rewind"] = "回退";
			textTranlateDictionary["Pause"] = "暂停";
			textTranlateDictionary["Fast Forward"] = "快进";
			textTranlateDictionary["Turbo"] = "涡轮加速";
			textTranlateDictionary["Toggle Throttle"] = "切换限速";
			textTranlateDictionary["Soft Reset"] = "软重启";
			textTranlateDictionary["Hard Reset"] = "硬重启";
			textTranlateDictionary["Autofire"] = "连发";
			textTranlateDictionary["Clear Autohold"] = "清除自动按住";
			textTranlateDictionary["Screenshot"] = "截图";
			textTranlateDictionary["Full Screen"] = "全屏";
			textTranlateDictionary["Open ROM"] = "打开ROM";
			textTranlateDictionary["Close ROM"] = "关闭ROM";
			textTranlateDictionary["Load Last ROM"] = "加载上一个ROM";
			textTranlateDictionary["Flush SaveRAM"] = "刷新存档内存";
			textTranlateDictionary["Display FPS"] = "显示帧率";
			textTranlateDictionary["Toggle BG Input"] = "切换后台输入";
			textTranlateDictionary["Toggle Menu"] = "切换菜单";
			textTranlateDictionary["Volume Up"] = "音量增大";
			textTranlateDictionary["Volume Down"] = "音量减小";
			textTranlateDictionary["Record A/V"] = "录制音视频";
			textTranlateDictionary["Stop A/V"] = "停止音视频录制";
			textTranlateDictionary["Larger Window"] = "放大窗口";
			textTranlateDictionary["Smaller Window"] = "缩小窗口";
			textTranlateDictionary["Increase Speed"] = "提升速度";
			textTranlateDictionary["Decrease Speed"] = "降低速度";
			textTranlateDictionary["Reset Speed"] = "重置速度";
			textTranlateDictionary["Reboot Core"] = "重启模拟器核心";
			textTranlateDictionary["Toggle Sound"] = "切换声音开关";
			textTranlateDictionary["Exit Program"] = "退出程序";
			textTranlateDictionary["Screen Raw to Clipboard"] = "原始画面复制到剪贴板";
			textTranlateDictionary["Screen Client to Clipboard"] = "窗口画面复制到剪贴板";
			textTranlateDictionary["Toggle Skip Lag Frame"] = "切换跳延迟帧";
			textTranlateDictionary["Toggle Key Priority"] = "切换按键优先级";
			textTranlateDictionary["Frame Inch"] = "帧微步进";
			textTranlateDictionary["Toggle Messages"] = "切换消息提示";
			textTranlateDictionary["Toggle Display Nothing"] = "切换无画面输出";
			textTranlateDictionary["Accept Background Input"] = "允许后台输入";
			textTranlateDictionary["Capture Mouse"] = "捕获鼠标";
			textTranlateDictionary["Toggle Stay on Top"] = "切换窗口置顶";
			textTranlateDictionary["Save States"] = "保存进度";
			textTranlateDictionary["Save State 1"] = "保存进度 1";
			textTranlateDictionary["Save State 2"] = "保存进度 2";
			textTranlateDictionary["Save State 3"] = "保存进度 3";
			textTranlateDictionary["Save State 4"] = "保存进度 4";
			textTranlateDictionary["Save State 5"] = "保存进度 5";
			textTranlateDictionary["Save State 6"] = "保存进度 6";
			textTranlateDictionary["Save State 7"] = "保存进度 7";
			textTranlateDictionary["Save State 8"] = "保存进度 8";
			textTranlateDictionary["Save State 9"] = "保存进度 9";
			textTranlateDictionary["Save State 10"] = "保存进度 10";
			textTranlateDictionary["Load State 1"] = "加载进度 1";
			textTranlateDictionary["Load State 2"] = "加载进度 2";
			textTranlateDictionary["Load State 3"] = "加载进度 3";
			textTranlateDictionary["Load State 4"] = "加载进度 4";
			textTranlateDictionary["Load State 5"] = "加载进度 5";
			textTranlateDictionary["Load State 6"] = "加载进度 6";
			textTranlateDictionary["Load State 7"] = "加载进度 7";
			textTranlateDictionary["Load State 8"] = "加载进度 8";
			textTranlateDictionary["Load State 9"] = "加载进度 9";
			textTranlateDictionary["Load State 10"] = "加载进度 10";
			textTranlateDictionary["Select State 1"] = "选择进度槽 1";
			textTranlateDictionary["Select State 2"] = "选择进度槽 2";
			textTranlateDictionary["Select State 3"] = "选择进度槽 3";
			textTranlateDictionary["Select State 4"] = "选择进度槽 4";
			textTranlateDictionary["Select State 5"] = "选择进度槽 5";
			textTranlateDictionary["Select State 6"] = "选择进度槽 6";
			textTranlateDictionary["Select State 7"] = "选择进度槽 7";
			textTranlateDictionary["Select State 8"] = "选择进度槽 8";
			textTranlateDictionary["Select State 9"] = "选择进度槽 9";
			textTranlateDictionary["Select State 10"] = "选择进度槽 10";
			textTranlateDictionary["Quick Load"] = "快速存档";
			textTranlateDictionary["Quick Save"] = "快速读档";
			textTranlateDictionary["Save Named State"] = "进度另存为";
			textTranlateDictionary["Load Named State"] = "加载指定进度";
			textTranlateDictionary["Previous Slot"] = "前一进度槽";
			textTranlateDictionary["Next Slot"] = "后一进度槽";
			textTranlateDictionary["Movie"] = "影片";
			textTranlateDictionary["Toggle read-only"] = "切换只读模式";
			textTranlateDictionary["Play Movie"] = "播放影片";
			textTranlateDictionary["Stop Movie"] = "停止影片";
			textTranlateDictionary["Play from beginning"] = "从头播放";
			textTranlateDictionary["Save Movie"] = "保存影片";
			textTranlateDictionary["Tools"] = "工具";
			textTranlateDictionary["ToolBox"] = "工具箱";
			textTranlateDictionary["Virtual Pad"] = "虚拟手柄";
			textTranlateDictionary["Toggle All Cheats"] = "切换全部金手指";
			textTranlateDictionary["Toggle Last Lua Script"] = "切换上一个Lua脚本";
			textTranlateDictionary["New Search"] = "新建搜索";
			textTranlateDictionary["Do Search"] = "执行搜索";
			textTranlateDictionary["Previous Compare To"] = "上一个对比目标";
			textTranlateDictionary["Next Compare To"] = "下一个对比目标";
			textTranlateDictionary["Previous Operator"] = "上一运算符";
			textTranlateDictionary["Next Operator"] = "下一运算符";
			textTranlateDictionary["Delete Branch"] = "删除分支";
			textTranlateDictionary["Show Cursor"] = "显示光标";
			textTranlateDictionary["Select Current Frame"] = "选中当前帧";
			textTranlateDictionary["Seek To Selected Frame"] = "跳转至选中帧";
			textTranlateDictionary["Seek To..."] = "跳转至";
			textTranlateDictionary["Toggle Follow Cursor"] = "切换跟随光标";
			textTranlateDictionary["Toggle Auto‑Restore"] = "切换自动恢复";
			textTranlateDictionary["Seek To Green Arrow"] = "跳转至绿色箭头位置";
			textTranlateDictionary["Toggle Turbo Seek"] = "切换高速跳转";
			textTranlateDictionary["Undo"] = "撤销";
			textTranlateDictionary["Redo"] = "重做";
			textTranlateDictionary["Seek To Prev Marker"] = "跳转到上一标记点";
			textTranlateDictionary["Seek To Next Marker"] = "跳转到下一标记点";
			textTranlateDictionary["Toggle Auto-Restore"] = "切换自动恢复";
			textTranlateDictionary["Cancel Seek"] = "取消跳转";
			textTranlateDictionary["Set Marker"] = "设置标记点";
			textTranlateDictionary["Delete Marker"] = "删除标记点";
			textTranlateDictionary["Sel. bet. Markers"] = "选中标记点之间";
			textTranlateDictionary["Select All"] = "全选";
			textTranlateDictionary["Reselect Clip."] = "重新选择片段";
			textTranlateDictionary["Clear Frames"] = "清空帧";
			textTranlateDictionary["Delete Frames"] = "删除帧";
			textTranlateDictionary["Insert Frame"] = "插入帧";
			textTranlateDictionary["Insert # Frames"] = "插入指定数量帧";
			textTranlateDictionary["Clone Frames"] = "克隆帧";
			textTranlateDictionary["Paste Insert"] = "粘贴并插入";
			textTranlateDictionary["Analog Increment"] = "模拟量增加";
			textTranlateDictionary["Analog Decrement"] = "模拟量减少";
			textTranlateDictionary["Analog Incr. by 10"] = "模拟量+10";
			textTranlateDictionary["Analog Decr. by 10"] = "模拟量‑10";
			textTranlateDictionary["Analog Maximum"] = "模拟量拉满";
			textTranlateDictionary["Analog Minimum"] = "模拟量置最小";
			textTranlateDictionary["SNES"] = "SNES";
			textTranlateDictionary["Toggle BG 1"] = "切换背景图层1";
			textTranlateDictionary["Toggle BG 2"] = "切换背景图层2";
			textTranlateDictionary["Toggle BG 3"] = "切换背景图层3";
			textTranlateDictionary["Toggle BG 4"] = "切换背景图层4";
			textTranlateDictionary["Toggle OBJ 1"] = "切换精灵图层1";
			textTranlateDictionary["Toggle OBJ 2"] = "切换精灵图层2";
			textTranlateDictionary["Toggle OBJ 3"] = "切换精灵图层3";
			textTranlateDictionary["Toggle OBJ 4"] = "切换精灵图层4";
			textTranlateDictionary["GB"] = "GB";
			textTranlateDictionary["GB Toggle BG"] = "GB切换背景图层";
			textTranlateDictionary["GB Toggle Obj"] = "GB切换精灵";
			textTranlateDictionary["GB Toggle Window"] = "GB切换窗口图层";
			textTranlateDictionary["Analog"] = "摇杆模拟量";
			textTranlateDictionary["For Virtual Pad"] = "用于虚拟手柄";
			textTranlateDictionary["Y Up Small"] = "Y轴向上小幅";
			textTranlateDictionary["Y Up Large"] = "Y轴向上大幅";
			textTranlateDictionary["Y Down Small"] = "Y轴向下小幅";
			textTranlateDictionary["Y Down Large"] = "Y轴向下大幅";
			textTranlateDictionary["X Up Small"] = "X轴向右小幅";
			textTranlateDictionary["X Up Large"] = "X轴向右大幅";
			textTranlateDictionary["X Down Small"] = "X轴向左小幅";
			textTranlateDictionary["X Down Large"] = "X轴向左大幅";
			textTranlateDictionary["NDS"] = "NDS";
			textTranlateDictionary["Next Screen Layout"] = "下一种屏幕布局";
			textTranlateDictionary["Previous Screen Layout"] = "上一种屏幕布局";
			textTranlateDictionary["Screen Rotate"] = "旋转屏幕";
			textTranlateDictionary["Swap Screens"] = "交换上下屏幕";

			// 视频输出器
			textTranlateDictionary["Writes a series of standard RIFF wav files containing uncompressed audio.  Does not write video.  Splits every 2G."] = "输出一系列标准RIFF格式WAV无损音频文件，不输出视频。每2GB自动分块。";
			textTranlateDictionary["Writes each frame to a directory as a PNG and WAV pair, identified by frame number. The results can be exported into one video file."] = "将每一帧以PNG图像+WAV音频成对输出至文件夹，文件以帧编号命名。输出结果可合并导出为单个视频文件。";
			textTranlateDictionary["Writes a series of .nut files to disk, a container format which can be opened by ffmpeg.  All data is uncompressed.  Splits occur on resolution changes.  NOT RECOMMENDED FOR USE."] = "输出一系列.nut封装格式文件，可由FFmpeg打开。全部数据为无压缩，分辨率发生变化时自动分割。不推荐使用。";
			textTranlateDictionary["Writes a JPC‑rr multidump file (JMD).  These can be read and further processed with jpc‑streamtools.  One JMD file contains all audio (uncompressed) and video (compressed)."] = "输出JPC‑rr多转储文件（JMD），可使用jpc‑streamtools读取并二次处理。单个JMD文件包含全部无损音频与压缩视频数据。";
			textTranlateDictionary["Writes a sequence of 24bpp PNG or JPG files (default compression quality)"] = "输出24位色深的PNG或JPG图像序列，使用默认压缩质量";
			textTranlateDictionary["Creates an animated .gif"] = "生成GIF动图";
			textTranlateDictionary["Uses the Microsoft AVIFIL32 system to write .avi files.  Audio is uncompressed; Video can be compressed with any installed VCM codec.  Splits on 2G and resolution change."] = "调用微软AVIFIL32组件输出AVI文件；音频为无压缩，视频可使用系统已安装的任意VCM编码器。达到2GB或分辨率变化时自动分割。";
			textTranlateDictionary["Uses an external FFMPEG process to encode video and audio.  Various formats supported.  Splits on resolution change."] = "调用外部FFmpeg进程编码音视频，支持多种格式。分辨率发生变化时自动分割输出。";
			textTranlateDictionary["Writes a JPC-rr multidump file (JMD).  These can be read and further processed with jpc-streamtools.  One JMD file contains all audio (uncompressed) and video (compressed)."] = "生成JPC-rr多 Dump文件（JMD）。这类文件可以使用jpc-streamtools进行读取和进一步处理。一个JMD文件中包含了所有的音频数据（未压缩）以及视频数据（已压缩）。";


			// key display name
			textTranlateDictionary["WMouse L"] = "左键";
			textTranlateDictionary["WMouse M"] = "中键";
			textTranlateDictionary["WMouse R"] = "右键";
			textTranlateDictionary["WMouse 1"] = "鼠标侧键4(后退)";
			textTranlateDictionary["WMouse 2"] = "鼠标侧键5(前进)";
			textTranlateDictionary["<[keyname]>:Super"] = "Win";
			textTranlateDictionary["<[keyname]>:Ctrl"] = "Ctrl";
			textTranlateDictionary["<[keyname]>:Alt"] = "Alt";
			textTranlateDictionary["<[keyname]>:Shift"] = "Shift";
			textTranlateDictionary["<[keyname]>:LeftSuper"] = "左Win";
			textTranlateDictionary["<[keyname]>:RightSuper"] = "右Win";
			textTranlateDictionary["<[keyname]>:LeftCtrl"] = "左Ctrl";
			textTranlateDictionary["<[keyname]>:RightCtrl"] = "右Ctrl";
			textTranlateDictionary["<[keyname]>:LeftAlt"] = "左Alt";
			textTranlateDictionary["<[keyname]>:RightAlt"] = "右Alt";
			textTranlateDictionary["<[keyname]>:LeftShift"] = "左Shift";
			textTranlateDictionary["<[keyname]>:RightShift"] = "右Shift";
			textTranlateDictionary["<[keyname]>:WMouse L"] = "鼠标左键";
			textTranlateDictionary["<[keyname]>:WMouse M"] = "鼠标中键";
			textTranlateDictionary["<[keyname]>:WMouse R"] = "鼠标右键";
			textTranlateDictionary["<[keyname]>:WMouse 1"] = "鼠标侧键4(后退)";
			textTranlateDictionary["<[keyname]>:WMouse 2"] = "鼠标侧键5(前进)";
			textTranlateDictionary["<[keyname]>:WMouse X"] = "绝对鼠标X轴";
			textTranlateDictionary["<[keyname]>:WMouse Y"] = "绝对鼠标Y轴";
			textTranlateDictionary["<[keyname]>:RMouse X"] = "相对鼠标X轴";
			textTranlateDictionary["<[keyname]>:RMouse Y"] = "相对鼠标Y轴";
			textTranlateDictionary["<[keyname]>:Backspace"] = "退格键";
			textTranlateDictionary["<[keyname]>:Enter"] = "回车键";
			textTranlateDictionary["<[keyname]>:CapsLock"] = "大写锁定";
			textTranlateDictionary["<[keyname]>:PageDown"] = "下页";
			textTranlateDictionary["<[keyname]>:Number0"] = "0";
			textTranlateDictionary["<[keyname]>:Number1"] = "1";
			textTranlateDictionary["<[keyname]>:Number2"] = "2";
			textTranlateDictionary["<[keyname]>:Number3"] = "3";
			textTranlateDictionary["<[keyname]>:Number4"] = "4";
			textTranlateDictionary["<[keyname]>:Number5"] = "5";
			textTranlateDictionary["<[keyname]>:Number6"] = "6";
			textTranlateDictionary["<[keyname]>:Number7"] = "7";
			textTranlateDictionary["<[keyname]>:Number8"] = "8";
			textTranlateDictionary["<[keyname]>:Number9"] = "9";
			textTranlateDictionary["<[keyname]>:LeftWin"] = "左Win";
			textTranlateDictionary["<[keyname]>:RightWin"] = "右Win";
			textTranlateDictionary["<[keyname]>:Keypad0"] = "小键盘0";
			textTranlateDictionary["<[keyname]>:Keypad1"] = "小键盘1";
			textTranlateDictionary["<[keyname]>:Keypad2"] = "小键盘2";
			textTranlateDictionary["<[keyname]>:Keypad3"] = "小键盘3";
			textTranlateDictionary["<[keyname]>:Keypad4"] = "小键盘4";
			textTranlateDictionary["<[keyname]>:Keypad5"] = "小键盘5";
			textTranlateDictionary["<[keyname]>:Keypad6"] = "小键盘6";
			textTranlateDictionary["<[keyname]>:Keypad7"] = "小键盘7";
			textTranlateDictionary["<[keyname]>:Keypad8"] = "小键盘8";
			textTranlateDictionary["<[keyname]>:Keypad9"] = "小键盘9";
			textTranlateDictionary["<[keyname]>:KeypadMultiply"] = "小键盘*";
			textTranlateDictionary["<[keyname]>:KeypadAdd"] = "小键盘+";
			textTranlateDictionary["<[keyname]>:KeypadComma"] = "小键盘逗号";
			textTranlateDictionary["<[keyname]>:KeypadSubtract"] = "小键盘-";
			textTranlateDictionary["<[keyname]>:KeypadDecimal"] = "小键盘.";
			textTranlateDictionary["<[keyname]>:KeypadDivide"] = "小键盘/";
			textTranlateDictionary["<[keyname]>:ScrollLock"] = "滚动锁定";
			textTranlateDictionary["<[keyname]>:Semicolon"] = "分号 ;";
			textTranlateDictionary["<[keyname]>:Equals"] = "等号";
			textTranlateDictionary["<[keyname]>:Comma"] = "逗号";
			textTranlateDictionary["<[keyname]>:Minus"] = "减号";
			textTranlateDictionary["<[keyname]>:Period"] = "句号";
			textTranlateDictionary["<[keyname]>:Slash"] = "斜杠";
			textTranlateDictionary["<[keyname]>:Backtick"] = "反引号";
			textTranlateDictionary["<[keyname]>:LeftBracket"] = "左方括号";
			textTranlateDictionary["<[keyname]>:Backslash"] = "反斜杠";
			textTranlateDictionary["<[keyname]>:RightBracket"] = "右方括号";
			textTranlateDictionary["<[keyname]>:Apostrophe"] = "单引号";
			textTranlateDictionary["<[keyname]>:OEM102"] = "OEM102";
			textTranlateDictionary["<[keyname]>:KeypadEnter"] = "小键盘回车";

			// 控制器
			textTranlateDictionary["Port1"] = "端口1";
			textTranlateDictionary["Port2"] = "端口2";
			textTranlateDictionary["Player 1"] = "玩家 1";
			textTranlateDictionary["Player 2"] = "玩家 2";
			textTranlateDictionary["Console"] = "控制";
			textTranlateDictionary["<[controllerkey]>:P1 Up"] = "P1 ↑";
			textTranlateDictionary["<[controllerkey]>:P1 Down"] = "P1 ↓";
			textTranlateDictionary["<[controllerkey]>:P1 Left"] = "P1 ←";
			textTranlateDictionary["<[controllerkey]>:P1 Right"] = "P1 →";
			textTranlateDictionary["<[controllerkey]>:P2 Up"] = "P2 ↑";
			textTranlateDictionary["<[controllerkey]>:P2 Down"] = "P2 ↓";
			textTranlateDictionary["<[controllerkey]>:P2 Left"] = "P2 ←";
			textTranlateDictionary["<[controllerkey]>:P2 Right"] = "P2 →";
			textTranlateDictionary["<[controllerkey]>:Power"] = "电源";
			textTranlateDictionary["<[controllerkey]>:Reset"] = "复位";
			textTranlateDictionary["<[controllerkey]>:Up"] = "↑";
			textTranlateDictionary["<[controllerkey]>:Down"] = "↓";
			textTranlateDictionary["<[controllerkey]>:Left"] = "←";
			textTranlateDictionary["<[controllerkey]>:Right"] = "→";

			// GBA
			textTranlateDictionary["DisplayBG0"] = "显示背景0";
			textTranlateDictionary["DisplayBG1"] = "显示背景1";
			textTranlateDictionary["DisplayBG2"] = "显示背景2";
			textTranlateDictionary["DisplayBG3"] = "显示显示3";
			textTranlateDictionary["DisplayOBJ"] = "显示对象";
			textTranlateDictionary["PlayCh0"] = "播放通道0";
			textTranlateDictionary["PlayCh1"] = "播放通道1";
			textTranlateDictionary["PlayCh2"] = "播放通道2";
			textTranlateDictionary["PlayCh3"] = "播放通道3";
			textTranlateDictionary["PlayChA"] = "播放通道A";
			textTranlateDictionary["PlayChB"] = "播放通道B";
			textTranlateDictionary["ColorType"] = "颜色类型";
			textTranlateDictionary["RTCUseRealTime"] = "RTC使用系统真实时间";
			textTranlateDictionary["SkipBios"] = "跳过BIOS";
			textTranlateDictionary["RTCInitialTime"] = "RTC初始时间";
			textTranlateDictionary["SubframeInput"] = "子帧输入";
			textTranlateDictionary["OverrideSaveType"] = "强制覆盖存档类型";
			textTranlateDictionary["OverrideRtc"] = "强制覆盖RTC";
			textTranlateDictionary["OverrideRumble"] = "强制覆盖震动";
			textTranlateDictionary["OverrideLightSensor"] = "强制覆盖光传感器";
			textTranlateDictionary["OverrideGyro"] = "强制覆盖陀螺仪";
			textTranlateDictionary["OverrideTilt"] = "强制覆盖倾斜传感器";
			textTranlateDictionary["OverrideGbPlayerDetect"] = "强制覆盖GB播放器检测";
			textTranlateDictionary["OverrideVbaBugCompat"] = "强制覆盖VBA兼容性Bug模拟";
			textTranlateDictionary["OverridePokemonRomhackDetect"] = "强制覆盖宝可梦ROM改版检测";
			textTranlateDictionary["Skips the BIOS intro.  Not applicable when a BIOS is not provided."] = "跳过BIOS开机引导。未提供BIOS文件时该选项无效。";
			textTranlateDictionary["Causes the internal clock to reflect your system clock.  Only relevant when a game has an RTC chip.  Forced to false for movie recording."] = "让模拟器内部时钟跟随系统时钟。仅对搭载RTC实时时钟芯片的游戏生效；录制TAS录像时会强制关闭此功能。";
			textTranlateDictionary["The initial time of emulation.  Only relevant when a game has an RTC chip and \"RTC Use Real Time\" is false."] = "模拟器的初始时钟时间。仅当游戏带有RTC芯片，且未开启「RTC使用系统真实时间」时生效。";
			textTranlateDictionary["If true, subframe inputs will be possible."] = "开启后，将允许使用子帧输入功能。";
			textTranlateDictionary["Save type used in games."] = "游戏所使用的存档类型。";
			textTranlateDictionary["Enables a compatibility mode for buggy Pokemon romhacks which rely on VBA bugs. Generally you don't need to enable yourself as Pokemon romhack detection will enable this itself."] = "为依赖VBA漏洞的有问题的宝可梦ROM改版开启兼容模式。一般无需手动开启，宝可梦ROM改版检测会自动启用该选项。";
			textTranlateDictionary["Detects Pokemon romhacks and enables compatibility options due to their generally buggy nature. Will override other override settings."] = "检测宝可梦ROM改版并开启对应的兼容选项（这类改版普遍存在程序缺陷）。该设置会覆盖其余强制覆盖类选项。";

			// MD
			textTranlateDictionary["True to draw BG layer A"] = "勾选则绘制背景图层A";
			textTranlateDictionary["True to draw BG layer B"] = "勾选则绘制背景图层B";
			textTranlateDictionary["True to draw BG layer W"] = "勾选则绘制背景图层W";
			textTranlateDictionary["True to draw sprite layer"] = "勾选则绘制精灵图层";
			textTranlateDictionary["When using 1:1 aspect ratio, enable to make screen width constant (320) between game modes"] = "使用1:1宽高比时，开启可让画面宽度在不同游戏模式下固定为320像素";
			textTranlateDictionary["Filler when layers are off"] = "图层关闭时的填充底色";
			textTranlateDictionary["Removes the original sprite-per-scanline hardware limit"] = "移除原版硬件每条扫描线的精灵数量上限";
			textTranlateDictionary["DrawBGB"] = "绘制背景图层B";
			textTranlateDictionary["DrawBGA"] = "绘制背景图层A";
			textTranlateDictionary["DrawBGW"] = "绘制背景图层W";
			textTranlateDictionary["DrawObj"] = "绘制精灵";
			textTranlateDictionary["PadScreen320"] = "320像素宽度固定画面";
			textTranlateDictionary["Backdrop"] = "背景底色";
			textTranlateDictionary["NoSpriteLimit"] = "取消精灵数量限制";
			textTranlateDictionary["Controls the type of any attached normal controllers; six button controllers are used if true, otherwise three button controllers.  Some games don't work correctly with six button controllers.  Not relevant if other controller types are connected."] = "设置普通手柄类型；开启为六键手柄，关闭则为三键手柄。部分游戏在六键手柄下运行异常；接入其他类型手柄时此项无效。";
			textTranlateDictionary["Sets the type of controls that are plugged into the console.  Some games will automatically load with a different control type."] = "设置主机接入的控制器类型。部分游戏会自动使用其他控制器类型启动。";
			textTranlateDictionary["Sets the region of the emulated console.  Many games can run on multiple regions and will behave differently on different ones.  Some games may require a particular region."] = "设置模拟器主机区域。很多游戏支持多区域，在不同区域下表现会有差异，部分游戏需要指定区域才能运行。";
			textTranlateDictionary["Overrides the VDP mode to force it to run at either 60Hz (NTSC) or 50Hz (PAL), regardless of system region."] = "强制覆盖VDP模式，无视主机区域，强制运行在60Hz(NTSC)或50Hz(PAL)";
			textTranlateDictionary["Indicates whether to load the system BIOS rom."] = "选择是否加载系统BIOS镜像";
			textTranlateDictionary["Sets overscan borders shown."] = "设置要显示的过扫描边框";
			textTranlateDictionary["Enables displaying extended Game Gear screen (256x192)."] = "开启Game Gear扩展画面（256×192）";
			textTranlateDictionary["Sets the method used to emulate the FM Sound Unit of the Sega Mark III/Master System. 'MAME' is fast and runs full speed on most systems.'Nuked' is cycle accurate, very high quality, and have substantial CPU requirements."] = "设置世嘉Mark III/Master System的FM音效单元模拟方案。MAME模式速度快，多数设备可满速运行；Nuked为周期精确模拟，音质极佳，但CPU开销很高。";
			textTranlateDictionary["Sets the method used to emulate the FM synthesizer (main sound generator) of the Mega Drive/Genesis.  'MAME' options are fast, and run full speed on most systems.  'Nuked' options are cycle accurate, very high quality, and have substantial CPU requirements.  The 'YM2612' chip is used by the original Model 1 Mega Drive/Genesis.  The 'YM3438' is used in later Mega Drive/Genesis revisions."] = "设置Mega Drive/Genesis的FM合成器（主音频发生器）模拟方案。MAME选项速度快，多数设备可满速；Nuked为周期精确模拟，音质极佳，但CPU占用高。YM2612用于初代Model1主机，YM3438用于后期改版主机。";
			textTranlateDictionary["Only active when filter type is lowpass. Range is 0 - 0xffff. Default value is 40%"] = "仅低通滤波器模式生效，取值范围0~0xFFFF，默认40%";
			textTranlateDictionary["Only active when filter type is three band"] = "仅三段均衡滤波器模式生效";
			textTranlateDictionary["Magic pink by default. Requires core reboot"] = "默认是品红色。修改后需要重启模拟器核心";
			textTranlateDictionary["Forces sprites to always be displayed on top"] = "强制精灵始终绘制在最上层";
			textTranlateDictionary["UseSixButton"] = "使用六键手柄";
			textTranlateDictionary["GenesisFMSoundChip"] = "MD FM音效芯片";
			textTranlateDictionary["SpritesAlwaysOnTop"] = "精灵置顶";
			textTranlateDictionary["ControlTypeLeft"] = "左侧控制器类型";
			textTranlateDictionary["ControlTypeRight"] = "右侧控制器类型";
			textTranlateDictionary["Region"] = "区域";
			textTranlateDictionary["ForceVDP"] = "强制VDP刷新率";
			textTranlateDictionary["LoadBIOS"] = "加载BIOS";
			textTranlateDictionary["Overscan"] = "过扫描";
			textTranlateDictionary["GGExtra"] = "GG扩展画面";
			textTranlateDictionary["SMSFMSoundChip"] = "SMS FM音效芯片";
			textTranlateDictionary["BackdropColor"] = "背景底色";
			textTranlateDictionary["Filter"] = "音频滤波器";
			textTranlateDictionary["LowPassRange"] = "低通强度";
			textTranlateDictionary["LowFreq"] = "低频";
			textTranlateDictionary["HighFreq"] = "高频";
			textTranlateDictionary["LowGain"] = "低频增益";
			textTranlateDictionary["MidGain"] = "中频增益";
			textTranlateDictionary["HighGain"] = "高频增益";

			// SFC
			textTranlateDictionary["ShowBg0"] = "显示背景0";
			textTranlateDictionary["ShowBg1"] = "显示背景1";
			textTranlateDictionary["ShowBg2"] = "显示背景2";
			textTranlateDictionary["ShowBg3"] = "显示背景3";
			textTranlateDictionary["ShowTransparency"] = "显示透明度";
			textTranlateDictionary["PlaySound0"] = "播放声音0";
			textTranlateDictionary["PlaySound1"] = "播放声音1";
			textTranlateDictionary["PlaySound2"] = "播放声音2";
			textTranlateDictionary["PlaySound3"] = "播放声音3";
			textTranlateDictionary["PlaySound4"] = "播放声音4";
			textTranlateDictionary["PlaySound5"] = "播放声音5";
			textTranlateDictionary["PlaySound6"] = "播放声音6";
			textTranlateDictionary["PlaySound7"] = "播放声音7";
			textTranlateDictionary["ShowWindow"] = "显示窗口";
			textTranlateDictionary["ShowSprites0"] = "显示精灵0";
			textTranlateDictionary["ShowSprites1"] = "显示精灵1";
			textTranlateDictionary["ShowSprites2"] = "显示精灵2";
			textTranlateDictionary["ShowSprites3"] = "显示精灵3";
			textTranlateDictionary["Specifies the controller type plugged into the left controller port on the console"] = "指定插入控制台左侧控制器端口的控制器类型";
			textTranlateDictionary["Specifies the controller type plugged into the right controller port on the console"] = "指定插入控制台右侧控制器端口的控制器类型";
			textTranlateDictionary["LeftPort"] = "左端口";
			textTranlateDictionary["RightPort"] = "右端口";

			// NGP
			textTranlateDictionary["Background Scroll"] = "背景滚动";
			textTranlateDictionary["Foreground Scroll"] = "前景滚动";
			textTranlateDictionary["ngp.language"] = "NGP系统语言";
			textTranlateDictionary["Built-In"] = "内置";
			textTranlateDictionary["nyma.rtcinitialtime"] = "NYMA RTC初始时间";
			textTranlateDictionary["nyma.rtcrealtime"] = "NYMA RTC使用真实时间";
			textTranlateDictionary["Built-In - Gamepad"] = "内置 - 游戏手柄";

			// SMS
			textTranlateDictionary["System"] = "系统";
			textTranlateDictionary["SMS only"] = "仅SMS有效";
			textTranlateDictionary["Not applicable to Game Gear"] = "Game Gear上无效";
			textTranlateDictionary["Game Gear only"] = "仅Game Gear有效";
			textTranlateDictionary["SpriteLimit"] = "精灵数量限制";
			textTranlateDictionary["ForceStereoSeparation"] = "强制立体声分离";
			textTranlateDictionary["Fix3D"] = "3D修正";
			textTranlateDictionary["DisplayOverscan"] = "显示过扫描区域";
			textTranlateDictionary["ShowClippedRegions"] = "显示裁剪区域";
			textTranlateDictionary["HighlightActiveDisplayRegion"] = "高亮有效显示区域";
			textTranlateDictionary["DispBG"] = "显示背景图层";
			textTranlateDictionary["DispOBJ"] = "显示精灵";
			textTranlateDictionary["Must be Enabled for TAS"] = "TAS录制必须开启此项";
			textTranlateDictionary["Enables keyboard for non-GG systems"] = "为非Game Gear主机启用键盘输入";
			textTranlateDictionary["The type of controller plugged into the first controller port"] = "一号控制器端口接入的设备类型";
			textTranlateDictionary["The type of controller plugged into the second controller port"] = "二号控制器端口接入的设备类型";
			textTranlateDictionary["AllowOverClock"] = "允许超频";
			textTranlateDictionary["EnableFm"] = "开启FM音效";
			textTranlateDictionary["UseBios"] = "使用BIOS";
			textTranlateDictionary["ConsoleRegion"] = "主机区域";
			textTranlateDictionary["DisplayType"] = "显示类型";
			textTranlateDictionary["UseKeyboard"] = "使用键盘";

			// SS
			textTranlateDictionary["NBG0"] = "背景图层NBG0";
			textTranlateDictionary["ss.input.port6.gun_chairs"] = "端口6 光枪配置";
			textTranlateDictionary["nyma.constantfb"] = "NYMA 固定帧缓冲";
			textTranlateDictionary["NBG1"] = "背景图层NBG1";
			textTranlateDictionary["NBG2"] = "背景图层NBG2";
			textTranlateDictionary["NBG3"] = "背景图层NBG3";
			textTranlateDictionary["RBG0"] = "背景图层RBG0";
			textTranlateDictionary["ss.slstartp"] = "扫描线起始(预)";
			textTranlateDictionary["ss.correct_aspect"] = "修正宽高比";
			textTranlateDictionary["ss.h_blend"] = "水平混合";
			textTranlateDictionary["ss.h_overscan"] = "水平过扫描";
			textTranlateDictionary["ss.slend"] = "扫描线结束";
			textTranlateDictionary["ss.slstart"] = "扫描线起始";
			textTranlateDictionary["ss.input.port12.gun_chairs"] = "端口12 光枪配置";
			textTranlateDictionary["ss.input.port11.gun_chairs"] = "端口11 光枪配置";
			textTranlateDictionary["ss.input.port10.gun_chairs"] = "端口10 光枪配置";
			textTranlateDictionary["ss.input.port9.gun_chairs"] = "端口9 光枪配置";
			textTranlateDictionary["ss.input.port8.gun_chairs"] = "端口8 光枪配置";
			textTranlateDictionary["ss.input.port7.gun_chairs"] = "端口7 光枪配置";
			textTranlateDictionary["ss.slendp"] = "扫描线结束(预)";
			textTranlateDictionary["ss.input.port5.gun_chairs"] = "端口5 光枪配置";
			textTranlateDictionary["ss.input.port4.gun_chairs"] = "端口4 光枪配置";
			textTranlateDictionary["ss.input.port3.gun_chairs"] = "端口3 光枪配置";
			textTranlateDictionary["ss.input.port2.gun_chairs"] = "端口2 光枪配置";
			textTranlateDictionary["ss.input.port1.gun_chairs"] = "端口1 光枪配置";
			textTranlateDictionary["ss.scsp.resamp_quality"] = "SCSP重采样质量";
			textTranlateDictionary["Sprite"] = "精灵图层";
			textTranlateDictionary["RBG1"] = "背景图层RBG1";
			textTranlateDictionary["Virtual Port 1"] = "虚拟端口1";
			textTranlateDictionary["Builtin"] = "内置";
			textTranlateDictionary["Virtual Port 2"] = "虚拟端口2";
			textTranlateDictionary["ss.cd_sanity"] = "CD校验检查";
			textTranlateDictionary["ss.bios_sanity"] = "BIOS校验检查";
			textTranlateDictionary["ss.cart.auto_default"] = "存储卡自动默认";
			textTranlateDictionary["ss.cart"] = "存储卡";
			textTranlateDictionary["ss.smpc.autortc.lang"] = "SMPC自动RTC语言";
			textTranlateDictionary["ss.smpc.autortc"] = "SMPC自动RTC";
			textTranlateDictionary["ss.input.sport2.multitap"] = "物理端口2 多手柄转接器";
			textTranlateDictionary["ss.input.sport1.multitap"] = "物理端口1 多手柄转接器";
			textTranlateDictionary["ss.region_default"] = "默认主机区域";
			textTranlateDictionary["ss.region_autodetect"] = "自动检测主机区域";
			textTranlateDictionary["Virtual Port 3"] = "虚拟端口3";
			textTranlateDictionary["Virtual Port 12"] = "虚拟端口12";
			textTranlateDictionary["Virtual Port 11"] = "虚拟端口11";
			textTranlateDictionary["Virtual Port 10"] = "虚拟端口10";
			textTranlateDictionary["Virtual Port 9"] = "虚拟端口9";
			textTranlateDictionary["Virtual Port 8"] = "虚拟端口8";
			textTranlateDictionary["Virtual Port 7"] = "虚拟端口7";
			textTranlateDictionary["Virtual Port 6"] = "虚拟端口6";
			textTranlateDictionary["Virtual Port 5"] = "虚拟端口5";
			textTranlateDictionary["Virtual Port 4"] = "虚拟端口4";

			// NDS
			textTranlateDictionary["Adjusts the layout of the screens. Natural will change between Vertical and Horizontal depending on Screen Rotation"] = "调整双屏布局。自动模式会根据屏幕旋转在纵向/横向之间切换";
			textTranlateDictionary["Inverts the order of the screens."] = "颠倒上下屏幕顺序";
			textTranlateDictionary["Adjusts the orientation of the screens"] = "调整屏幕旋转方向";
			textTranlateDictionary["Gap between the screens"] = "两屏之间的间距";
			textTranlateDictionary["Auto will set the audio bit depth most accurate to the console (10 for DS, 16 for DSi)."] = "自动模式会选择最贴合主机的音频位深（DS为10位，DSi为16位）";
			textTranlateDictionary["Audio enhancement (original hardware has no audio interpolation)."] = "音频增强（原版硬件没有音频插值）";
			textTranlateDictionary["If true, touch screen polling and ARM7 key polling will be considered for lag frames. Otherwise, only ARM9 key polling will be considered."] = "开启后，触摸采样与ARM7按键采样都会计入延迟帧；关闭则仅统计ARM9按键采样";
			textTranlateDictionary["ScreenInvert"] = "屏幕反转";
			textTranlateDictionary["ScreenLayout"] = "屏幕布局";
			textTranlateDictionary["ScreenRotation"] = "屏幕旋转";
			textTranlateDictionary["ScreenGap"] = "屏幕间距";
			textTranlateDictionary["AudioBitDepth"] = "音频位深";
			textTranlateDictionary["AudioInterpolation"] = "音频插值";
			textTranlateDictionary["ConsiderAltLag"] = "计入额外延迟采样";
			textTranlateDictionary["TraceArm7Thumb"] = "追踪ARM7 Thumb指令";
			textTranlateDictionary["TraceArm7Arm"] = "追踪ARM7 ARM指令";
			textTranlateDictionary["TraceArm9Thumb"] = "追踪ARM9 Thumb指令";
			textTranlateDictionary["TraceArm9Arm"] = "追踪ARM9 ARM指令";
			textTranlateDictionary["Renderer used for 3D. OpenGL Classic requires at least OpenGL 3.2, OpenGL Compute requires at least OpenGL 4.3. Forced to Software when recording a movie."] = "3D渲染器。经典OpenGL最低需要OpenGL3.2，计算着色器OpenGL最低需要OpenGL4.3；录制TAS录像时强制切换为软件渲染器";
			textTranlateDictionary["Offloads 3D rendering to a separate thread. Only used for the software renderer."] = "将3D渲染放到独立线程，仅软件渲染器生效";
			textTranlateDictionary["Factor at which OpenGL upscales the final image. Not used for the software renderer."] = "OpenGL最终画面放大倍数，软件渲染器不使用此项";
			textTranlateDictionary["Enhances polygon quality with OpenGL Classic. Not used for the software nor OpenGL Compute renderer."] = "经典OpenGL模式下提升多边形质量；软件渲染器、计算着色器OpenGL不生效";
			textTranlateDictionary["Uses high resolution coordinates with OpenGL Compute. Not used for the software nor OpenGL Classic renderer."] = "计算着色器OpenGL使用高分辨率坐标；软件渲染器、经典OpenGL不生效";
			textTranlateDictionary["Enables JIT recompilation, offering a speed boost at the cost of accuracy. Debugging tools cannot be used with the JIT. Savestate size will be much larger with the JIT."] = "开启JIT即时重编译，提升运行速度，但会牺牲精度。开启JIT后无法使用调试工具，存档体积会明显变大";
			textTranlateDictionary["Sets the maximum size of a JIT block. Higher values gain more speed but have a higher risk of timing problems."] = "设置JIT代码块最大长度。数值越高速度越快，但时序异常风险越高";
			textTranlateDictionary["Performs literal optimizations in the JIT recompiler."] = "在JIT重编译器中执行常量优化";
			textTranlateDictionary["Performs branch optimizations in the JIT recompiler."] = "在JIT重编译器中执行分支优化";
			textTranlateDictionary["Initial time of emulation. Not used if Use Real Time is true"] = "模拟器初始时间；开启使用真实时间时此项无效";
			textTranlateDictionary["If true, the initial RTC clock will be based off of real time instead of the Initial Time setting. Ignored (set to false) when recording a movie."] = "开启后RTC初始时钟取自系统真实时间，而非上面的初始时间设置；录制TAS录像时强制关闭";
			textTranlateDictionary["If true, touch inputs will be interpolated, creating smoother touch movements. Required to progress in some games. May be undesirable when TASing."] = "开启触摸输入插值，让触摸移动更平滑。部分游戏必须开启才能正常游玩；做TAS时一般不建议开启";
			textTranlateDictionary["If true, DSi mode will be used. Forced true if a DSiWare rom is detected."] = "启用DSi模式；检测到DSiWare游戏时强制开启";
			textTranlateDictionary["If true, real BIOS files will be used. Forced true for DSi."] = "使用真实BIOS文件；DSi模式下强制开启";
			textTranlateDictionary["If true, the full DSi BIOS boot sequence will be done, instead of the first part HLE'd. Requires full (good) BIOS dumps. Ignored outside of DSi mode."] = "完整执行DSi BIOS开机流程，而非HLE高层模拟启动。需要完整可用的BIOS转储文件；非DSi模式无效";
			textTranlateDictionary["If true, initial firmware boot will be skipped. Forced true if firmware cannot be booted (no real bios or missing firmware)."] = "跳过固件启动流程；无法加载固件时自动强制开启（无真实BIOS或固件缺失）";
			textTranlateDictionary["If true, the firmware settings will be overriden by provided settings. Forced true when recording a movie."] = "使用自定义设置覆盖固件内置配置；录制TAS录像时强制开启";
			textTranlateDictionary["If true, the DSi NAND will have all its titles cleared. Forced true when recording a movie."] = "清空DSi NAND内全部程序；录制TAS录像时强制开启";
			textTranlateDictionary["If true, homebrew ROMs will have DLDI enabled, giving them a blank SD Card to use. Ignored for retail ROMs."] = "为自制ROM开启DLDI，模拟空白SD卡；正版零售ROM无效";
			textTranlateDictionary["If true, a blank SD card will be inserted into the DSi SD card slot. Ignored outside of DSi mode."] = "向DSi的SD卡槽插入空白SD卡；非DSi模式无效";
			textTranlateDictionary["If true, the DSi DSP will use HLE (High Level Emulation) if possible. Ignored outside of DSi mode."] = "DSi DSP尽可能使用高层模拟HLE；非DSi模式无效";
			textTranlateDictionary["The way firmware is booted. Auto Boot will go to the game immediately, while Manual Boot will go into the firmware menu. Only applicable if firmware override is in effect."] = "固件启动方式：自动启动直接进入游戏，手动启动进入固件菜单。仅固件覆盖开启时生效";
			textTranlateDictionary["Username in firmware. Only applicable if firmware override is in effect."] = "固件内用户名；仅固件覆盖开启时生效";
			textTranlateDictionary["Language in firmware. Only applicable if firmware override is in effect."] = "固件系统语言；仅固件覆盖开启时生效";
			textTranlateDictionary["Birthday month in firmware. Only applicable if firmware override is in effect."] = "固件生日月份；仅固件覆盖开启时生效";
			textTranlateDictionary["Birthday day in firmware. Only applicable if firmware override is in effect."] = "固件生日日期；仅固件覆盖开启时生效";
			textTranlateDictionary["Favorite color in firmware. Only applicable if firmware override is in effect."] = "固件喜爱颜色；仅固件覆盖开启时生效";
			textTranlateDictionary["Message in firmware. Only applicable if firmware override is in effect."] = "固件留言；仅固件覆盖开启时生效";
			textTranlateDictionary["ThreeDeeRenderer"] = "3D渲染器";
			textTranlateDictionary["UseRealBIOS"] = "使用真实BIOS";
			textTranlateDictionary["FirmwareMessage"] = "固件留言";
			textTranlateDictionary["ThreadedRendering"] = "多线程渲染";
			textTranlateDictionary["GLScaleFactor"] = "OpenGL放大系数";
			textTranlateDictionary["GLBetterPolygons"] = "OpenGL高质量多边形";
			textTranlateDictionary["GLHiResCoordinates"] = "OpenGL高分辨率坐标";
			textTranlateDictionary["EnableJIT"] = "开启JIT";
			textTranlateDictionary["JITMaxBranchSize"] = "JIT最大代码块尺寸";
			textTranlateDictionary["JITLiteralOptimizations"] = "JIT常量优化";
			textTranlateDictionary["JITBranchOptimizations"] = "JIT分支优化";
			textTranlateDictionary["InitialTime"] = "初始时间";
			textTranlateDictionary["UseRealTime"] = "使用真实时间";
			textTranlateDictionary["FirmwareBirthdayDay"] = "固件生日日期";
			textTranlateDictionary["UseTouchInterpolation"] = "触摸插值";
			textTranlateDictionary["FirmwareBirthdayMonth"] = "固件生日月份";
			textTranlateDictionary["UseDSi"] = "启用DSi模式";
			textTranlateDictionary["FirmwareLanguage"] = "固件语言";
			textTranlateDictionary["FirmwareFavouriteColour"] = "固件喜爱颜色";
			textTranlateDictionary["FullDSiBIOSBoot"] = "完整DSi BIOS启动";
			textTranlateDictionary["SkipFirmware"] = "跳过固件";
			textTranlateDictionary["FirmwareOverride"] = "覆盖固件设置";
			textTranlateDictionary["ClearNAND"] = "清空NAND";
			textTranlateDictionary["EnableDLDI"] = "开启DLDI";
			textTranlateDictionary["EnableDSiSDCard"] = "启用DSi SD卡";
			textTranlateDictionary["DSiDSPHLE"] = "DSi DSP高层模拟";
			textTranlateDictionary["FirmwareStartUp"] = "固件启动方式";
			textTranlateDictionary["FirmwareUsername"] = "固件用户名";

			// PSX
			textTranlateDictionary["psx.input.port2.gun_chairs"] = "端口2 光枪配置";
			textTranlateDictionary["psx.input.port1.gun_chairs"] = "端口1 光枪配置";
			textTranlateDictionary["psx.input.port3.gun_chairs"] = "端口3 光枪配置";
			textTranlateDictionary["psx.input.port4.gun_chairs"] = "端口4 光枪配置";
			textTranlateDictionary["psx.input.port5.gun_chairs"] = "端口5 光枪配置";
			textTranlateDictionary["psx.input.port6.gun_chairs"] = "端口6 光枪配置";
			textTranlateDictionary["psx.input.port7.gun_chairs"] = "端口7 光枪配置";
			textTranlateDictionary["psx.input.port8.gun_chairs"] = "端口8 光枪配置";
			textTranlateDictionary["psx.spu.resamp_quality"] = "SPU重采样质量";
			textTranlateDictionary["psx.correct_aspect"] = "修正宽高比";
			textTranlateDictionary["psx.slstart"] = "扫描线起始";
			textTranlateDictionary["psx.slend"] = "扫描线结束";
			textTranlateDictionary["psx.slstartp"] = "扫描线起始(预)";
			textTranlateDictionary["psx.slendp"] = "扫描线结束(预)";
			textTranlateDictionary["psx.h_overscan"] = "水平过扫描";
			textTranlateDictionary["psx.input.port1.memcard"] = "端口1 记忆卡";
			textTranlateDictionary["psx.cd_sanity"] = "CD完整性校验";
			textTranlateDictionary["psx.region_default"] = "默认主机区域";
			textTranlateDictionary["psx.region_autodetect"] = "自动检测主机区域";
			textTranlateDictionary["psx.input.port8.memcard"] = "端口8 记忆卡";
			textTranlateDictionary["psx.input.port7.memcard"] = "端口7 记忆卡";
			textTranlateDictionary["psx.input.port6.memcard"] = "端口6 记忆卡";
			textTranlateDictionary["psx.input.port5.memcard"] = "端口5 记忆卡";
			textTranlateDictionary["psx.input.port4.memcard"] = "端口4 记忆卡";
			textTranlateDictionary["psx.input.port3.memcard"] = "端口3 记忆卡";
			textTranlateDictionary["psx.input.port2.memcard"] = "端口2 记忆卡";
			textTranlateDictionary["psx.bios_sanity"] = "BIOS完整性校验";
			textTranlateDictionary["psx.input.pport2.multitap"] = "物理端口2 多手柄转接器";
			textTranlateDictionary["psx.input.pport1.multitap"] = "物理端口1 多手柄转接器";
			
		}
		//*/
	}
}
