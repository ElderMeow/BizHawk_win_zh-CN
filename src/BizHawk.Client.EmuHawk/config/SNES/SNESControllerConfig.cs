using System.Windows.Forms;

using BizHawk.Emulation.Common;
using BizHawk.Emulation.Cores.Nintendo.SNES;

namespace BizHawk.Client.EmuHawk
{
	public partial class SNESControllerSettings : Form
	{
		private readonly ISettingsAdapter _settable;

		private readonly LibsnesCore.SnesSyncSettings _syncSettings;
		private bool _suppressDropdownChangeEvents;

		public SNESControllerSettings(ISettingsAdapter settable)
		{
			_settable = settable;
			_syncSettings = (LibsnesCore.SnesSyncSettings) _settable.GetSyncSettings();
			InitializeComponent();
			Icon = Properties.Resources.GameControllerIcon;
		}

		private void SNESControllerSettings_Load(object sender, EventArgs e)
		{
			LimitAnalogChangeCheckBox.Checked = _syncSettings.LimitAnalogChangeSensitivity;

			_suppressDropdownChangeEvents = true;
			Port1ComboBox.PopulateFromEnum(_syncSettings.LeftPort);
			Port2ComboBox.PopulateFromEnum(_syncSettings.RightPort);
			_suppressDropdownChangeEvents = false;
		}

		private void OkBtn_Click(object sender, EventArgs e)
		{
			bool changed =
				_syncSettings.LeftPort != (LibsnesControllerDeck.ControllerType)Port1ComboBox.SelectedIndex
				|| _syncSettings.RightPort != (LibsnesControllerDeck.ControllerType)Port2ComboBox.SelectedIndex
				|| _syncSettings.LimitAnalogChangeSensitivity != LimitAnalogChangeCheckBox.Checked;

			if (changed)
			{
				_syncSettings.LeftPort = (LibsnesControllerDeck.ControllerType)Port1ComboBox.SelectedIndex;
				_syncSettings.RightPort = (LibsnesControllerDeck.ControllerType)Port2ComboBox.SelectedIndex;
				_syncSettings.LimitAnalogChangeSensitivity = LimitAnalogChangeCheckBox.Checked;

				_settable.PutCoreSyncSettings(_syncSettings);
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void PortComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_suppressDropdownChangeEvents)
			{
				var leftPort = (LibsnesControllerDeck.ControllerType)Port1ComboBox.SelectedIndex;
				var rightPort = (LibsnesControllerDeck.ControllerType)Port2ComboBox.SelectedIndex;
				ToggleMouseSection(leftPort == LibsnesControllerDeck.ControllerType.Mouse
					|| rightPort == LibsnesControllerDeck.ControllerType.Mouse);
			}
		}

		private void ToggleMouseSection(bool show)
		{
			LimitAnalogChangeCheckBox.Visible =
				MouseSpeedLabel1.Visible =
				MouseSpeedLabel2.Visible =
				MouseSpeedLabel3.Visible =
				MouseNagLabel1.Visible =
				MouseNagLabel2.Visible =
				show;
		}
	}
}
