using System.Windows;
using ITube.Model;

namespace ITube.View
{
	public partial class AddChannel
	{
		public AddChannel() => InitializeComponent();

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbUrl.Text)) return;
			Channel.AddChannel($"https://invidious.namazso.eu/channel/{tbUrl.Text}");
			Close();
		}
	}
}