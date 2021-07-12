using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

		private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var s = (Label) sender;
			Video.WatchVideo(s.Content.ToString());
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			ChannelWindow window = new();
			window.Show();
			Close();
		}
	}
}
