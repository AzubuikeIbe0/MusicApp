using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json; 
using System.Threading.Tasks;
using System.Text.Json;


namespace MusicApp.Media
{
    public class SearchService
    {
    private readonly HttpClient _httpClient;
    const string _baseUrl = "https://shazam.p.rapidapi.com";
    const string _searchEndpoint = "https://shazam.p.rapidapi.com/charts/track";

    public SearchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public class ApiResponse
    {
        public List<MusicItem> Tracks { get; set; }
    }


    public async Task<List<MusicItem>> Search(string query)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_searchEndpoint}?query={query}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"JSON Response: {jsonResponse}");

            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse?.Tracks ?? new List<MusicItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Search: {ex.Message}");
            return new List<MusicItem>(); // Return an empty list in case of an error
        }
    }


    }

}



