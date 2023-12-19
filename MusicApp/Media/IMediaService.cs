using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Media
{
    public interface IMediaService
    {
        Task<List<MusicItem>> GetMedia();
        Task<List<MusicItem>> Search(string query); 
        Task<ChartList> GetChartList();
    }
}
