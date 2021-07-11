using System;

namespace ITube.Model
{
	/// <summary>
	/// Канал
	/// </summary>
	public class Channel
	{
		public string Name { get; init; }
		public string Url { get; init; }

		public Channel(string url, string name = "")
		{
			if (!string.IsNullOrWhiteSpace(url))
			{
				Url = url;
				Name = name;
			}
			else
			{
				throw new ArgumentNullException();
			}
		}
	}
}