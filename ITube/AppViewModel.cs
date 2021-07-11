using System;
using System.Collections.Generic;
using ITube.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Browser;
using AngleSharp.Html.Parser;

namespace ITube
{
	public class AppViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Video> Videos { get; set; }

		public AppViewModel()
		{
			Videos = new ObservableCollection<Video>(GetVideosAsync());
		}

		private static IEnumerable<Video> GetVideosAsync()
		{
			var config = Configuration.Default.WithDefaultLoader();
			var address = "https://invidious.namazso.eu/channel/UCZ26MoNJKaGXFQWKuGVzmAg";
			var document = BrowsingContext.New(config).OpenAsync(address);
			var cellSelector = @"html body div div div div div a";
			var cell = document.Result.QuerySelectorAll(cellSelector).Where(x => x.ParentElement.ParentElement.Attributes["class"].Value == "pure-u-1 pure-u-md-1-4");
			List<Video> list = new();
			foreach (var i in cell)
			{
				list.Add(new Video("sad", i.Attributes["href"].Value));
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
