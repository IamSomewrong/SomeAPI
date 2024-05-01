using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace ApiTestProject
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {

        readonly HttpClient _client;

        public UnitTest1(WebApplicationFactory<Program> application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async void Test1()
        {
            var start = DateTime.UtcNow;
            var response = await _client.GetAsync("/Person");
            var end = DateTime.UtcNow;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Иван", content);
            Assert.True((end - start).TotalMilliseconds < 2000);
        }
    }
}