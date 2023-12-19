using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicApp.Media
{
    public class MusicService : IMediaService
    {
        private readonly HttpClient _httpClient;
        private const string _baseUrl = "https://shazam.p.rapidapi.com";
        private const string _host = "shazam.p.rapidapi.com";
        private const string _key = "5670401c68msh467aa30dbbb72aep156bfcjsn7f7e8014b596";
        const string _artistEndpoint = "https://shazam.p.rapidapi.com/artists/get-top-songs";
        const string _chartTrackEndpoint = "https://shazam.p.rapidapi.com/charts/track";
        const string _chartListEndpoint = "https://shazam.p.rapidapi.com/charts/list";

        public MusicService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri(_baseUrl);
            HttpClientConfig();
        }

        private void HttpClientConfig()
        {
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
        }

        public async Task<List<MusicItem>> GetMedia()
        {
            var res = await _httpClient.GetAsync(_chartTrackEndpoint);
            res.EnsureSuccessStatusCode();

            using var stream = await res.Content.ReadAsStreamAsync();

            var dataItems = await JsonSerializer.DeserializeAsync<MediaData>(stream);

            var mediaItems = dataItems.tracks.Select(track => new MusicItem
            {
                Type = track.type,
                Title = track.title,
                Subtitle = track.subtitle,
                Images = new Images
                {
                    background = track.images.background,
                    coverart = track.images.coverart,
                    coverarthq = track.images.coverarthq,
                    joecolor = track.images.joecolor
                },
                MusicUri = track.hub?.actions?.FirstOrDefault(action => action.type == "uri")?.uri
            }).ToList();

            return mediaItems;
        }

        public async Task<ChartList> GetChartList()
        {
            var res = await _httpClient.GetAsync(_chartListEndpoint);
            res.EnsureSuccessStatusCode();

            using var stream = await res.Content.ReadAsStreamAsync();

            var chartList = await JsonSerializer.DeserializeAsync<ChartList>(stream);

            return chartList;
        }

     
        public async Task<List<MusicItem>> Search(string query)
    {
        try
        {
            // Get the list of media items using GetMedia method
            var mediaItems = await GetMedia();

            // Filter the media items based on the search query
            var searchResults = mediaItems
                .Where(item => item.Title.ToLower().Contains(query?.ToLower() ?? ""))
                .ToList();

            return searchResults;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Search: {ex.Message}");
            return new List<MusicItem>();
        }
    }
    }
}
