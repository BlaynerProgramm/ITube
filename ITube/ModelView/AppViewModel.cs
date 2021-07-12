using ITube.Model;

using System.Collections.ObjectModel;

namespace ITube
{
	public class AppViewModel
	{
		public ObservableCollection<Video> Videos { get; set; }

		public AppViewModel(string channel)
		{
			Videos = new ObservableCollection<Video>(Video.GetVideos(channel));
		}
	}
}