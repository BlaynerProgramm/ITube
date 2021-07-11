using System.Collections.Generic;
using ITube.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ITube
{
	public class ChannelViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Channel> Channels { get; set; }
		public ChannelViewModel()
		{
			Channels = new ObservableCollection<Channel>();
			foreach (var s in GetChannels())
			{
				Channels.Add(new Channel(s));
			}
		}

		private static IEnumerable<string> GetChannels()
		{
			string[] listChannels;
			using (StreamReader stream = new("List Channels.csv", Encoding.UTF8))
				listChannels = stream.ReadToEnd().Split(';');
			return listChannels;
		} 

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
