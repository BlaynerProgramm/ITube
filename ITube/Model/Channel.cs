using AngleSharp;

using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace ITube.Model
{
	/// <summary>
	/// Канал
	/// </summary>
	public class Channel
	{
		public string Name { get; init; }
		public string Image { get; set; }
		public string Subscribe { get; set; }
		public string Url { get; init; }

		public Channel(string url, string image, string subscribe ,string name)
		{
			Url = url;
			Name = name;
			Image = image;
			Subscribe = subscribe;
		}

		public static IEnumerable<Channel> GetChannels()
		{
			string json;
			using (StreamReader stream = new("List Channels.json", Encoding.UTF8))
				json = stream.ReadToEnd();
			return JsonSerializer.Deserialize<List<Channel>>(json); ;
		}

		public static void AddChannel(string url)
		{
			IConfiguration config = Configuration.Default.WithDefaultLoader();
			var document = BrowsingContext.New(config).OpenAsync(url);
			var nameChannel = document.Result.QuerySelector("html body div div div div div span").TextContent;
			var image = document.Result.QuerySelector("html body div div div div div img").Attributes["src"].Value;
			var sub = document.Result.QuerySelector("html body div div div p a b").TextContent;
			Channel newChannel = new(url, $"https://invidious.namazso.eu{image}", sub, nameChannel);
			List<Channel> allChannel = (List<Channel>)GetChannels();
			allChannel.Add(newChannel);
			using StreamWriter stream = new("List Channels.json", false, Encoding.UTF8);
			stream.Write(JsonSerializer.Serialize(allChannel));
		}
	}
}