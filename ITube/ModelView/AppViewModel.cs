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
		private static string _channel;

		public AppViewModel(string channel)
		{
			_channel = channel;
			Videos = new ObservableCollection<Video>(GetVideos());
		}

		private static IEnumerable<Video> GetVideos()
		{
			IConfiguration config = Configuration.Default.WithDefaultLoader();
			string address = _channel;
			var document = BrowsingContext.New(config).OpenAsync(address);
			const string cellSelector = @"html body div div div div div a";

			var elements = document.Result.QuerySelectorAll(cellSelector).Where(x =>
				x.ParentElement.ParentElement.Attributes["class"].Value == "pure-u-1 pure-u-md-1-4");

			return elements.Select(element => new Video(element.Children[1].TextContent,
				element.Attributes["href"].Value,
				$"https://invidious.namazso.eu{element.Children[0].Children[0].Attributes["src"].Value}",
				element.Children[0].Children[1].TextContent)).ToList();
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