using System;

namespace ITube.Model
{
	public class Video
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Image { get; set; }
		public string Time { get; set; }

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
