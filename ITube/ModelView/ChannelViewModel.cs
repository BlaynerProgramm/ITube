using ITube.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ITube
{
	public class ChannelViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Channel> Channels { get; set; }
		public ChannelViewModel()
		{
			Channels = new ObservableCollection<Channel>(Channel.GetChannels());
		}

		public ICommand AddChannel
		{
			get => new DelegateCommand(x => 
			{
				new View.AddChannel().ShowDialog();
				//OnPropertyChanged("Channels");
			});
			
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName) =>
	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}