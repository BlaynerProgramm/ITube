using AngleSharp;

using ITube.Model;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ITube
{
	public class AppViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Video> Videos { get; set; }
		private static string _chennel;
		public AppViewModel(string chennel)
		{
			_chennel = chennel;
			Videos = new ObservableCollection<Video>(GetVideos());
		}

		private static IEnumerable<Video> GetVideos()
		{
			var config = Configuration.Default.WithDefaultLoader();
			var address = _chennel;
			var document = BrowsingContext.New(config).OpenAsync(address);
			const string cellSelector = @"html body div div div div div a";
			var elements = document.Result.QuerySelectorAll(cellSelector).Where(x => x.ParentElement.ParentElement.Attributes["class"].Value == "pure-u-1 pure-u-md-1-4");
			List<Video> list = new();
			foreach (var i in elements)
			{
				list.Add(new Video(i.Children[1].TextContent, i.Attributes["href"].Value, $"https://invidious.namazso.eu{i.Children[0].Children[0].Attributes["src"].Value}", i.Children[0].Children[1].TextContent));
			}
			return list;
		}

		public static void WatchVideo(string url)
		{
			Process cmd = new();
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.Start();
			cmd.StandardInput.WriteLine($"vlc https://youtube.com{url}");
			cmd.WaitForExit();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

	}
}
