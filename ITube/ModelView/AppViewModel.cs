using ITube.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ITube.ModelView
{
	public class AppViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Video> Videos { get; set; }

		public AppViewModel(string channel)
		{
			Videos = new ObservableCollection<Video>(Video.GetVideos(channel));
		}

		public static void OpenVideo(object url) => Video.WatchVideo((string)url);

		public event PropertyChangedEventHandler PropertyChanged;
	}
}