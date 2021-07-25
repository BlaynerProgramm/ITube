using ITube.Model;

using System.Collections.ObjectModel;

namespace ITube.ModelView
{
	public class AppViewModel
	{
		public ObservableCollection<Video> Videos { get; init; }

		public AppViewModel(string channel)
		{
			Videos = new ObservableCollection<Video>(Video.GetVideos(channel));
		}

		public static void OpenVideo(object url) => Video.WatchVideo((string)url);
	}
}