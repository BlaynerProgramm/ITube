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
using System.Windows.Shapes;
using ITube.Model;

namespace ITube.View
{
	/// <summary>
	/// Interaction logic for AddChannel.xaml
	/// </summary>
	public partial class AddChannel : Window
	{
		public AddChannel()
		{
			InitializeComponent();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			Channel.AddChannel(tbUrl.Text);
			Close();
		}
	}
}
