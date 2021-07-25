using System.Windows;
using System.Windows.Controls;
using ITube.Model;
using ITube.ModelView;
using ITube.View;

namespace ITube
{
	/// <summary>
	/// Interaction logic for ChannelWindow.xaml
	/// </summary>
	public partial class ChannelWindow : Window
	{
		public ChannelWindow()
		{
			InitializeComponent();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			AddChannel window = new();
			window.ShowDialog();
			DataContext = new ChannelViewModel();
		}

		private void Selector_OnSelected(object sender, RoutedEventArgs e)
		{
			var s = (ListBox) sender;
			MainWindow window = new((Channel)s.SelectedItem); 
			window.Show();
			Close();
		}
	}
}
