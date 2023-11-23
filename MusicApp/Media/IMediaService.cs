using System;

namespace MusicApp.Media
{
	public interface IMediaService
	{
		Task<List<MusicItem>> GetMedia();
	}
}

