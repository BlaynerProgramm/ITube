using System;

namespace ITube.Model
{
	public class Video
	{
		public string Name { get; set; }
		public string Url { get; set; }

		public Video(string name, string url)
		{
			if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(url))
			{
				Name = name;
				Url = url;
			}
			else
			{
				throw new ArgumentNullException();
			}
		}
	}
}
