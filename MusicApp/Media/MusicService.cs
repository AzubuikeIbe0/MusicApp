using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicApp.Media
{
    public class MusicService : IMediaService
    {
        private readonly HttpClient _httpClient;
        const string _baseUrl = "https://shazam.p.rapidapi.com";
        const string _mediaEndpoint = "https://shazam.p.rapidapi.com/charts/track";
        const string _host = "shazam.p.rapidapi.com";
        const string _key = "5670401c68msh467aa30dbbb72aep156bfcjsn7f7e8014b596"; 

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

        public async Task<List<MusicItem>> GetMusicItems()
        {
            var res = await _httpClient.GetAsync(_mediaEndpoint);
            res.EnsureSuccessStatusCode();

            using var stream = await res.Content.ReadAsStreamAsync();

            var dataItems = await JsonSerializer.DeserializeAsync<MediaData>(stream);

            var musicItems = dataItems.tracks.Select(track => new MusicItem
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
                }
            }).ToList();

            return musicItems;
        }

        public async Task<List<MusicItem>> GetMedia()
        {
            var res = await _httpClient.GetAsync(_mediaEndpoint); 
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
                }
            }).ToList();

            return mediaItems;
        }
    }
}
