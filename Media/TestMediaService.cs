using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;



namespace MusicApp.Media
{
    [TestClass]

       public class TestableHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpResponseMessage _responseMessage;

    public TestableHttpMessageHandler(HttpResponseMessage responseMessage)
    {
        _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_responseMessage);
    }
}

// Then, in your test class:
[TestClass]
public class MServiceTests
{
    private MusicService _musicService;
    private HttpClient _httpClient;

    [TestInitialize]
    public void Setup()
    {
        var mockResponse = new MediaData
        {
            tracks = new[]
            {
                new Track { title = "Song 1", subtitle = "Subtitle 1", type = "Type 1", images = new Images { background = "Background 1", coverart = "Coverart 1", coverarthq = "Coverarthq 1", joecolor = "Joecolor 1" } },
                new Track { title = "Song 2", subtitle = "Subtitle 2", type = "Type 2", images = new Images { background = "Background 2", coverart = "Coverart 2", coverarthq = "Coverarthq 2", joecolor = "Joecolor 2" } }
            }
        };

        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
        httpResponseMessage.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockResponse));

        var testableHandler = new TestableHttpMessageHandler(httpResponseMessage);
        _httpClient = new HttpClient(testableHandler);
        _musicService = new MusicService(_httpClient);
    }

    [TestMethod]
    public async Task GetMedia_SuccessfulRequest_ReturnsMediaItems()
    {
        var result = await _musicService.GetMedia();

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
    }
}


    }


