using AngleSharp;

using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ITube.Model
{
	/// <summary>
	/// Канал
	/// </summary>
	public class Channel : INotifyPropertyChanged
	{
		string _name;
		string _image;
		string _subscribe;
		string _url;
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}
		public string Image
		{
			get => _image;
			set
			{
				_image = value;
				OnPropertyChanged("Image");
			}
		}
		public string Subscribe
		{
			get => _subscribe;
			set
			{
				_subscribe = value;
				OnPropertyChanged("Subscribe");
			}
		}
		public string Url
		{
			get => _url;
			set
			{
				_url = value;
				OnPropertyChanged("Url");
			}
		}

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

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName) =>
	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}