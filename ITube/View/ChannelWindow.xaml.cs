using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
			DataContext = new ChannelViewModel();
		}

		private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Label s = (Label)sender;
			MainWindow window = new(s.Content.ToString());
			window.Show();
			Close();
		}
	}
}
