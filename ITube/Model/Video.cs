using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AngleSharp;

namespace ITube.Model
{
	public class Video
	{
		public string Name { get; init; }
		public string Url { get; init; }
		public string Image { get; init; }
		public string Time { get; init; }

		public Video(string name, string url, string image, string time)
		{
			if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(image) && !string.IsNullOrWhiteSpace(time))
			{
				Name = name;
				Url = url;
				Image = image;
				Time = time;
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		/// <summary>
		/// Получить список видео
		/// </summary>
		/// <param name="channelUrl">Ссылка канала</param>
		/// <returns></returns>
		public static IEnumerable<Video> GetVideos(string channelUrl)
		{
			IConfiguration config = Configuration.Default.WithDefaultLoader();
			var document = BrowsingContext.New(config).OpenAsync(channelUrl);

			var elements = document.Result.QuerySelectorAll("html body div div div div div a").Where(x =>
				x.ParentElement.ParentElement.Attributes["class"].Value == "pure-u-1 pure-u-md-1-4");

			return elements.Select(element => new Video(element.Children[1].TextContent,
				element.Attributes["href"].Value,
				$"https://invidious.namazso.eu{element.Children[0].Children[0].Attributes["src"].Value}",
				element.Children[0].Children[1].TextContent)).ToList();
		}

		/// <summary>
		/// Открыть видео в VLC
		/// </summary>
		/// <param name="url">Ссылка на видео</param>
		public static void WatchVideo(string url)
		{
			Process cmd = new();
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.Start();
			cmd.StandardInput.WriteLine($"vlc https://youtube.com{url}");
			cmd.CloseMainWindow();
			cmd.Dispose();
		}
	}
}