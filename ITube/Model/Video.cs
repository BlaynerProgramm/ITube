using System;

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
	}
}