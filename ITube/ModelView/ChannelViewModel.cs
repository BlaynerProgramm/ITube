using ITube.Model;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ITube.ModelView
{
	public class ChannelViewModel
	{
		public ObservableCollection<Channel> Channels { get; init; }
		public ChannelViewModel()
		{
			Channels = new ObservableCollection<Channel>(Channel.GetChannels());
		}

		public static ICommand AddChannel
		{
			get => new DelegateCommand(x => { new View.AddChannel().ShowDialog(); });
		}
	}
}