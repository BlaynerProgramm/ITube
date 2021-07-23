using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ITube.Model;

namespace ITube
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(Channel channel)
		{
			InitializeComponent();
			Title = channel.Name;
			DataContext = new AppViewModel(channel.Url);
		}

		private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) => 
			AppViewModel.OpenVideo((sender as Label).Content);

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			ChannelWindow window = new();
			window.Show();
			Close();
		}
	}
}
