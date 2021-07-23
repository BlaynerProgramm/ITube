using System.Windows;
using ITube.Model;

namespace ITube.View
{
	public partial class AddChannel : Window
	{
		public AddChannel() => InitializeComponent();

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{//UCN6geF_MsLDEp5ISxXKgAFQ
			if (!string.IsNullOrWhiteSpace(tbUrl.Text))
			{
				Channel.AddChannel($"https://invidious.namazso.eu/channel/{tbUrl.Text}");
				Close();
			}
		}
	}
}