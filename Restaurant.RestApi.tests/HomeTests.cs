using System.Net.Http.Headers;
using Restaurant.RestApi.Tests;

namespace Restaurant.RestApi.tests;

public sealed class HomeTests
{
    [Test]
    public async Task HomeReturnHelloWorld()
    {
        var app = new WebApplicationFactory<Startup>();
        var client = app.CreateClient();
        
        var response = await client.GetAsync("/");
        
        Assert.That(
            response.IsSuccessStatusCode, Is.True,
            $"Response status code is {response.StatusCode}");
    }
    
    [Test]
    public async Task HomeReturnHelloWorldWithJson()
    {
        var app = new WebApplicationFactory<Startup>();
        var client = app.CreateClient();
        
        using var request = new HttpRequestMessage(HttpMethod.Get, "/");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.SendAsync(request);
        Assert.Multiple(() =>
        {
            Assert.That(
                response.Content.Headers.ContentType?.MediaType,
                Is.EqualTo("application/json"));

            Assert.That(
                response.IsSuccessStatusCode, Is.True,
                $"Response status code is {response.StatusCode}");
        });
    }
}