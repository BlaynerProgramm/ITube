using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ITube.Model;
using ITube.ModelView;

namespace ITube.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class VideoChannelWindow : Window
	{
		public VideoChannelWindow(Channel channel)
		{
			InitializeComponent();
			Title = $"Все видео с каналла {channel.Name}";
			DataContext = new AppViewModel(channel.Url);
		}

		private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) =>
			AppViewModel.OpenVideo((sender as Label).Content);

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			View.ChannelWindow window = new();
			window.Show();
			Close();
		}
	}
}