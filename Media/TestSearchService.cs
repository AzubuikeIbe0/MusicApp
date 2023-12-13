using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MusicApp.Media;



namespace MusicApp.Media
{   
    [TestClass]
    public class SearchServiceTests
    {
        private SearchService _searchService;
        private HttpClient _httpClient;

        [TestInitialize]
        public void Setup()
        {
            _httpClient = new HttpClient(new TestHttpMessageHandler());
            _searchService = new SearchService(_httpClient);
        }

        [TestMethod]
        public async Task Search_ValidQuery_ReturnsMusicItems()
        {
           
            var mockResponse = new ApiResponse
            {
                Tracks = new System.Collections.Generic.List<MusicItem>
                {
                    new MusicItem { Title = "Song 1", Subtitle = "Subtitle 1", Type = "Type 1" },
                    new MusicItem { Title = "Song 2", Subtitle = "Subtitle 2", Type = "Type 2" },
                }
            };

       
            var testHandler = _httpClient.GetTestHttpMessageHandler();
            testHandler.Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockResponse))
            };

            var result = await _searchService.Search("your-query");

       
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
    }

    
    public class TestHttpMessageHandler : HttpMessageHandler
    {
        public HttpResponseMessage Response { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(Response);
        }
    }
}