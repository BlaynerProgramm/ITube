using ITube.Model;

using System.Collections.ObjectModel;

namespace ITube
{
	public class ChannelViewModel
	{
		public ObservableCollection<Channel> Channels { get; set; }
		public ChannelViewModel()
		{
			Channels = new ObservableCollection<Channel>();
			foreach (var s in Channel.GetChannels())
			{
				Channels.Add(s);
			}
		}
	}
}