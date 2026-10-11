using System.Windows.Forms;

using BizHawk.Common;
using BizHawk.Emulation.Common;

namespace BizHawk.Client.EmuHawk
{
	public partial class BizBoxInfoControl : UserControl
	{
		private readonly string _url = "";

		public BizBoxInfoControl(CoreAttribute attributes)
		{
			InitializeComponent();
			CoreNameLabel.Text = attributes.CoreName;

			if (!string.IsNullOrEmpty(attributes.Author))
			{
				CoreAuthorLabel.Text = TheLocalizater.TranslateFormatString("authors: {0}", attributes.Author);
			}
			else
			{
				CoreAuthorLabel.Visible = false;
			}

			if (attributes is PortedCoreAttribute ported)
			{
				CorePortedLabel.Text = TheLocalizater.TranslateText("(Ported)");
				_url = ported.PortedUrl;
				CoreUrlLink.Text = ported.PortedVersion;
				CoreUrlLink.Visible = true;
			}
		}

		private void CoreUrlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CoreUrlLink.LinkVisited = true;
			Util.OpenUrlExternal(_url);
		}
	}
}
