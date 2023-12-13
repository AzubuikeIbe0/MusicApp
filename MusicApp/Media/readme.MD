@foreach(MusicItem item in MediaTable  )
 <tfoot>
                            <@Pagination TotalPages="@(totalPages != 0 ? totalPages : 1)" PageIndex="@pageIndex" Radius="3" OnSelectedPage="SelectedPage">
                            </@Pagination>
                        </tfoot>
  protected override async Task OnInitializedAsync()
    {
        try
        {
            @* Media = await MusicService.GetMedia(); *@
            allMusic = await MusicService.GetMedia();
            ChartListData = await MusicService.GetChartList(); 
            // ArtistTopSongs = await MusicService.GetArtistTopSongs(); 
            if(allMusic != null)
            {
                totalPages = (int)(allMusic.Count() / itemsPerPage);

                MediaTable = allMusic.Skip(0).Take(itemsPerPage);
            }
        }
        catch (Exception e)
        {
            Error = e.Message;
        }

         private void SelectedPage(int selectedPageIndex)
        {
            if (allMusic != null)
            {
                pageIndex = selectedPageIndex;
                var skipCount = itemsPerPage * (pageIndex - 1);
                MediaTable = allMusic.Skip(skipCount).Take(itemsPerPage).ToList();
            }
        }
    }






    @page "/search"
@using MusicApp.Media
@inject SearchService searchService


<div class="searchbar">
    <input class="search-input" @bind="searchQuery" placeholder="search music" />
    <button class="search-button" @onclick="PerformSearch"><i class='bx bx-search'></i></button>
</div>


@if (searchResults != null)
{
    <ul>
    @foreach (var item in searchResults)
        {
            <li>@item.Title - @item.Subtitle</li>
        }
    </ul>
}

@code {
    private string searchQuery;
    private List<MusicItem> searchResults;

    private async Task PerformSearch()
    {
        searchResults = await searchService.Search(searchQuery);

       Console.WriteLine($"Search results: {System.Text.Json.JsonSerializer.Serialize(searchResults)}");
    }
}

<style>

.searchbar{
    display: grid;
}

.search-input {
    border: 1px solid #ccc;
    padding: 5px;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 20px;
    padding-left: 30px;
    font-size: 12px;
}


.search-button {
  background-color: transparent;
  color: #000;
  padding: 10px;
  cursor: pointer;
  border: none;
  position: absolute;
  align-self: start;
  justify-self: start;
  margin-top: -11px;
}

.search-button .bx {
  font-size: 16px;
}


</style>


@typeparam TEntity


@code 
{
    [Parameter]
    public List<TEntity> Items {get; set;}
    
    [Parameter]
    public EventCallback<string> OnSearch {get; set;}

    private string queryText;

    private async Task OnsearchClicked()
    {
        await OnSearch.InvokeAsync(queryText);
    }
}







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




