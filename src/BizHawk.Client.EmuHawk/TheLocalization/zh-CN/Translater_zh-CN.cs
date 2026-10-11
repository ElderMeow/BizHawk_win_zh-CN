using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizHawk.Client.EmuHawk.zh_CN
{
	internal class Translater_zh_CN : HardEncodingTextTralslaterBase
	{
		public Translater_zh_CN()
		{
			cultureName = "zh-CN";

			// ====================================================

			InitTranslatedText();
		}

		// 第一批导出和翻译
		private void InitTranslatedText()
		{

			#region A
			// AVOut/AviWriter.cs
			theDictionary["AVIFIL32 Thread died:\n\n{0}"] = "AVIFIL32 线程已终止：\n\n{0}";
			theDictionary["AVI Worker thread died!"] = "AVI 工作线程已终止！";

			// AVOut/FFmpegDownloaderForm.cs
			theDictionary["BizHawk relies on a specific version of FFmpeg. No other version will do. The wrong version will be ignored. There is no way to override this behavior."] = "BizHawk 依赖于特定版本的 FFmpeg，其他版本都不行。版本不正确将被忽略，且无法覆盖此行为。";
			theDictionary["\n\nThe required version could not be found."] = "\n\n找不到所需版本。";
			theDictionary["\n\n(Linux user: If installing manually, you can use a symlink.)"] = "\n\n(Linux 用户：如果是手动安装，可以使用符号链接。)";
			theDictionary["\n\nUse this dialog to download it automatically, or download it yourself from the URL below and place it in the specified location."] = "\n\n使用此对话框自动下载，或者自行从下方 URL 下载后放入指定位置。";

			// AVOut/FFmpegWriter.cs
			theDictionary["Exception! ffmpeg history:\n{0}"] = "异常！ffmpeg 历史记录：\n{0}";

			// AVOut/FFmpegWriterForm.cs
			theDictionary["Lossless UT video and uncompressed audio in an AVI container. Compatible with AVISource(), if UT Video decoder is installed. Fast, but low compression."] = "AVI 容器中的无损 UT 视频和未压缩音频。若安装了 UT Video 解码器，则兼容 AVISource()。速度快，但压缩率低。";
			theDictionary["Lossless FFV1 video and uncompressed audio in an AVI container. Compatible with AVISource(), if ffmpeg based decoder is installed. Slow, but high compression."] = "AVI 容器中的无损 FFV1 视频和未压缩音频。若安装了基于 ffmpeg 的解码器，则兼容 AVISource()。速度慢，但压缩率高。";
			theDictionary["Lossless AVC video and uncompressed audio in an AVI container. High speed and compression, compatible with AVISource() if x264vfw or ffmpeg based decoder is installed. Seeking may be unstable."] = "AVI 容器中的无损 AVC 视频和未压缩音频。速度快、压缩率高，若安装了 x264vfw 或基于 ffmpeg 的解码器，则兼容 AVISource()。拖动定位可能不稳定。";
			theDictionary["Uncompressed video and audio in an AVI container. Very large, don't use!"] = "AVI 容器中的未压缩视频和音频。体积非常大，不要使用！";
			theDictionary["Lossless AVC video and uncompressed audio in a Matroska container."] = "Matroska 容器中的无损 AVC 视频和未压缩音频。";
			theDictionary["AVC video and Vorbis audio in a Matroska container."] = "Matroska 容器中的 AVC 视频和 Vorbis 音频。";
			theDictionary["AVC video and AAC audio in an MP4 container."] = "MP4 容器中的 AVC 视频和 AAC 音频。";
			theDictionary["VP8 video and Vorbis audio in a WebM container."] = "WebM 容器中的 VP8 视频和 Vorbis 音频。";
			theDictionary["Theora video and Vorbis audio in an Ogg container."] = "Ogg 容器中的 Theora 视频和 Vorbis 音频。";
			theDictionary["Xvid video and MP3 audio in an AVI container."] = "AVI 容器中的 Xvid 视频和 MP3 音频。";
			theDictionary["AVC video and AAC audio in a QuickTime container."] = "QuickTime 容器中的 AVC 视频和 AAC 音频。";
			theDictionary["AVC video and AAC audio in a Flash Video container."] = "Flash Video 容器中的 AVC 视频和 AAC 音频。";
			theDictionary["[Custom]"] = "[自定义]";
			theDictionary["Write your own ffmpeg command. For advanced users only."] = "自行编写 ffmpeg 命令。仅供高级用户使用。";

			// AVOut/GifWriterForm.cs
			theDictionary["Auto"] = "自动";
			theDictionary["Fastest"] = "最快";
			theDictionary["{0} FPS"] = "{0} FPS";

			// AVOut/JMDForm.cs
			theDictionary["Number of compression threads: {0}"] = "压缩线程数：{0}";
			theDictionary["Compression Level: NONE"] = "压缩级别：无";
			theDictionary["Compression Level: {0}"] = "压缩级别：{0}";

			// AVOut/JMDWriter.cs
			theDictionary["JMD Worker Thread died:\n\n{0}"] = "JMD 工作线程已终止：\n\n{0}";

			// AVOut/VideoWriterChooserForm.cs
			theDictionary["Size:\r\n{0}x{1}"] = "尺寸：\r\n{0}x{1}";
			theDictionary["Size must be positive!"] = "尺寸必须为正数！";
			theDictionary["Size must be numeric!"] = "尺寸必须为数字！";

			// ArchiveChooser.cs
			theDictionary["Error parsing RegEx: {0}"] = "解析正则表达式出错：{0}";
			theDictionary["Could not find search text"] = "找不到搜索文本";
			#endregion

			#region BCDE
			// BizBoxInfoControl.cs
			theDictionary["authors: {0}"] = "作者：{0}";
			theDictionary["(Ported)"] = "(移植)";

			// CoreFeatureAnalysis.cs
			theDictionary["Core Features"] = "核心功能";
			theDictionary[" (UNRELEASED)"] = "(未发布)";
			theDictionary["Total: {0} Released: {1} Profiled: {2}"] = "总计：{0} 已发布：{1} 已分析：{2}";

			// CustomControls/ExceptionBox.cs
			theDictionary["Done!"] = "完成！";
			theDictionary["ERROR!"] = "错误！";

			// CustomControls/FolderBrowserDialogEx.cs
			theDictionary["Please select a folder below:"] = "请在下方选择一个文件夹：";

			// CustomControls/InputRoll/InputRoll.cs
			theDictionary["Shift click logic for individual cells has not yet implemented"] = "针对单个单元格的 Shift 点击逻辑尚未实现";

			// CustomControls/InputWidget.cs
			theDictionary["Binds the Escape key"] = "绑定 Escape 键";
			theDictionary["Binds the left mouse button"] = "绑定鼠标左键";
			theDictionary["Binds the middle mouse button"] = "绑定鼠标中键";
			theDictionary["Binds the right mouse button"] = "绑定鼠标右键";
			theDictionary["Binds the mouse auxiliary button 1"] = "绑定鼠标附加键 1";
			theDictionary["Binds the mouse auxiliary button 2"] = "绑定鼠标附加键 2";

			// CustomControls/MsgBox.cs
			theDictionary["OK"] = "确定";

			// DownloaderForm.cs
			theDictionary["Download {0}"] = "下载 {0}";
			theDictionary["Downloading..."] = "正在下载...";
			theDictionary["FAILED - Download Again"] = "失败 - 重新下载";

			// Extensions/ControlExtensions.cs
			theDictionary["Columns"] = "列";
			theDictionary["{0} ({1})"] = "{0} ({1})";

			// Extensions/ToolExtensions.cs
			theDictionary["None"] = "无";
			theDictionary["&Copy Canonical Path"] = "复制规范路径(&C)";
			theDictionary["Copy Archive Path"] = "复制归档路径";
			theDictionary["Open &Archive"] = "打开归档(&A)";
			theDictionary["&Copy Path"] = "复制路径(&C)";
			theDictionary["&Explore"] = "浏览(&E)";
			theDictionary["Copy &File"] = "复制文件(&F)";
			theDictionary["&Shell Context Menu"] = "&Shell 上下文菜单";
			theDictionary["-Missing-"] = "-缺失-";
			theDictionary["&Remove"] = "移除(&R)";
			theDictionary["&Clear"] = "清除(&C)";
			theDictionary["&Clear Moved/Deleted"] = "清除已移动/已删除(&C)";
			theDictionary["&Unfreeze"] = "解冻(&U)";
			theDictionary["&Freeze"] = "冻结(&F)";
			theDictionary["&Autoload {0}"] = "自动加载 {0}(&A)";
			theDictionary["&Recent Settings..."] = "最近设置(&R)...";
			theDictionary["Number of recent files to track"] = "最近文件的数量";
			theDictionary["File not found"] = "找不到文件";
			theDictionary["Could not open {0}"] = "无法打开 {0}";
			theDictionary["Could not open {0}\nRemove from list?"] = "无法打开 {0}\n是否从列表中移除？";
			#endregion

			#region LM
			// LogWindow.cs
			theDictionary["Log Window"] = "日志窗口";

			// MainForm.Debug.cs
			theDictionary["Debug RC Hash"] = "调试 RC 哈希";
			theDictionary["Open Dummy Modal Dialog"] = "打开虚拟模态对话框";
			theDictionary["This message is meaningless.\nPress\"OK\" to continue."] = "此消息毫无意义。\n按\"确定\"继续。";
			theDictionary["Queue Dummy OSD Message"] = "排队虚拟 OSD 消息";
			theDictionary["Firmware"] = "固件";
			theDictionary["RCheevos"] = "RCheevos";
			theDictionary["WinForms/UI"] = "WinForms/UI";
			theDictionary["Debug SameBoy States"] = "调试 SameBoy 进度";
			theDictionary["&Debug Utilities"] = "调试工具(&D)";

			// MainForm.Events.cs
			theDictionary["Open Advanced"] = "高级打开";
			theDictionary["Failed to flush saveram!"] = "刷写 RAM 失败！";
			theDictionary["Thanks for using BizHawk!  The emulation core you have selected "] = "感谢使用 BizHawk！您选择的模拟核心 ";
			theDictionary["is currently BETA-status.  We appreciate your help in testing BizHawk. "] = "目前处于 BETA 状态。我们感谢您协助测试 BizHawk。";
			theDictionary["You can record a movie on this core if you'd like to, but expect to "] = "如果您愿意，可以在此核心上录制影片，但请预期会 ";
			theDictionary["encounter bugs and sync problems.  Continue?"] = "遇到 bug 和同步问题。是否继续？";
			theDictionary["Most of these options will cause crashes on Linux."] = "这些选项中的大多数会导致 Linux 崩溃。";
			theDictionary["A/V instability warning"] = "音视频不稳定警告";
			theDictionary["Est. {0} since power-on"] = "开机后估计 {0}";
			theDictionary["(none)"] = "(无)";
			theDictionary["Forget Trusted Tools"] = "忘记受信任的工具";
			theDictionary["Forget trusted ext. tools?"] = "忘记受信任的外部工具？";
			theDictionary["This will cause the warning about running third-party code to show again for all the ext. tools you've previously loaded.\n"] = "这会让之前加载过的所有外部工具再次显示运行第三方代码的警告。\n";
			theDictionary["(If a tool has been loaded this session, the warning may not appear until EmuHawk is restarted.)"] = "(如果本会话中已加载过某工具，警告可能要到重启 EmuHawk 后才会出现。)";
			theDictionary["Current core does not support input polling. TAStudio can't be used."] = "当前核心不支持输入轮询，无法使用 TAStudio。";
			theDictionary["This will reload the rom without saving. Launch TAStudio anyway?"] = "这会在不保存的情况下重新加载 ROM。仍要启动 TAStudio 吗？";
			theDictionary["Confirmation"] = "确认";
			theDictionary["View Subtitles"] = "查看字幕";
			theDictionary["View Comments"] = "查看注释";
			theDictionary["Edit Subtitles"] = "编辑字幕";
			theDictionary["Edit Comments"] = "编辑注释";
			theDictionary["Redo Save to slot {0}"] = "重做保存到进度槽 {0}";
			theDictionary["Undo Save to slot {0}"] = "撤销保存到进度槽 {0}";
			theDictionary["Undo Savestate"] = "撤销进度";
			theDictionary["Hide Menu"] = "隐藏菜单";
			theDictionary["Show Menu"] = "显示菜单";
			theDictionary["Failed to swap state files."] = "交换进度文件失败。";
			theDictionary["Version {0} is now available. Would you like to open the BizHawk homepage?\r\n\r\nClick \"No\" to hide the update notification for this version."] = "版本 {0} 现已可用。是否打开 BizHawk 主页？\r\n\r\n单击\"否\"可隐藏此版本的更新通知。";
			theDictionary["New Version Available"] = "有新版本可用";

			// MainForm.Movie.cs
			theDictionary["Cheats warning"] = "作弊警告";
			theDictionary["Continue playback with cheats enabled?\nChoosing \"No\" will disable cheats but not remove them."] = "在启用作弊的情况下继续播放？\n选择\"否\"将禁用作弊但不会删除它们。";
			theDictionary["Movie/Platform Mismatch"] = "影片与平台不匹配";
			theDictionary["Movie is in playback mode"] = "影片处于播放模式";
			theDictionary["Movie is in record mode"] = "影片处于录制模式";
			theDictionary["No movie is active"] = "没有活动的影片";
			theDictionary["Failed to save movie.\n{0}\n{1}"] = "保存影片失败。\n{0}\n{1}";
			theDictionary["Error"] = "错误";
			theDictionary["Replaying movie file in read-only mode"] = "以只读模式重放影片文件";

			// MainForm.VSystem.cs
			theDictionary["Disk{0}"] = "磁盘{0}";
			theDictionary[" Settings"] = " 设置";
			theDictionary[" Controller Settings"] = " 控制器设置";
			theDictionary["Insert {0}"] = "插入 {0}";
			theDictionary["Upload Failed"] = "上传失败";
			theDictionary["Invalid file format. Reason: {0} \nForce transfer? This may cause the calculator to crash."] = "文件格式无效。原因：{0} \n强制传输？这可能导致计算器崩溃。";
			theDictionary["Settings..."] = "设置";
			theDictionary["{0} Settings"] = "{0} 设置";
			theDictionary["Controller Settings..."] = "控制器设置";
			theDictionary["Filter Settings..."] = "滤镜设置";
			theDictionary["Circular Analog Range"] = "圆形模拟摇杆范围";
			theDictionary["Controller Configuration..."] = "控制器配置";
			theDictionary["Options..."] = "选项";
			theDictionary["Skip BIOS intro (When Applicable)"] = "跳过 BIOS 开场(可用时)";
			theDictionary["Use the Super Game Module"] = "使用 Super Game Module";
			theDictionary["Core Emulation Settings..."] = "核心模拟设置";
			theDictionary["Audio Settings..."] = "音频设置";
			theDictionary["Non-Sync Settings..."] = "非同步设置";
			theDictionary["Palette..."] = "调色板";
			theDictionary["Video Plugins..."] = "视频插件";
			theDictionary["Mupen Style Lag Frames"] = "Mupen 风格延迟帧数";
			theDictionary["Use Expansion Slot"] = "使用扩展插槽";
			theDictionary["VS Settings..."] = "VS 设置";
			theDictionary["Advanced Settings..."] = "高级设置";
			theDictionary["Graphics Settings..."] = "图形设置";
			theDictionary["Controller / Memcard Settings..."] = "控制器/记忆卡设置";
			theDictionary["Options (as NTSC)..."] = "选项(NTSC 模式)";
			theDictionary["Options (as PAL)..."] = "选项(PAL 模式)";
			theDictionary["Choose Custom Palette..."] = "选择自定义调色板";
			theDictionary["Joystick Configuration..."] = "摇杆配置";

			// MainForm.cs
			theDictionary["Rewinder is capturing states"] = "倒带器正在捕获进度";
			theDictionary["{0}&{1}x"] = "{0}&{1}x";
			theDictionary["GB in SGB"] = "SGB 中的 GB";
			theDictionary["Set Libretro Core..."] = "设置 Libretro 核心...";
			theDictionary["Recent"] = "历史";
			theDictionary["(N/A)"] = "(不适用)";
			theDictionary["For Consoles"] = "主机";
			theDictionary["For Handhelds"] = "掌机";
			theDictionary["For Computers"] = "计算机";
			theDictionary["Other"] = "其他";
			theDictionary["Core Settings"] = "核心设置";
			theDictionary["Export Hard Disk Drive..."] = "导出硬盘驱动器...";
			theDictionary["(Dismiss Menu)"] = "(关闭菜单)";
			theDictionary["Warning"] = "警告";
			theDictionary["Couldn't initialize sound device! Try changing the output method in Sound config."] = "无法初始化声音设备！请尝试在声音配置中更改输出方式。";
			theDictionary["Initialization Error"] = "初始化错误";
			theDictionary["Failed to load {0} specified on commandline"] = "无法加载命令行中指定的 {0}";
			theDictionary["Failed to load movie {0} specified on commandline"] = "无法加载命令行中指定的影片 {0}";
			theDictionary["Quick reminder: Your copy of Windows 11 (build {0}) is no longer supported by Microsoft.\nEmuHawk will probably continue working, but please update to 24H2 for increased security."] = "温馨提示：您的 Windows 11 副本(内部版本 {0})已不再受微软支持。\nEmuHawk 可能仍能继续工作，但请更新到 24H2 以获得更高的安全性。";
			theDictionary["Quick reminder: Your copy of Windows 10 (build {0}) is no longer supported by Microsoft.\nEmuHawk will probably continue working, but please update to 22H2 for increased security."] = "温馨提示：您的 Windows 10 副本(内部版本 {0})已不再受微软支持。\nEmuHawk 可能仍能继续工作，但请更新到 22H2 以获得更高的安全性。";
			theDictionary["Quick reminder: Windows {0} is no longer supported by Microsoft.\nEmuHawk will probably continue working, but please get a new operating system for increased security (either Windows 10+ or a GNU+Linux distro)."] = "温馨提示：Windows {0} 已不再受微软支持。\nEmuHawk 可能仍能继续工作，但请更换新的操作系统以获得更高的安全性(Windows 10+ 或 GNU+Linux 发行版)。";
			theDictionary["{0}\n\nSkip this reminder from now on?"] = "{0}\n\n从现在起跳过此提示？";
			theDictionary["Really quit?"] = "确定要退出吗？";
			theDictionary["You are currently recording A/V.\nChoose \"Yes\" to finalise it and quit EmuHawk.\nChoose \"No\" to cancel shutdown and continue recording."] = "您当前正在录制音视频。\n选择\"是\"以完成录制并退出 EmuHawk。\n选择\"否\"以取消关闭并继续录制。";
			theDictionary["Failed to save config file."] = "保存配置文件失败。";
			theDictionary["Native Lua dynamic library was unable to be loaded. "] = "无法加载原生 Lua 动态库。";
			theDictionary["Make sure Lua is installed with your package manager."] = "请确保已通过包管理器安装 Lua。";
			theDictionary["This library is provided in the dll/ folder, try redownloading BizHawk to fix this error."] = "该库位于 dll/ 文件夹中，请尝试重新下载 BizHawk 以修复此错误。";
			theDictionary["Lua Load Error"] = "Lua 加载错误";
			theDictionary["Cheats are currently active"] = "作弊当前已激活";
			theDictionary["Verified good dump"] = "已验证的良好转储";
			theDictionary["Warning: Bad ROM Dump"] = "警告：不良 ROM 转储";
			theDictionary["Homebrew ROM"] = "自制 ROM";
			theDictionary["Translated ROM"] = "翻译版 ROM";
			theDictionary["Hacked ROM"] = "修改版 ROM";
			theDictionary["Warning: Overdump"] = "警告：过量转储";
			theDictionary["Warning: Unknown ROM"] = "警告：未知 ROM";
			theDictionary["Warning: Imperfect emulation"] = "警告：不完全模拟";
			theDictionary["Warning: Unemulated features"] = "警告：未模拟的功能";
			theDictionary["Warning: The game does not work"] = "警告：游戏无法运行";
			theDictionary["Warning: ROM of Unknown Character"] = "警告：性质不明的 ROM";
			theDictionary["Multi-disk bundler"] = "多碟打包器";
			theDictionary["The autosaved SaveRAM is more recent than the normal SaveRAM.\n"] = "自动保存的存档内存比普通存档内存更新。\n";
			theDictionary["This could happen due to a crash or because files were manually modified.\n"] = "这可能是由于崩溃或手动修改文件所致。\n";
			theDictionary["Do you want to load the autosave instead of the older SaveRAM file?"] = "是否加载自动保存而不是较旧的存档内存文件？";
			theDictionary["Load autosaved SaveRAM?"] = "加载自动保存的存档内存？";
			theDictionary["&Settings"] = "设置(&S)";
			theDictionary["Emulator Paused"] = "模拟器已暂停";
			theDictionary["Emulator is turbo seeking to frame {0} click to stop seek"] = "模拟器正在快速定位到帧 {0}，点击可停止定位";
			theDictionary["Emulator is playing to frame {0} click to stop seek"] = "模拟器正在播放到帧 {0}，点击可停止定位";
			theDictionary["Exception on drag and drop:\n{0}"] = "拖放时发生异常：\n{0}";
			theDictionary["No sync settings found, using currently configured settings for this core."] = "找不到同步设置，将使用此核心当前已配置的设置。";
			theDictionary["No sync settings found"] = "找不到同步设置";
			theDictionary["Link connection is currently {0}"] = "连接目前为 {0}";
			theDictionary["Core is producing audio, live playback at {0}% volume"] = "核心正在产生音频，以 {0}% 音量实时播放";
			theDictionary["Core is not producing audio"] = "核心未产生音频";
			theDictionary["Key priority: Allow both hotkeys and controller buttons"] = "按键优先级：快捷键和按键同级";
			theDictionary["Key priority: Controller buttons will override hotkeys"] = "按键优先级：按键将覆盖快捷键";
			theDictionary["Key priority: Hotkeys will override controller buttons"] = "按键优先级：快捷键将覆盖按键";
			theDictionary["(ported) "] = "(移植的)";
			theDictionary["A/V capture in progress"] = "音视频捕获进行中";
			theDictionary["Video dumping died:\n\n{0}"] = "视频转储已终止：\n\n{0}";
			theDictionary["Missing Firmware!"] = "缺少固件！";
			theDictionary["{0}\n\nOpen the firmware manager now?"] = "{0}\n\n现在打开固件管理器？";
			theDictionary["load error"] = "加载错误";
			theDictionary["{0} load error"] = "{0} 加载错误";
			theDictionary["No such core"] = "没有此核心";
			theDictionary["Failed to save cheats."] = "保存作弊码失败。";
			theDictionary["Failed to save movie."] = "保存影片失败。";
			theDictionary["Failed to clear SRAM."] = "清除 SRAM 失败。";
			theDictionary["Failed flushing the game's Save RAM to your disk."] = "将游戏的 RAM 刷写到磁盘时失败。";
			theDictionary["Failed to auto-save state."] = "自动保存进度失败。";
			theDictionary["Conversion error"] = "转换错误";
			theDictionary["While the {0} core is faster, it is not nearly as accurate as {1}.{2}It is recommended that you switch to the {3} core for movie recording.{4}Switch to {5}?"] = "虽然 {0} 核心速度更快，但精度远不及 {1}。{2}建议切换到 {3} 核心进行影片录制。{4}切换到 {5}？";
			theDictionary["Accuracy Warning"] = "精度警告";
			theDictionary["Switch"] = "切换";
			theDictionary["Continue"] = "继续";
			theDictionary["Unable to save state."] = "无法保存进度。";
			#endregion

			#region OPR
			// OpenAdvancedChooser.cs
			theDictionary["Couldn't load the selected Libretro core for analysis. It won't be available.\n\nError:\n\n{0}"] = "无法加载所选的 Libretro 核心用于分析。它将不可用。\n\n错误：\n\n{0}";

			// Program.cs
			theDictionary["EmuHawk requires a 64 bit environment in order to run! EmuHawk will now close."] = "EmuHawk 需要 64 位环境才能运行！EmuHawk 现在将关闭。";
			theDictionary["One or more of the BizHawk.* assemblies have the wrong version!\n(Did you attempt to update by overwriting an existing install?)"] = "一个或多个 BizHawk.* 程序集版本不正确！\n(您是否尝试通过覆盖现有安装来更新？)";
			theDictionary["Mismatched version in config file"] = "配置文件中的版本不匹配";
			theDictionary["It appears your config file (config.ini) is corrupted; an exception was thrown while loading it."] = "您的配置文件 (config.ini) 似乎已损坏；加载时抛出了异常。";
			theDictionary["On closing this warning, EmuHawk will delete your config file and generate a new one. You can go make a backup now if you'd like to look into diffs."] = "关闭此警告后，EmuHawk 将删除您的配置文件并生成新的文件。如果您想查看差异，可以现在去备份。";
			theDictionary["The caught exception was:"] = "捕获的异常为：";
			theDictionary["Initialization of Display Method failed; falling back to {0}"] = "显示方式初始化失败；回退到 {0}";
			theDictionary["Initialization of Direct3D11 Display Method failed; falling back to {0}"] = "Direct3D11 显示方式初始化失败；回退到 {0}";
			theDictionary["Initialization of OpenGL Display Method failed; falling back to {0}"] = "OpenGL 显示方式初始化失败；回退到 {0}";
			theDictionary["SetDllDirectoryW failed with error code {0}, this is fatal. EmuHawk will now close."] = "SetDllDirectoryW 失败，错误代码 {0}，这是致命错误。EmuHawk 现在将关闭。";
			theDictionary["This EmuHawk is privileged"] = "此 EmuHawk 以特权身份运行";
			theDictionary["EmuHawk detected it {0}.\n"] = "EmuHawk 检测到它 {0}。\n";
			theDictionary["Regularly using {0} for things other than system administration makes it easier to hack you.\n"] = "经常将 {0} 用于系统管理之外的事务会让您更容易被入侵。\n";
			theDictionary["If you're certain, you may continue anyway (and without support).\n"] = "如果您确定，仍可继续（但不提供支持）。\n";
			theDictionary["You'll find a flag \"{0}\" in the config file, which disables this warning."] = "您可以在配置文件中找到标志 \"{0}\"，该标志可禁用此警告。";
			theDictionary["EmuHawk has thrown a fatal exception and is about to close.\nA movie has been detected. Would you like to try to save?\n(Note: Depending on what caused this error, this may or may not succeed)"] = "EmuHawk 已抛出致命异常，即将关闭。\n检测到影片。是否尝试保存？\n（注意：取决于导致此错误的原因，此操作可能成功也可能失败）";
			theDictionary["Fatal error: {0}"] = "致命错误：{0}";

			// RetroAchievements/RAIntegration.Update.cs
			theDictionary["An update is required to use RetroAchievements. Do you want to download the update now?"] = "使用 RetroAchievements 需要更新。是否立即下载更新？";
			theDictionary["Update"] = "更新";
			theDictionary["An optional update is available for RetroAchievements. Do you want to download the update now?"] = "RetroAchievements 有可选更新。是否立即下载更新？";
			theDictionary["Failed to fetch update information, cannot start RetroAchievements."] = "获取更新信息失败，无法启动 RetroAchievements。";
			theDictionary["Exception {0} occurred when fetching update information, cannot start RetroAchievements."] = "获取更新信息时发生异常 {0}，无法启动 RetroAchievements。";

			// RetroAchievements/RAIntegration.cs
			theDictionary["Shutdown RetroAchievements"] = "关闭 RetroAchievements";
			theDictionary["Autostart RetroAchievements"] = "自动启动 RetroAchievements";
			theDictionary["{0} Disabling hardcore mode."] = "{0} 正在禁用硬核模式。";
			theDictionary["Loading savestates is not allowed in hardcore mode."] = "硬核模式下不允许加载进度。";
			theDictionary["Failed to reboot core."] = "重启核心失败。";

			// RetroAchievements/RCheevos.cs
			theDictionary["Login"] = "登录";
			theDictionary["Logout"] = "注销";
			theDictionary["Enable Achievements"] = "启用成就";
			theDictionary["Enable Leaderboard Notifications"] = "启用排行榜通知";
			theDictionary["Enable Rich Presence"] = "启用丰富状态";
			theDictionary["Enable Hardcore Mode"] = "启用硬核模式";
			theDictionary["Enable Sound Effects"] = "启用音效";
			theDictionary["Test Unofficial Achievements"] = "测试非官方成就";
			theDictionary["View Game Info"] = "查看游戏信息";
			theDictionary["View Achievement List"] = "查看成就列表";
			theDictionary["View Leaderboard List"] = "查看排行榜列表";
			theDictionary["Loading a quicksave is not allowed in hardcode mode. Abort loading state?"] = "硬核模式下不允许加载快速存档。是否中止加载进度？";

			// RetroAchievements/RCheevosLoginForm.cs
			theDictionary["Login successful"] = "登录成功";
			theDictionary["Login failed"] = "登录失败";

			// RetroAchievements/RetroAchievements.Hardcore.cs
			theDictionary["All loaded games were not verified."] = "所有已加载的游戏均未验证。";
			theDictionary["Playing a movie while in hardcore mode is not allowed."] = "硬核模式下不允许播放影片。";
			theDictionary["Using cheat codes while in hardcore mode is not allowed."] = "硬核模式下不允许使用作弊码。";
			theDictionary["Slow motion in hardcore mode is not allowed."] = "硬核模式下不允许使用慢动作。";
			theDictionary["Using {0} in hardcore mode is not allowed."] = "硬核模式下不允许使用 {0}。";
			theDictionary["Using external tools in hardcore mode is not allowed."] = "硬核模式下不允许使用外部工具。";
			theDictionary["Using subframes in hardcore mode is not allowed."] = "硬核模式下不允许使用子帧。";
			theDictionary["Using MAME in hardcore mode is not allowed."] = "硬核模式下不允许使用 MAME。";
			theDictionary["Disabling {0}'s graphics layers in hardcore mode is not allowed."] = "硬核模式下不允许禁用 {0} 的图形图层。";
			theDictionary["Disabling GambatteLink's graphics layers in hardcore mode is not allowed."] = "硬核模式下不允许禁用 GambatteLink 的图形图层。";
			theDictionary["Disabling Gambatte's graphics layers in hardcore mode is not allowed."] = "硬核模式下不允许禁用 Gambatte 的图形图层。";
			theDictionary["Disabling DSi NAND clear in hardcore mode is not allowed."] = "硬核模式下不允许禁用 DSi NAND 清除。";
			theDictionary["Disabling Skip Firmware in DSi mode in hardcore mode is not allowed."] = "硬核模式下不允许在 DSi 模式中禁用跳过固件。";
			theDictionary["Disabling {0}'s {1} in hardcore mode is not allowed."] = "硬核模式下不允许禁用 {0} 的 {1}。";

			// RetroAchievements/RetroAchievements.cs
			theDictionary["In order to use RetroAchievements, some information needs to be sent to retroachievements.org:\n"] = "为了使用 RetroAchievements，需要向 retroachievements.org 发送一些信息：\n";
			theDictionary["\n\u2022 Your RetroAchievements username and password (first login) or token (subsequent logins)."] = "\n\u2022 您的 RetroAchievements 用户名和密码(首次登录)或令牌(后续登录)。";
			theDictionary["\n\u2022 The hash of the game(s) you have loaded into BizHawk. (for game identification + achievement unlock + leaderboard submission)"] = "\n\u2022 您已加载到 BizHawk 中的游戏的哈希值。(用于游戏识别 + 成就解锁 + 排行榜提交)";
			theDictionary["\n\u2022 The RetroAchievements game ID(s) of the game(s) you have loaded into BizHawk. (for game information + achievement definitions + leaderboard definitions + rich presence definitions + code notes + achievement badges + user unlocks + leaderboard submission + ticket submission)"] = "\n\u2022 您已加载到 BizHawk 中的游戏的 RetroAchievements 游戏 ID。(用于游戏信息 + 成就定义 + 排行榜定义 + 丰富状态定义 + 代码注释 + 成就徽章 + 用户解锁 + 排行榜提交 + 工单提交)";
			theDictionary["\n\u2022 Rich presence data (periodically sent, derived from emulated game memory)."] = "\n\u2022 丰富状态数据(定期发送，从模拟的游戏内存中导出)。";
			theDictionary["\n\u2022 Whether or not you are currently in \"Hardcore Mode\" (for achievement unlock)."] = "\n\u2022 您当前是否处于\"硬核模式\"(用于成就解锁)。";
			theDictionary["\n\u2022 Ticket submission type and message (when submitting tickets with RAIntegration)."] = "\n\u2022 工单提交类型和消息(使用 RAIntegration 提交工单时)。";
			theDictionary["\n\nDo you agree to send this information to retroachievements.org?"] = "\n\n您是否同意将这些信息发送到 retroachievements.org？";
			theDictionary["Notice"] = "注意";
			#endregion

			#region config
			// config/AmstradCPC/AmstradCPCCoreEmulationSettings.cs
			theDictionary["Approximates what you see on a CPC monitor"] = "近似 CPC 显示器上的效果";
			theDictionary["The full display area"] = "完整显示区域";

			// config/AmstradCPC/AmstradCPCNonSyncSettings.cs
			theDictionary["Show all OSD messages"] = "显示所有 OSD 消息";
			theDictionary["Only show machine/device generated messages"] = "仅显示机器/设备生成的消息";
			theDictionary["No core-driven OSD messages"] = "不显示核心驱动的 OSD 消息";

			// config/ControllerConfig.cs
			theDictionary["{0} Configuration"] = "{0} 配置";
			theDictionary["OK to overwrite defaults for current control scheme?"] = "确定要覆盖当前控制方案的默认值吗？";
			theDictionary["Save Defaults"] = "保存默认值";

			// config/ControllerConfig/AnalogBindControl.cs
			theDictionary["Bind!"] = "绑定！";
			theDictionary["Sensitivity: {0:P0}"] = "灵敏度：{0:P0}";
			theDictionary["Deadzone: {0:P0}"] = "死区：{0:P0}";

			// config/ControllerConfig/FeedbackBindControl.cs
			theDictionary["Unbind!"] = "解绑！";
			theDictionary["Pre-scaled by: {0:F1}x"] = "预缩放：{0:F1}x";

			// config/ControllerConfig/FeedbacksBindPanel.cs
			theDictionary["To bind, click \"Bind!\", move an axis (e.g. analog stick) on the desired gamepad, and choose from the dropdown."] = "要绑定，请点击\"绑定！\"，在目标手柄上移动一个轴（例如模拟摇杆），然后从下拉列表中选择。";

			// config/DisplayConfig.cs
			theDictionary["Window title suffix (static and not):"] = "窗口标题后缀(静态和动态)：";
			theDictionary["Snowy NullHawk"] = "NullHawk 雪花";
			theDictionary["Always"] = "总是";
			theDictionary["During Christmas (Dec. 20th through 26th)"] = "圣诞节期间(12月20日至26日)";
			theDictionary["Never"] = "从不";
			theDictionary["Framerate: {0:F1} Hz"] = "帧率：{0:F1} Hz";
			theDictionary["When no rom loaded, draw \"snow\" (white noise):"] = "未加载 ROM 时绘制\"雪花\"(白噪声)：";
			theDictionary["Brightness multiplier:"] = "亮度倍数：";
			theDictionary["RNG bias:"] = "随机数偏差：";
			theDictionary["{0:P2}"] = "{0:P2}";
			theDictionary["Thin"] = "细";
			theDictionary["Thick"] = "粗";

			// config/EmuHawkOptions.cs
			theDictionary["Enable Wii U/Switch GameCube Adapter Support (via libusb)"] = "启用 Wii U/Switch GameCube 适配器支持(通过 libusb)";
			theDictionary["Enable Wii U/Switch GameCube Adapter Support (via Zadig/WinUSB)"] = "启用 Wii U/Switch GameCube 适配器支持(通过 Zadig/WinUSB)";
			theDictionary["Would you like to replace {0},\nand the same for the other modifier keys,\nin existing keybinds for hotkeys and all systems' gamepads?"] = "是否替换 {0}，\n以及其他修饰键，\n在快捷键和所有系统手柄的现有按键绑定中？";
			theDictionary["Rewrite keybinds now?"] = "立即重写按键绑定？";

			// config/FirmwareConfig.cs
			theDictionary["BAD! Why are you using this file"] = "差！你为什么在使用这个文件";
			theDictionary["NO: This doesn't work on the core"] = "否：此文件在此核心上无法工作";
			theDictionary["OK: This works on the core"] = "可：此文件在此核心上可以工作";
			theDictionary["PERFECT: Ideal for TASing and anything"] = "完美：适用于 TAS 及一切用途";
			theDictionary["Close Firmware Manager and reload ROM"] = "关闭固件管理器并重新加载 ROM";
			theDictionary["Close Firmware Manager and reload {0}"] = "关闭固件管理器并重新加载 {0}";
			theDictionary["No file bound for this firmware!"] = "此固件未绑定任何文件！";
			theDictionary["You've bound a custom choice here. Hope you know what you're doing."] = "您在此处绑定了自定义选项。希望您清楚自己在做什么。";
			theDictionary["-custom-"] = "-自定义-";
			theDictionary["Perfect! This file has been bound to an ideal choice"] = "完美！此文件已绑定到理想选项";
			theDictionary["Good! This file has been bound to some kind of a decent choice"] = "良好！此文件已绑定到一种还算不错的选择";
			theDictionary["Bad! This file has been bound to a choice which is known to be bad (details in right-click -> Info)"] = "差！此文件已绑定到已知的不良选项（详细信息请右键 -> 信息）";
			theDictionary["The file that's specified is missing!"] = "指定的文件缺失！";
			theDictionary["You've manually specified a firmware file, and we're sure it's wrong. Hope you know what you're doing."] = "您手动指定了一个固件文件，我们确定它是错误的。希望您清楚自己在做什么。";
			theDictionary["Organize firmware"] = "整理固件";
			theDictionary["This is going to move/rename every automatically-selected firmware file under your configured Firmware folder to match our recommended organizational scheme (which is not super great right now)."] = "这将移动/重命名您配置的固件文件夹下每一个自动选择的固件文件，以匹配我们推荐的整理方案(目前并不是特别好)。";
			theDictionary["\nProceed?"] = "\n是否继续？";
			theDictionary["The selected custom firmware does not reside in the root of the global firmware directory.\nDo you want to copy it there?"] = "所选择的自定义固件不在全局固件目录的根目录下。\n是否将其复制到那里？";
			theDictionary["Import Custom Firmware"] = "导入自定义固件";
			theDictionary["There was an issue copying the file. The customization has NOT been set.\n\n{0}"] = "复制文件时出现问题。自定义设置未生效。\n\n{0}";
			theDictionary["There was an issue during the process. The customization has NOT been set.\n\n{0}"] = "过程中出现问题。自定义设置未生效。\n\n{0}";
			theDictionary["Error importing these files"] = "导入这些文件时出错";

			// config/GB/ColorChooserForm.cs
			theDictionary["Error loading .pal file!"] = "加载 .pal 文件出错！";
			theDictionary["Error saving .pal file!"] = "保存 .pal 文件出错！";

			// config/GB/SameBoyColorChooserForm.cs

			// config/GenericCoreConfig.cs

			// config/HotkeyConfig.cs
			theDictionary["Save States hotkeys operate with branches when TAStudio is engaged."] = "启用 TAStudio 时，保存进度快捷键将配合分支工作。";

			// config/InputCompositeWidget.cs
			theDictionary["* Escape clears a key mapping\r\n* Disable Auto Tab to multiply bind"] = "* Escape 键可清除按键映射\r\n* 禁用自动切换以实现多重绑定";
			theDictionary["Click here for special tricky bindings"] = "点击此处进行特殊的复杂绑定";
			theDictionary["Current Binding: {0}"] = "当前绑定：{0}";

			// config/Messages/MessageConfig.cs
			theDictionary["Messages fade after"] = "消息消失于";
			theDictionary["seconds"] = "秒后";

			// config/N64/N64ControllerSettingControl.cs
			theDictionary["Controller {0}"] = "控制器 {0}";

			// config/NES/NESSoundConfig.cs
			theDictionary["NES Sound Channels"] = "NES 声音通道";

			// config/NES/NESSyncSettingsForm.cs
			theDictionary["Board Properties are special per-mapper system settings.  They are only useful to advanced users creating Tool Assisted Superplays.  No support will be provided if you break something with them."] = "基板属性是针对 Mapper 的特殊系统设置，仅适合制作 TAS 的高级用户。如果您因使用它们而出现问题，我们将不提供支持。";
			theDictionary["Help"] = "帮助";

			// config/PSX/PSXHashDiscs.cs
			theDictionary["PSX Disc Hasher"] = "PSX 光盘哈希工具";

			// config/PSX/PSXOptions.cs
			theDictionary["Finetuned Display Options will take effect if you OK from PSX Options"] = "如果您从 PSX 选项中点确定，微调后的显示选项将生效";
			theDictionary[@"These options control BizHawk's Display Options to make it act quite a lot like Mednafen:

{0} = System (Use emulator-recommended AR)
{1} = true (Maintain aspect ratio [letterbox main window as needed])
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
			theDictionary["Set the directory for {0}"] = "设置 {0} 的目录";

			// config/RewindConfig.cs
			theDictionary["{0:n0} frames"] = "{0:n0} 帧";
			theDictionary["{0:n} minutes"] = "{0:n} 分";

			// config/ZXSpectrum/ZXSpectrumCoreEmulationSettings.cs
			theDictionary["Original border sizes"] = "原始边框尺寸";
			theDictionary["All borders 24px"] = "所有边框 24px";
			theDictionary["No border at all"] = "无边框";
			theDictionary["All borders 10px"] = "所有边框 10px";
			theDictionary["No top and bottom border (almost 16:9)"] = "去除上下边框（接近 16:9）";

			// config/ZXSpectrum/ZXSpectrumJoystickSettings.cs
			theDictionary["Invalid joystick configuration. \nDuplicates have automatically been changed to NULL.\n\nPlease review the configuration"] = "摇杆配置无效。\n重复项已自动改为 NULL。\n\n请检查配置";

			// config/ZXSpectrum/ZXSpectrumNonSyncSettings.cs
			#endregion

			#region debug_movie
			// debug/FirmwareAutopatchDebugToolForm.cs
			theDictionary["dry run (skip writing to disk)"] = "试运行（跳过写入磁盘）";
			theDictionary["wrote {0}"] = "已写入 {0}";
			theDictionary["success"] = "成功";
			theDictionary["patchset declared with target\nSHA1:{0}\nbut produced\nSHA1:{1}\n(is the patch wrong, or the hash?)"] = "补丁集声明的目标为\nSHA1:{0}\n但产生的结果为\nSHA1:{1}\n(是补丁有误，还是哈希有误？)";
			theDictionary["patchset declared for base\nSHA1:{0}\nbut\nSHA1:{1}\nwas provided"] = "补丁集声明的基准为\nSHA1:{0}\n但提供的是\nSHA1:{1}";
			theDictionary["caught {0}:\n{1}"] = "捕获到 {0}：\n{1}";
			theDictionary["apply"] = "应用";
			theDictionary["to file"] = "到文件";
			theDictionary["(browse)"] = "(浏览)";
			theDictionary["patched files are saved in dir set as \"Temp Files\""] = "已修补的文件保存在设置为\"临时文件\"的目录中";
			theDictionary["--> patch"] = "--> 打补丁";

			// debug/N64RomByteswapToolForm.cs
			theDictionary["wrote {0}\n{1}"] = "已写入 {0}\n{1}";
			theDictionary["convert"] = "转换";
			theDictionary["(browse)"] = "（浏览）";
			theDictionary["from <autodetected> (assumes .z64 on fail)"] = "从 <自动检测>（失败时假定为 .z64）";
			theDictionary["to"] = "到";
			theDictionary["--> convert"] = "--> 转换";

			// debug/N64VideoSettingsFuzzToolForm.cs
			theDictionary["--> randomise some props"] = "--> 随机化部分属性";
			theDictionary["--> randomise every prop"] = "--> 随机化所有属性";

			// movie/EditCommentsForm.cs

			// movie/EditSubtitlesForm.cs
			theDictionary["Unable to parse value: {0}"] = "无法解析值：{0}";
			theDictionary["Parse Error Row {0} Column {1}"] = "解析错误 行 {0} 列 {1}";
			theDictionary["Could not determine movie fps, export failed."] = "无法确定影片帧率，导出失败。";
			theDictionary["Subtitles successfully exported to {0}."] = "字幕已成功导出到 {0}。";
			theDictionary["Success"] = "成功";

			// movie/PlayMovie.cs
			theDictionary["{0} {1}"] = "{0} {1}";
			theDictionary["Expected: {0}\nActual: {1}"] = "预期：{0}\n实际：{1}";
			theDictionary["Expected: {0}\n Actual: {1}"] = "预期：{0}\n 实际：{1}";

			// movie/RecordMovie.cs
			theDictionary["&Cancel"] = "取消(&C)";
			theDictionary["&OK"] = "确定(&O)";
			theDictionary["Make default author"] = "设为默认作者";
			theDictionary["File:"] = "文件：";
			theDictionary["Author:"] = "作者：";
			theDictionary["Record From:"] = "录制起始：";
			theDictionary["Record Movie"] = "录制影片";
			theDictionary["{0} already exists, overwrite?"] = "{0} 已存在，是否覆盖？";
			theDictionary["Confirm overwrite"] = "确认覆盖";
			theDictionary["Please select a movie to record"] = "请选择要录制的影片";
			theDictionary["File selection error"] = "文件选择错误";
			#endregion

			#region tools
			// tools/BasicBot/BasicBot.cs
			theDictionary["Basic Bot"] = "基础机器人";
			theDictionary["In order to use this tool you must be recording a movie."] = "要使用此工具，您必须正在录制影片。";
			theDictionary["In order to use this tool, U+D/L+R policy in the controller binds dialog must be set to 'Allow'."] = "要使用此工具，控制器绑定对话框中的 U+D/L+R 策略必须设置为\"允许\"。";
			theDictionary["Replaying"] = "重放中";
			theDictionary["This file was made for a different system ({0})."] = "此文件是为不同的系统制作的({0})。";
			theDictionary[" with a different core ({0})"] = " 使用了不同的核心({0})";
			theDictionary[" with a different version of EmuHawk"] = " 使用了不同版本的 EmuHawk";
			theDictionary[" with a different core ({0}) on a different version of EmuHawk"] = " 在不同版本的 EmuHawk 上使用了不同的核心({0})";
			theDictionary["for a different game ({0}){1}"] = "为不同的游戏({0}){1}";
			theDictionary["This file was made {0}. Load it anyway?"] = "此文件是为 {0} 制作的。仍要加载吗？";
			theDictionary["Confirm file load"] = "确认加载文件";
			theDictionary["{0} loaded"] = "已加载 {0}";
			theDictionary["{0} saved"] = "已保存 {0}";
			theDictionary["Replay stopped"] = "重放已停止";
			theDictionary["Running..."] = "运行中...";
			theDictionary["At least one control must have a probability greater than 0."] = "至少要有一个操作的概率大于 0。";
			theDictionary["A main value address is required."] = "需要提供一个主值地址。";
			theDictionary["A frame count greater than 0 is required"] = "帧数需要大于 0";
			theDictionary["Bot stopped"] = "机器人已停止";
			theDictionary["Replaying best result"] = "正在重放最佳结果";
			theDictionary["Botting in progress"] = "机器人运行中";
			theDictionary["Bot is currently not running"] = "机器人当前未运行";

			// tools/BatchRun.cs
			theDictionary["Number of files: {0}"] = "文件数：{0}";
			theDictionary["Old one still running!"] = "旧的还在运行！";
			theDictionary["No files!"] = "没有文件！";
			theDictionary["Status: Running..."] = "状态：运行中...";
			theDictionary["Status: Finished!"] = "状态：已完成！";
			theDictionary["The Whole Thing Died!"] = "全部任务异常终止！";
			theDictionary["Deaded!"] = "已终止！";
			theDictionary["Can't close while task is running!"] = "任务运行时无法关闭！";
			theDictionary["No results to save!"] = "没有结果可保存！";

			// tools/CDL.cs
			theDictionary["Code Data Logger"] = "代码数据记录器";
			theDictionary["Save changes to CDL session?"] = "是否保存对 CDL 会话的更改？";
			theDictionary["CDL Save"] = "CDL 保存";
			theDictionary["CDL file does not match emulator's current memory map!"] = "CDL 文件与模拟器当前的内存映射不匹配！";
			theDictionary["OK to create new CDL?"] = "确定要创建新的 CDL 吗？";
			theDictionary["Query"] = "询问";
			theDictionary["OK to load new CDL?"] = "确定要加载新的 CDL 吗？";
			theDictionary["Failed to save CDL session."] = "保存 CDL 会话失败。";
			theDictionary["Cannot save with no CDL loaded!"] = "未加载 CDL 时无法保存！";
			theDictionary["Alert"] = "警告";
			theDictionary["Cannot append with no CDL loaded!"] = "未加载 CDL 时无法追加！";
			theDictionary["Cannot clear with no CDL loaded!"] = "未加载 CDL 时无法清除！";
			theDictionary["OK to clear CDL?"] = "确定要清除 CDL 吗？";
			theDictionary["Cannot disassemble with no CDL loaded!"] = "未加载 CDL 时无法反汇编！";

			// tools/Cheats/CheatEdit.cs
			theDictionary["0x{0:X} is not a valid address for the domain {1}"] = "0x{0:X} 不是域 {1} 的有效地址";
			theDictionary["Index out of range"] = "索引超出范围";

			// tools/Cheats/Cheats.cs
			theDictionary["Cheats"] = "作弊";
			theDictionary["{0} {1} {2} active"] = "{0} {1} {2} 已激活";
			theDictionary["{0} saved."] = "已保存 {0}。";
			theDictionary["{0} *"] = "{0} *";
			theDictionary["Big"] = "大端";
			theDictionary["Little"] = "小端";
			theDictionary["New Cheat"] = "新建作弊码";
			theDictionary["Editing Cheat {0} - {1}"] = "正在编辑作弊码 {0} - {1}";
			theDictionary["Multiple Cheats Selected"] = "已选择多个作弊码";
			theDictionary["Names"] = "名称";
			theDictionary["Address"] = "地址";
			theDictionary["Value"] = "值";
			theDictionary["Compare"] = "比较";
			theDictionary["Compare Type"] = "比较类型";
			theDictionary["On"] = "开";
			theDictionary["Size"] = "大小";
			theDictionary["Endian"] = "序";
			theDictionary["Display Type"] = "显示类型";

			// tools/Debugger/AddBreakpointDialog.cs
			theDictionary["Add Breakpoint"] = "添加断点";
			theDictionary["Duplicate Breakpoint"] = "克隆断点";
			theDictionary["Edit Breakpoint"] = "编辑断点";

			// tools/Debugger/BreakpointControl.cs
			theDictionary["{0} Total / {1} Active"] = "{0} 总计 / {1} 活动";

			// tools/Debugger/GenericDebugger.cs
			theDictionary["Debugger"] = "调试器";
			theDictionary["This core does not currently support disassembling"] = "此核心目前不支持反汇编";
			theDictionary["This core does not currently implement this feature"] = "此核心目前未实现此功能";
			theDictionary["This core does not currently support reading registers"] = "此核心目前不支持读取寄存器";
			theDictionary["This core does not currently support breakpoints"] = "此核心目前不支持断点";

			// tools/ExternalToolManager.cs
			theDictionary["This tool doesn't work when no rom is loaded"] = "未加载 ROM 时此工具无法工作";
			theDictionary["This tool doesn't work with this system"] = "此工具不适用于此系统";
			theDictionary["This tool doesn't work with this game"] = "此工具不适用于此游戏";
			theDictionary["The IExternalToolForm has conflicting applicability attributes."] = "IExternalToolForm 具有冲突的适用范围属性。";
			theDictionary["The assembly doesn't contain a class implementing IExternalToolForm and annotated with [ExternalTool]."] = "程序集不包含实现 IExternalToolForm 并带有 [ExternalTool] 标注的类。";
			theDictionary["Something went wrong while trying to load the assembly."] = "尝试加载程序集时出现问题。";
			theDictionary["An exception of type {0} was thrown while trying to load the assembly and look for an IExternalToolForm:\n{1}"] = "尝试加载程序集并查找 IExternalToolForm 时抛出了类型为 {0} 的异常：\n{1}";

			// tools/GBA/GBAGPUView.cs
			theDictionary["GBA GPU Viewer"] = "GBA GPU 查看器";
			theDictionary["Background 0"] = "背景 0";
			theDictionary["Background 1"] = "背景 1";
			theDictionary["Background 2"] = "背景 2";
			theDictionary["Background 3"] = "背景 3";
			theDictionary["Background Palettes"] = "背景调色板";
			theDictionary["Sprite Palettes"] = "精灵调色板";
			theDictionary["Sprites"] = "精灵";
			theDictionary["Sprite Tiles (4bpp)"] = "精灵块 (4bpp)";
			theDictionary["Sprite Tiles (8bpp)"] = "精灵块 (8bpp)";
			theDictionary["Background Tiles (4bpp)"] = "背景块 (4bpp)";
			theDictionary["Background Tiles (8bpp)"] = "背景块 (8bpp)";
			theDictionary["Scanline {0}"] = "扫描线 {0}";
			theDictionary["CTRL + C: Copy under mouse to clipboard."] = "CTRL + C：将鼠标下方的内容复制到剪贴板。";
			theDictionary["{0} copied to clipboard."] = "{0} 已复制到剪贴板。";

			// tools/GB/GBGPUView.cs
			theDictionary["GPU Viewer"] = "GPU 查看器";
			theDictionary["Palette {0}"] = "调色板 {0}";
			theDictionary["Color {0}"] = "颜色 {0}";
			theDictionary["(R,G,B) = ({0},{1},{2})"] = "(R,G,B) = ({0},{1},{2})";
			theDictionary["Tile #{0} @{1}:{2:x4}"] = "块 #{0} @{1}:{2:x4}";
			theDictionary["Tile #{0} @{1:x4}"] = "块 #{0} @{1:x4}";
			theDictionary["{0} Map ({1},{2}) @{3:x4}"] = "{0} 映射 ({1},{2}) @{3:x4}";
			theDictionary["  Tile #{0} @{1:x4}"] = "  块 #{0} @{1:x4}";
			theDictionary["  Tile #{0} @{1}:{2:x4}"] = "  块 #{0} @{1}:{2:x4}";
			theDictionary["  Palette {0}"] = "  调色板 {0}";
			theDictionary["  Flags {0}{1}{2}"] = "  标志 {0}{1}{2}";
			theDictionary["Sprite #{0} @{1:x4}"] = "精灵 #{0} @{1:x4}";
			theDictionary["  (x,y) = ({0},{1})"] = "  (x,y) = ({0},{1})";
			theDictionary["Details - Background"] = "详情 - 背景";
			theDictionary["Details - Window"] = "详情 - 窗口";
			theDictionary["Details - Tiles"] = "详情 - 块";
			theDictionary["Details - Palette"] = "详情 - 调色板";
			theDictionary["Details - Sprite"] = "详情 - 精灵";
			theDictionary["Details - Objects"] = "详情 - 对象";
			theDictionary["CTRL+C copies the pane under the mouse."] = "CTRL+C 复制鼠标下方的面板。";

			// tools/GB/GBPrinterView.cs
			theDictionary["Printer Viewer"] = "打印机查看器";

			// tools/GameShark.cs
			theDictionary["Cheat Code Converter"] = "作弊码转换器";
			theDictionary["Input Error"] = "输入错误";
			theDictionary["Are you sure you want to clear this form?"] = "确定要清空此表单吗？";
			theDictionary["Clear Form"] = "清空表单";

			// tools/Genesis/VDPViewer.cs
			theDictionary["VDP Viewer"] = "VDP 查看器";

			// tools/HexEditor/HexEditor.cs
			theDictionary[".tsv --> Clipboard"] = ".tsv --> 剪贴板";
			theDictionary["Hex Editor"] = "十六进制编辑器";
			theDictionary["{0} {1}{2}  -  {3} addresses"] = "{0} {1}{2}  -  {3} 个地址";
			theDictionary["  Typing: ({0})"] = "  键入：({0})";
			theDictionary[" - Editing Address 0x"] = " - 正在编辑地址 0x";
			theDictionary[" (Selected 0x{0:X})"] = "(已选择 0x{0:X})";
			theDictionary["Save as ROM..."] = "保存为 ROM";
			theDictionary["Save as binary..."] = "保存为二进制";
			theDictionary["This Memory Domain can't be Poked; so importing can't work"] = "此内存域无法被写入；因此无法导入";
			theDictionary["Un&freeze Address"] = "解冻地址(&F)";
			theDictionary["&Freeze Address"] = "冻结地址(&F)";
			theDictionary["Go to Address"] = "转到地址";
			theDictionary["Enter a hexadecimal value"] = "输入一个十六进制值";
			theDictionary["Un&freeze"] = "解冻(&F)";

			// tools/Lua/Libraries/ConsoleLuaLibrary.cs
			theDictionary["console"] = "控制台";

			// tools/Lua/LuaCanvas.cs
			theDictionary["LuaCanvas"] = "Lua 画布";

			// tools/Lua/LuaConsole.cs
			theDictionary["Copy All Logged Messages to Terminal/stdout"] = "将所有记录的消息复制到终端/stdout";
			theDictionary["Script"] = "脚本";
			theDictionary["Path"] = "路径";
			theDictionary["Lua Console"] = "Lua 控制台";
			theDictionary["{0} script ({1} active, {2} paused)"] = "{0} 个脚本（{1} 个活动，{2} 个暂停）";
			theDictionary["{0} scripts"] = "{0} 个脚本";
			theDictionary["{0} scripts ({1} active, {2} paused)"] = "{0} 个脚本（{1} 个活动，{2} 个暂停）";
			theDictionary["Lua session could not be saved to {0}"] = "无法将 Lua 会话保存到 {0}";
			theDictionary["Closing with Unsaved Changes"] = "存在未保存的更改，即将关闭";
			theDictionary["Save {0} session?"] = "是否保存 {0} 会话？";
			theDictionary["Failed to save Lua session."] = "保存 Lua 会话失败。";
			theDictionary["Failed to save {0}"] = "保存 {0} 失败";
			theDictionary["You are about to overwrite an existing Lua script.\n"] = "您即将覆盖一个现有的 Lua 脚本。\n";
			theDictionary["Keep in mind the \"New Lua Script\" option is for creating a brand new Lua script, not for opening Lua scripts.\n"] = "请记住，\"新建 Lua 脚本\"选项是用于创建全新的 Lua 脚本，而不是用于打开 Lua 脚本。\n";
			theDictionary["This warning will not appear again! (the file manager would be warning you about an overwrite anyways)\n"] = "此警告不会再次出现！(文件管理器无论如何都会警告您有关覆盖的问题)\n";
			theDictionary["Proceed with overwrite?"] = "继续覆盖？";
			theDictionary["Overwrite"] = "覆盖";
			theDictionary["Sublime Text 2 (installed)"] = "Sublime Text 2（已安装）";
			theDictionary["Sublime Text 2 (detected)"] = "Sublime Text 2（已发现）";
			theDictionary["Sublime Text 2"] = "Sublime Text 2";
			theDictionary["Notepad++ (installed)"] = "Notepad++（已安装）";
			theDictionary["Notepad++ (detected)"] = "Notepad++（已发现）";
			theDictionary["Notepad++"] = "Notepad++";

			// tools/Lua/LuaPictureBox.cs
			theDictionary["{0}: both {1} must be set to have any effect"] = "{0}：必须同时设置 {1} 才会生效";

			// tools/Macros/MacroInput.cs
			theDictionary["Macro Input"] = "宏输入";
			theDictionary["You have unsaved macro(s). Do you wish to save them?"] = "您有未保存的宏。是否要保存它们？";
			theDictionary["Save?"] = "保存？";
			theDictionary["Start and end frames must be inside the movie."] = "起始帧和结束帧必须在影片范围内。";
			theDictionary["Please select a zone first."] = "请先选择一个区域。";

			// tools/MultiDiskBundler/MultiDiskBundler.cs
			theDictionary["Multi-disk Bundler"] = "多碟打包器";
			theDictionary["File already exists, overwrite?"] = "文件已存在，是否覆盖？";
			theDictionary["File exists"] = "文件已存在";

			// tools/MultiDiskBundler/MultiDiskFileSelector.cs
			theDictionary["Using archives with PSX, PCFX or SATURN is not currently recommended/supported."] = "目前不建议/不支持在 PSX、PCFX 或 SATURN 上使用归档。";

			// tools/NES/BarcodeEntry.cs
			theDictionary["Barcode Entry"] = "条码输入";
			theDictionary["Invalid: {0}"] = "无效：{0}";

			// tools/NES/NESMusicRipper.cs
			theDictionary["Music Ripper"] = "音乐提取器";
			theDictionary["{0} Rows"] = "{0} 行";
			theDictionary["Start"] = "开始";
			theDictionary["Stop"] = "停止";

			// tools/NES/NESNameTableViewer.cs
			theDictionary["Nametable Viewer"] = "命名表查看器";
			theDictionary["{0:X4}"] = "{0:X4}";
			theDictionary["{0:X2}"] = "{0:X2}";

			// tools/NES/NESPPU.cs
			theDictionary["PPU Viewer"] = "PPU 查看器";
			theDictionary["Details"] = "详情";
			theDictionary["Palette: {0}"] = "调色板：{0}";
			theDictionary["Use CTRL+C to copy the pane under the mouse to the clipboard."] = "使用 CTRL+C 将鼠标下方的面板复制到剪贴板。";
			theDictionary["Details - Sprites"] = "详情 - 精灵";
			theDictionary["Number: {0:X2}"] = "编号：{0:X2}";
			theDictionary["Tile: {0:X2}"] = "块：{0:X2}";
			theDictionary["Color: {0}"] = "颜色：{0}";
			theDictionary["Details - Palettes"] = "详情 - 调色板";
			theDictionary["Address: 0x{0:X4}"] = "地址：0x{0:X4}";
			theDictionary["Color: 0x{0:X2}"] = "颜色：0x{0:X2}";
			theDictionary["Offset: {0}"] = "偏移：{0}";
			theDictionary["Details - Patterns"] = "详情 - 图案";
			theDictionary["Address: {0:X4}"] = "地址：{0:X4}";
			theDictionary["Table {0}"] = "表 {0}";
			theDictionary["Tile {0:X2}"] = "块 {0:X2}";

			// tools/PCE/PCEBGViewer.cs
			theDictionary["Background Viewer"] = "背景查看器";

			// tools/PCE/PCESoundDebugger.cs
			theDictionary["Sound Debugger"] = "声音调试器";
			theDictionary["(disabled)"] = "(已禁用)";
			theDictionary["(noise)"] = "(噪声)";

			// tools/PCE/PCETileViewer.cs
			theDictionary["Tile Viewer"] = "块查看器";

			// tools/SMS/VDPViewer.cs

			// tools/SNES/SNESGraphicsDebugger.cs
			theDictionary["Graphics Debugger"] = "图形调试器";
			theDictionary["Mode 1 BG3 priority toggle bit of $2105 is SET"] = "$2105 的 Mode 1 BG3 优先级切换位为 SET";
			theDictionary["Mode 1 BG3 priority toggle bit of $2105 is CLEAR"] = "$2105 的 Mode 1 BG3 优先级切换位为 CLEAR";
			theDictionary["Freeze - Map Entry"] = "冻结 - 映射条目";
			theDictionary["Freeze - Color"] = "冻结 - 颜色";
			theDictionary["Freeze - Tile"] = "冻结 - 块";
			theDictionary["Freeze - OBJ"] = "冻结 - OBJ";

			// tools/TAStudio/BookmarksBranchesBox.cs
			theDictionary["Add Branch ({0})"] = "添加分支 ({0})";
			theDictionary["Add Branch"] = "添加分支";
			theDictionary["Frame"] = "帧";
			theDictionary["UserText"] = "用户文本";
			theDictionary["Undo Branch Load"] = "撤销分支加载";
			theDictionary["Undo Branch Update"] = "撤销分支更新";
			theDictionary["Undo Branch Text Edit"] = "撤销分支文本编辑";
			theDictionary["Undo Branch Removal"] = "撤销分支移除";
			theDictionary["Text for branch {0}"] = "分支 {0} 的文本";
			theDictionary["Enter a message"] = "输入一条消息";

			// tools/TAStudio/MarkerControl.cs
			theDictionary["Add Marker to Emulated Frame ({0})"] = "向模拟帧添加标记 ({0})";
			theDictionary["Add Marker with Text to Emulated Frame ({0} {1})"] = "向模拟帧添加带文本的标记 ({0} {1})";
			theDictionary["Remove Marker ({0} on marker's frame)"] = "移除标记(标记帧上的 {0})";
			theDictionary["State"] = "进度";
			theDictionary["Marker for frame {0}"] = "帧 {0} 的标记";
			theDictionary["Enter a frame number"] = "输入一个帧编号";

			// tools/TAStudio/PlaybackBox.cs
			theDictionary["Hotkey: {0}"] = "快捷键：{0}";
			theDictionary["Hotkey: {0} or {1}"] = "快捷键：{0} 或 {1}";
			theDictionary["\nseek to next marker"] = "\n定位到下一个标记";
			theDictionary["\nseek to previous marker"] = "\n定位到上一个标记";
			theDictionary["\nframe advance"] = "\n帧步进";
			theDictionary["\ngo back 1 step (size of step is configurable in settings)"] = "\n后退 1 步（步长可在设置中配置）";
			theDictionary["\nWheel is always 1 frame per tick."] = "\n滚轮始终为每格 1 帧。";
			theDictionary["\ntoggle pause"] = "\n切换暂停";
			theDictionary["\nWhen enabled, the current emulator frame will be"] = "\n启用后，当前模拟器帧将";
			theDictionary["\nmade visible every time the current frame changes."] = "\n在当前帧每次变化时显示。";
			theDictionary["\nWhen enabled and you edit a frame before the current emulator frame,"] = "\n启用后，当您编辑当前模拟器帧之前的帧时，";
			theDictionary["\nTAStudio will automatically seek back to said emulator frame."] = "\nTAStudio 将自动定位回该模拟器帧。";
			theDictionary["\nWhen enabled, TAStudio will run the emulator as fast as possible during seeks."] = "\n启用后，TAStudio 在定位期间将尽可能快地运行模拟器。";
			theDictionary["\nWhen enabled, you can record inputs while unpaused or when frame advancing."] = "\n启用后，您可以在未暂停或帧步进时记录输入。";

			// tools/TAStudio/TAStudio.IToolForm.cs
			theDictionary["Save {0} project?"] = "是否保存 {0} 项目？";

			// tools/TAStudio/TAStudio.ListView.cs
			theDictionary["Encountered unrecoverable error while drawing the input roll.\n"] = "绘制输入卷帘时遇到无法恢复的错误。\n";
			theDictionary["The current movie will be closed without saving.\n"] = "当前影片将在不保存的情况下关闭。\n";
			theDictionary["The exception was:\n\n{0}"] = "异常为：\n\n{0}";
			theDictionary["Failed to draw input roll"] = "绘制输入卷帘失败";

			// tools/TAStudio/TAStudio.MenuItems.cs
			theDictionary["Failed to create movie."] = "创建影片失败。";
			theDictionary["Convert movie"] = "转换影片";
			theDictionary["This is a regular movie, a new project must be created from it to use in TAStudio\nProceed?"] = "这是一个普通影片，必须在 TAStudio 中从中创建新项目才能使用\n是否继续？";
			theDictionary["Movie load error"] = "影片加载错误";
			theDictionary["This is not a BizHawk movie!"] = "这不是 BizHawk 影片！";
			theDictionary["Failed to save backup."] = "保存备份失败。";
			theDictionary["Failed to save macro.\n{0}\n{1}"] = "保存宏失败。\n{0}\n{1}";
			theDictionary["This core requires emulation to be on the last frame when writing the movie, otherwise movie length will appear incorrect."] = "写入影片时，此核心要求模拟必须位于最后一帧，否则影片长度会显示不正确。";
			theDictionary["Exporting to .bk2..."] = "正在导出为 .bk2...";
			theDictionary["Failed to save .bk2. {0}\nTry again?"] = "保存 .bk2 失败。{0}\n是否重试？";
			theDictionary["{0} exported."] = "已导出 {0}。";
			theDictionary["bk2 export cancelled."] = "bk2 导出已取消。";
			theDictionary["Go to Frame"] = "转到帧";
			theDictionary["Jump/Seek to frame index:"] = "跳转/定位到帧索引：";
			theDictionary["Clone # Times"] = "克隆次数";
			theDictionary["Insert times to clone:"] = "输入要克隆的次数：";
			theDictionary["Are you sure you want to add more than 50 markers?"] = "确定要添加超过 50 个标记吗？";
			theDictionary["Add markers"] = "添加标记";
			theDictionary["The emulator is not deterministic. It might fail even if the difference isn't enough to cause a desync.\nContinue with check?"] = "模拟器不是确定性的。即使差异不足以导致失同步，也可能失败。\n是否继续检查？";
			theDictionary["Not Deterministic"] = "非确定性";
			theDictionary["Bad data between frames {0} and {1}. Save the relevant state (raw data)?"] = "帧 {0} 和 {1} 之间的数据有误。是否保存相关进度(原始数据)？";
			theDictionary["Integrity Failed!"] = "完整性检查失败！";
			theDictionary["Integrity Check passed"] = "完整性检查通过";
			theDictionary["Current roll: #{0}"] = "当前行：#{0}";
			theDictionary["Keys ({0} - {1})"] = "按键 ({0} - {1})";
			theDictionary["Change Peripherals..."] = "更改外设...";
			theDictionary["Changing peripherals/players is done in the core's sync settings (if the core supports different peripherals)."] = "更改外设/玩家是在核心的同步设置中完成的(如果核心支持不同的外设)。";
			theDictionary["\nAs these can't be changed in the middle of a movie, you'll have to close TAStudio, change the settings, and create a new TAStudio project."] = "\n由于这些无法在影片中途更改，您必须关闭 TAStudio 更改设置，然后创建一个新的 TAStudio 项目。";
			theDictionary["Attempt to keep old states?"] = "尝试保留旧进度？";
			theDictionary["Keep old states?"] = "保留旧进度？";

			// tools/TAStudio/TAStudio.Navigation.cs
			theDictionary["Seeking..."] = "正在定位...";

			// tools/TAStudio/TAStudio.cs
			theDictionary["Would you like to save the current movie before closing it?"] = "是否要在关闭当前影片之前保存它？";
			theDictionary["The current movie has unsaved changes. Would you like to save before closing it?"] = "当前影片有未保存的更改。是否要在关闭之前保存？";
			theDictionary["TAStudio will create a new project file from the current movie.\n\n"] = "TAStudio 将从当前影片创建一个新项目文件。\n\n";
			theDictionary["Failed to auto-save. {0}\n{1}\n\nTry again?"] = "自动保存失败。{0}\n{1}\n\n是否重试？";
			theDictionary["Failed to load the movie's client settings. Movie is still usable."] = "加载影片的客户端设置失败。影片仍可使用。";
			theDictionary["Saving backup..."] = "正在保存备份...";
			theDictionary["Saving..."] = "正在保存...";
			theDictionary["Backup .{0} saved to \"Movie backups\" path."] = "备份 .{0} 已保存到\"影片备份\"路径。";
			theDictionary["File saved."] = "文件已保存。";
			theDictionary["Failed to save."] = "保存失败。";
			theDictionary["TAStudio"] = "TAStudio";
			theDictionary["TAStudio - {0}*"] = "TAStudio - {0}*";
			theDictionary["TAStudio - {0}"] = "TAStudio - {0}";
			theDictionary["Selected: {0} {1}, States: {2}"] = "已选择：{0} {1}，进度：{2}";
			theDictionary[", Clipboard: {0} {1}"] = "，剪贴板：{0} {1}";
			theDictionary["Invalid mnemonic string: {0}"] = "无效的助记符字符串：{0}";
			theDictionary["Paste Input failed!"] = "粘贴输入失败！";

			// tools/TAStudio/TAStudioColorSettingsForm.cs
			theDictionary["Cancel"] = "取消";
			theDictionary["Defaults"] = "默认值";
			theDictionary["Edit TAStudio Colors"] = "编辑 TAStudio 颜色";

			// tools/TAStudio/TAStudioSettingsForm.cs
			theDictionary["You have enabled 'bind markers to input' and disabled 'allow editing hidden columns'. This combination is not recommended, and may result in your markers being moved in unexpected ways. Continue?"] = "您已启用\"将标记绑定到输入\"并禁用\"允许编辑隐藏列\"。不建议使用此组合，可能会导致标记以意外方式移动。是否继续？";

			// tools/TI83/TI83KeyPad.cs
			theDictionary["TI-83 Virtual KeyPad"] = "TI-83 虚拟键盘";

			// tools/ToolManager.cs
			theDictionary["&Close"] = "关闭(&C)";
			theDictionary["Save Window &Position"] = "保存窗口位置(&P)";
			theDictionary["Stay on &Top"] = "保持在顶部(&T)";
			theDictionary["&Float from Parent"] = "从父窗口浮动(&F)";
			theDictionary["&Autoload with EmuHawk"] = "随 EmuHawk 自动加载(&A)";
			theDictionary["Restore &Defaults"] = "恢复默认(&D)";
			theDictionary["Confirm loading"] = "确认加载";
			theDictionary["Trust this external tool to run on your device?"] = "信任此外部工具在您的设备上运行？";
			theDictionary["\nIf you're not 100% sure of what the tool will do, choose \"No\"."] = "\n如果您不完全确定该工具会做什么，请选择\"否\"。";
			theDictionary["It seems that the object CustomMainForm does not implement {0}. Please review the code."] = "对象 CustomMainForm 似乎未实现 {0}。请检查代码。";
			theDictionary["No, no, no. Wrong Way !"] = "不，不，不。走错路了！";
			theDictionary["It seems that the object CustomMainForm does not have a public default constructor. Please review the code."] = "对象 CustomMainForm 似乎没有公共默认构造函数。请检查代码。";
			theDictionary["It seems that the object CustomMainForm does not exists. Please review the code."] = "对象 CustomMainForm 似乎不存在。请检查代码。";

			// tools/TraceLogger.cs
			theDictionary["Trace Logger"] = "跟踪记录器";
			theDictionary["Trace log - logging to file..."] = "跟踪日志 - 正在记录到文件...";
			theDictionary["Trace log - logging - {0} instructions"] = "跟踪日志 - 记录中 - {0} 条指令";
			theDictionary["Trace log - logging..."] = "跟踪日志 - 记录中...";
			theDictionary["Trace log - {0} instructions"] = "跟踪日志 - {0} 条指令";
			theDictionary["Trace log"] = "跟踪日志";
			theDictionary["Max lines to display in the window"] = "窗口中显示的最大行数";
			theDictionary["Log file segment size in megabytes\nSetting 0 disables segmentation"] = "日志文件分片大小（兆字节）\n设置为 0 可禁用分片";
			theDictionary["Stop &logging"] = "停止记录(&L)";
			theDictionary["Start &logging"] = "开始记录(&L)";

			// tools/VirtualPads/VirtualpadsTool.cs
			theDictionary["Virtual Pads"] = "虚拟手柄";
			theDictionary["Schema warning: Schema entry '{0}':'{1}' will not correspond to any control in definition '{2}'"] = "架构警告：架构条目 '{0}':'{1}' 将不对应于定义 '{2}' 中的任何控件";
			theDictionary["Dev Warning"] = "开发者警告";

			// tools/Watch/RamPoke.cs
			theDictionary["RAM Poke does not support mixed types"] = "RAM 写入不支持混合类型";
			theDictionary["Unsupported Options"] = "不支持的选项";
			theDictionary["Big Endian"] = "大端";
			theDictionary["Little Endian"] = "小端";
			theDictionary["RAM Poke - {0}"] = "RAM 写入 - {0}";
			theDictionary["An error occured when writing Value."] = "写入值时发生错误。";

			// tools/Watch/RamSearch.cs
			theDictionary["RAM Search"] = "RAM 搜索";
			theDictionary["Search restarted"] = "搜索已重新开始";
			theDictionary["{0} {1} removed"] = "已移除 {0} {1}";
			theDictionary["{0:n0} addresses"] = "{0:n0} 个地址";
			theDictionary["Large domain, switching to fast mode"] = "域过大，切换到快速模式";
			theDictionary["Prev"] = "上一个";
			theDictionary["Changes"] = "变化";
			theDictionary["Diff"] = "差异";
			theDictionary["{0} {1} restored"] = "已恢复 {0} {1}";
			theDictionary["&Unfreeze Address"] = "解冻地址(&F)";

			// tools/Watch/RamWatch.cs
			theDictionary["RAM Watch"] = "RAM 监视";
			theDictionary["Purge duplicates?"] = "清除重复项？";
			theDictionary["This will go through each watch starting from the top,\n"] = "这将从顶部开始遍历每一个监视项，\n";
			theDictionary["removing it if its (domain & addr & size) has been seen before.\n"] = "如果其(域 & 地址 & 大小)之前已经出现过，则将其移除。\n";
			theDictionary["Neither the endianness nor display type are considered.\n"] = "既不考虑字节序也不考虑显示类型。\n";
			theDictionary["Overlapping watches also aren't considered."] = "重叠的监视项也不予考虑。";
			theDictionary["Prev"] = "前值";
			theDictionary["Changes"] = "更改";
			theDictionary["Type"] = "类型";
			theDictionary["Domain"] = "域";
			theDictionary["Notes"] = "注释";
			theDictionary["Save watch file?"] = "是否保存监视文件？";
			theDictionary["Failed to save watch list."] = "保存监视列表失败。";
			theDictionary["Edit Separator"] = "编辑分隔符";
			theDictionary["Separator Text:"] = "分隔符文本：";
			theDictionary[" watch"] = " 个监视";
			theDictionary[" watches"] = " 个监视";

			// tools/Watch/WatchEditor.cs
			theDictionary["Mem Domain:"] = "内存域：";
			theDictionary["Address:"] = "地址：";
			theDictionary["Size:"] = "大小：";
			theDictionary["Display Type:"] = "显示类型：";
			theDictionary["Notes:"] = "注释：";
			theDictionary["New Watch"] = "新建监视";
			theDictionary["Edit {0}"] = "编辑 {0}";
			theDictionary["Duplicate Watch"] = "克隆监视";
			#endregion

		}
	}
}
