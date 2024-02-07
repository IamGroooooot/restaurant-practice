using Restaurant.RestApi.Tests;

namespace Restaurant.RestApi.tests;

public sealed class HomeTests
{
    [Test]
    public async Task ShouldReturnHelloWorld()
    {
        var app = new WebApplicationFactory<Startup>();
        var client = app.CreateClient();
        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content, Is.EqualTo("Hello World!"));
    }
}