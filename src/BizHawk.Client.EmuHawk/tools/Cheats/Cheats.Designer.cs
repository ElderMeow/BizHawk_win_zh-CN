using BizHawk.WinForms.Controls;

namespace BizHawk.Client.EmuHawk
{
	partial class Cheats
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cheats));
            this.CheatListView = new BizHawk.Client.EmuHawk.InputRoll();
            this.CheatsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToggleContextMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.RemoveContextMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.DisableAllContextMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.ViewInHexEditorContextMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.CheatsMenu = new BizHawk.WinForms.Controls.MenuStripEx();
            this.FileSubMenu = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.NewMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.OpenMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.SaveMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.SaveAsMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.AppendMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.RecentSubMenu = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.toolStripSeparator4 = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.CheatsSubMenu = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.RemoveCheatMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.InsertSeparatorMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.toolStripSeparator3 = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.MoveUpMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.MoveDownMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.SelectAllMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.toolStripSeparator6 = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.ToggleMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.DisableAllCheatsMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.GameGenieSeparator = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.OpenGameGenieEncoderDecoderMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.OptionsSubMenu = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.AlwaysLoadCheatsMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.AutoSaveCheatsMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.DisableCheatsOnLoadMenuItem = new BizHawk.WinForms.Controls.ToolStripMenuItemEx();
            this.toolStrip1 = new BizHawk.WinForms.Controls.ToolStripEx();
            this.NewToolBarItem = new System.Windows.Forms.ToolStripButton();
            this.OpenToolBarItem = new System.Windows.Forms.ToolStripButton();
            this.SaveToolBarItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.RemoveToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.SeparatorToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.MoveUpToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.MoveDownToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.GameGenieToolbarSeparator = new BizHawk.WinForms.Controls.ToolStripSeparatorEx();
            this.LoadGameGenieToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.TotalLabel = new BizHawk.WinForms.Controls.LocLabelEx();
            this.MessageLabel = new BizHawk.WinForms.Controls.LocLabelEx();
            this.CheatGroupBox = new System.Windows.Forms.GroupBox();
            this.CheatEditor = new BizHawk.Client.EmuHawk.CheatEdit();
            this.CheatsContextMenu.SuspendLayout();
            this.CheatsMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.CheatGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheatListView
            // 
            this.CheatListView.AllowColumnReorder = true;
            this.CheatListView.AllowColumnResize = true;
            this.CheatListView.AllowDrop = true;
            this.CheatListView.AlwaysScroll = false;
            resources.ApplyResources(this.CheatListView, "CheatListView");
            this.CheatListView.CellHeightPadding = 0;
            this.CheatListView.ContextMenuStrip = this.CheatsContextMenu;
            this.CheatListView.FullRowSelect = true;
            this.CheatListView.HorizontalOrientation = false;
            this.CheatListView.LetKeysModifySelection = false;
            this.CheatListView.Name = "CheatListView";
            this.CheatListView.RowCount = 0;
            this.CheatListView.ScrollSpeed = 3;
            this.CheatListView.ColumnClick += new BizHawk.Client.EmuHawk.InputRoll.ColumnClickEventHandler(this.CheatListView_ColumnClick);
            this.CheatListView.SelectedIndexChanged += new System.EventHandler(this.CheatListView_SelectedIndexChanged);
            this.CheatListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewCheatForm_DragDrop);
            this.CheatListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.NewCheatForm_DragEnter);
            this.CheatListView.DoubleClick += new System.EventHandler(this.CheatListView_DoubleClick);
            this.CheatListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheatListView_KeyDown);
            // 
            // CheatsContextMenu
            // 
            this.CheatsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleContextMenuItem,
            this.RemoveContextMenuItem,
            this.DisableAllContextMenuItem,
            this.ViewInHexEditorContextMenuItem});
            this.CheatsContextMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.CheatsContextMenu, "CheatsContextMenu");
            this.CheatsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.CheatsContextMenu_Opening);
            // 
            // ToggleContextMenuItem
            // 
            resources.ApplyResources(this.ToggleContextMenuItem, "ToggleContextMenuItem");
            this.ToggleContextMenuItem.Click += new System.EventHandler(this.ToggleMenuItem_Click);
            // 
            // RemoveContextMenuItem
            // 
            resources.ApplyResources(this.RemoveContextMenuItem, "RemoveContextMenuItem");
            this.RemoveContextMenuItem.Click += new System.EventHandler(this.RemoveCheatMenuItem_Click);
            // 
            // DisableAllContextMenuItem
            // 
            resources.ApplyResources(this.DisableAllContextMenuItem, "DisableAllContextMenuItem");
            this.DisableAllContextMenuItem.Click += new System.EventHandler(this.DisableAllCheatsMenuItem_Click);
            // 
            // ViewInHexEditorContextMenuItem
            // 
            resources.ApplyResources(this.ViewInHexEditorContextMenuItem, "ViewInHexEditorContextMenuItem");
            this.ViewInHexEditorContextMenuItem.Click += new System.EventHandler(this.ViewInHexEditorContextMenuItem_Click);
            // 
            // CheatsMenu
            // 
            this.CheatsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSubMenu,
            this.CheatsSubMenu,
            this.OptionsSubMenu});
            resources.ApplyResources(this.CheatsMenu, "CheatsMenu");
            // 
            // FileSubMenu
            // 
            this.FileSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.AppendMenuItem,
            this.RecentSubMenu});
            resources.ApplyResources(this.FileSubMenu, "FileSubMenu");
            this.FileSubMenu.DropDownOpened += new System.EventHandler(this.FileSubMenu_DropDownOpened);
            // 
            // NewMenuItem
            // 
            resources.ApplyResources(this.NewMenuItem, "NewMenuItem");
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            resources.ApplyResources(this.OpenMenuItem, "OpenMenuItem");
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            resources.ApplyResources(this.SaveMenuItem, "SaveMenuItem");
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // SaveAsMenuItem
            // 
            resources.ApplyResources(this.SaveAsMenuItem, "SaveAsMenuItem");
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // AppendMenuItem
            // 
            resources.ApplyResources(this.AppendMenuItem, "AppendMenuItem");
            // 
            // RecentSubMenu
            // 
            this.RecentSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4});
            resources.ApplyResources(this.RecentSubMenu, "RecentSubMenu");
            this.RecentSubMenu.DropDownOpened += new System.EventHandler(this.RecentSubMenu_DropDownOpened);
            // 
            // CheatsSubMenu
            // 
            this.CheatsSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveCheatMenuItem,
            this.InsertSeparatorMenuItem,
            this.toolStripSeparator3,
            this.MoveUpMenuItem,
            this.MoveDownMenuItem,
            this.SelectAllMenuItem,
            this.toolStripSeparator6,
            this.ToggleMenuItem,
            this.DisableAllCheatsMenuItem,
            this.GameGenieSeparator,
            this.OpenGameGenieEncoderDecoderMenuItem});
            resources.ApplyResources(this.CheatsSubMenu, "CheatsSubMenu");
            this.CheatsSubMenu.DropDownOpened += new System.EventHandler(this.CheatsSubMenu_DropDownOpened);
            // 
            // RemoveCheatMenuItem
            // 
            resources.ApplyResources(this.RemoveCheatMenuItem, "RemoveCheatMenuItem");
            this.RemoveCheatMenuItem.Click += new System.EventHandler(this.RemoveCheatMenuItem_Click);
            // 
            // InsertSeparatorMenuItem
            // 
            resources.ApplyResources(this.InsertSeparatorMenuItem, "InsertSeparatorMenuItem");
            this.InsertSeparatorMenuItem.Click += new System.EventHandler(this.InsertSeparatorMenuItem_Click);
            // 
            // MoveUpMenuItem
            // 
            resources.ApplyResources(this.MoveUpMenuItem, "MoveUpMenuItem");
            this.MoveUpMenuItem.Click += new System.EventHandler(this.MoveUpMenuItem_Click);
            // 
            // MoveDownMenuItem
            // 
            resources.ApplyResources(this.MoveDownMenuItem, "MoveDownMenuItem");
            this.MoveDownMenuItem.Click += new System.EventHandler(this.MoveDownMenuItem_Click);
            // 
            // SelectAllMenuItem
            // 
            resources.ApplyResources(this.SelectAllMenuItem, "SelectAllMenuItem");
            this.SelectAllMenuItem.Click += new System.EventHandler(this.SelectAllMenuItem_Click);
            // 
            // ToggleMenuItem
            // 
            resources.ApplyResources(this.ToggleMenuItem, "ToggleMenuItem");
            this.ToggleMenuItem.Click += new System.EventHandler(this.ToggleMenuItem_Click);
            // 
            // DisableAllCheatsMenuItem
            // 
            resources.ApplyResources(this.DisableAllCheatsMenuItem, "DisableAllCheatsMenuItem");
            this.DisableAllCheatsMenuItem.Click += new System.EventHandler(this.DisableAllCheatsMenuItem_Click);
            // 
            // OpenGameGenieEncoderDecoderMenuItem
            // 
            resources.ApplyResources(this.OpenGameGenieEncoderDecoderMenuItem, "OpenGameGenieEncoderDecoderMenuItem");
            this.OpenGameGenieEncoderDecoderMenuItem.Click += new System.EventHandler(this.OpenGameGenieEncoderDecoderMenuItem_Click);
            // 
            // OptionsSubMenu
            // 
            this.OptionsSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlwaysLoadCheatsMenuItem,
            this.AutoSaveCheatsMenuItem,
            this.DisableCheatsOnLoadMenuItem});
            resources.ApplyResources(this.OptionsSubMenu, "OptionsSubMenu");
            this.OptionsSubMenu.DropDownOpened += new System.EventHandler(this.SettingsSubMenu_DropDownOpened);
            // 
            // AlwaysLoadCheatsMenuItem
            // 
            resources.ApplyResources(this.AlwaysLoadCheatsMenuItem, "AlwaysLoadCheatsMenuItem");
            this.AlwaysLoadCheatsMenuItem.Click += new System.EventHandler(this.AlwaysLoadCheatsMenuItem_Click);
            // 
            // AutoSaveCheatsMenuItem
            // 
            resources.ApplyResources(this.AutoSaveCheatsMenuItem, "AutoSaveCheatsMenuItem");
            this.AutoSaveCheatsMenuItem.Click += new System.EventHandler(this.AutoSaveCheatsMenuItem_Click);
            // 
            // DisableCheatsOnLoadMenuItem
            // 
            resources.ApplyResources(this.DisableCheatsOnLoadMenuItem, "DisableCheatsOnLoadMenuItem");
            this.DisableCheatsOnLoadMenuItem.Click += new System.EventHandler(this.CheatsOnOffLoadMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolBarItem,
            this.OpenToolBarItem,
            this.SaveToolBarItem,
            this.toolStripSeparator,
            this.RemoveToolbarItem,
            this.SeparatorToolbarItem,
            this.toolStripSeparator2,
            this.MoveUpToolbarItem,
            this.MoveDownToolbarItem,
            this.GameGenieToolbarSeparator,
            this.LoadGameGenieToolbarItem});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // NewToolBarItem
            // 
            this.NewToolBarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.NewToolBarItem, "NewToolBarItem");
            this.NewToolBarItem.Name = "NewToolBarItem";
            this.NewToolBarItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenToolBarItem
            // 
            this.OpenToolBarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.OpenToolBarItem, "OpenToolBarItem");
            this.OpenToolBarItem.Name = "OpenToolBarItem";
            this.OpenToolBarItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveToolBarItem
            // 
            this.SaveToolBarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.SaveToolBarItem, "SaveToolBarItem");
            this.SaveToolBarItem.Name = "SaveToolBarItem";
            this.SaveToolBarItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // RemoveToolbarItem
            // 
            this.RemoveToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.RemoveToolbarItem, "RemoveToolbarItem");
            this.RemoveToolbarItem.Name = "RemoveToolbarItem";
            this.RemoveToolbarItem.Click += new System.EventHandler(this.RemoveCheatMenuItem_Click);
            // 
            // SeparatorToolbarItem
            // 
            this.SeparatorToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.SeparatorToolbarItem, "SeparatorToolbarItem");
            this.SeparatorToolbarItem.Name = "SeparatorToolbarItem";
            this.SeparatorToolbarItem.Click += new System.EventHandler(this.InsertSeparatorMenuItem_Click);
            // 
            // MoveUpToolbarItem
            // 
            this.MoveUpToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.MoveUpToolbarItem, "MoveUpToolbarItem");
            this.MoveUpToolbarItem.Name = "MoveUpToolbarItem";
            this.MoveUpToolbarItem.Click += new System.EventHandler(this.MoveUpMenuItem_Click);
            // 
            // MoveDownToolbarItem
            // 
            this.MoveDownToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.MoveDownToolbarItem, "MoveDownToolbarItem");
            this.MoveDownToolbarItem.Name = "MoveDownToolbarItem";
            this.MoveDownToolbarItem.Click += new System.EventHandler(this.MoveDownMenuItem_Click);
            // 
            // LoadGameGenieToolbarItem
            // 
            this.LoadGameGenieToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.LoadGameGenieToolbarItem, "LoadGameGenieToolbarItem");
            this.LoadGameGenieToolbarItem.Name = "LoadGameGenieToolbarItem";
            this.LoadGameGenieToolbarItem.Click += new System.EventHandler(this.OpenGameGenieEncoderDecoderMenuItem_Click);
            // 
            // TotalLabel
            // 
            resources.ApplyResources(this.TotalLabel, "TotalLabel");
            this.TotalLabel.Name = "TotalLabel";
            // 
            // MessageLabel
            // 
            resources.ApplyResources(this.MessageLabel, "MessageLabel");
            this.MessageLabel.Name = "MessageLabel";
            // 
            // CheatGroupBox
            // 
            resources.ApplyResources(this.CheatGroupBox, "CheatGroupBox");
            this.CheatGroupBox.Controls.Add(this.CheatEditor);
            this.CheatGroupBox.Name = "CheatGroupBox";
            this.CheatGroupBox.TabStop = false;
            // 
            // CheatEditor
            // 
            resources.ApplyResources(this.CheatEditor, "CheatEditor");
            this.CheatEditor.MemoryDomains = null;
            this.CheatEditor.Name = "CheatEditor";
            // 
            // Cheats
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheatGroupBox);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CheatsMenu);
            this.Controls.Add(this.CheatListView);
            this.Name = "Cheats";
            this.Load += new System.EventHandler(this.Cheats_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewCheatForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NewCheatForm_DragEnter);
            this.CheatsContextMenu.ResumeLayout(false);
            this.CheatsMenu.ResumeLayout(false);
            this.CheatsMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.CheatGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private InputRoll CheatListView;
		private MenuStripEx CheatsMenu;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx FileSubMenu;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx NewMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx OpenMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx SaveMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx SaveAsMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx AppendMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx RecentSubMenu;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx toolStripSeparator4;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx CheatsSubMenu;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx RemoveCheatMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx InsertSeparatorMenuItem;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx toolStripSeparator3;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx MoveUpMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx MoveDownMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx SelectAllMenuItem;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx toolStripSeparator6;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx DisableAllCheatsMenuItem;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx GameGenieSeparator;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx OpenGameGenieEncoderDecoderMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx OptionsSubMenu;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx AlwaysLoadCheatsMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx AutoSaveCheatsMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx DisableCheatsOnLoadMenuItem;
		private ToolStripEx toolStrip1;
		private System.Windows.Forms.ToolStripButton NewToolBarItem;
		private System.Windows.Forms.ToolStripButton OpenToolBarItem;
		private System.Windows.Forms.ToolStripButton SaveToolBarItem;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx toolStripSeparator;
		private System.Windows.Forms.ToolStripButton RemoveToolbarItem;
		private System.Windows.Forms.ToolStripButton SeparatorToolbarItem;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton MoveUpToolbarItem;
		private System.Windows.Forms.ToolStripButton MoveDownToolbarItem;
		private System.Windows.Forms.ToolStripButton LoadGameGenieToolbarItem;
		private BizHawk.WinForms.Controls.LocLabelEx TotalLabel;
		private BizHawk.WinForms.Controls.LocLabelEx MessageLabel;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx ToggleMenuItem;
		private BizHawk.WinForms.Controls.ToolStripSeparatorEx GameGenieToolbarSeparator;
		private System.Windows.Forms.ContextMenuStrip CheatsContextMenu;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx ToggleContextMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx RemoveContextMenuItem;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx DisableAllContextMenuItem;
		private System.Windows.Forms.GroupBox CheatGroupBox;
		private CheatEdit CheatEditor;
		private BizHawk.WinForms.Controls.ToolStripMenuItemEx ViewInHexEditorContextMenuItem;
	}
}