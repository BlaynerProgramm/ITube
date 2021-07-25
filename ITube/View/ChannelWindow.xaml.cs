using System.Windows;
using System.Windows.Controls;
using ITube.Model;

namespace ITube.View
{
	/// <summary>
	/// Interaction logic for ChannelWindow.xaml
	/// </summary>
	public partial class ChannelWindow : Window
	{
		public ChannelWindow() => InitializeComponent();

		private void Selector_OnSelected(object sender, RoutedEventArgs e)
		{
			var s = (ListBox)sender;
			MainWindow window = new((Channel)s.SelectedItem); 
			window.Show();
			Close();
		}
	}
}
