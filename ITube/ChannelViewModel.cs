using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using ITube.Model;

namespace ITube
{
	public class ChannelViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Channel> Channels { get; set; }
		public ChannelViewModel()
		{
			string[] listChannels;
			using (StreamReader stream = new("List Channels.csv", Encoding.UTF8))
			{
				listChannels = stream.ReadToEnd().Split(';');
			}
			Channels = new ObservableCollection<Channel>();
			foreach (var s in listChannels)
			{
				Channels.Add(new Channel() { Url = s });
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
