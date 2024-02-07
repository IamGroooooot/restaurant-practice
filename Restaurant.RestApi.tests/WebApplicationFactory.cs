using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Restaurant.RestApi.Tests;

public class WebApplicationFactory<TStartup> : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TStartup> where TStartup : class
{
    protected override IWebHostBuilder CreateWebHostBuilder()
    {
        return new WebHostBuilder().UseStartup<TStartup>();
    }

    protected override TestServer CreateServer(IWebHostBuilder builder)
    {
        return new TestServer(builder);
    }

    public new HttpClient CreateClient()
    {
        var client = CreateClient(new WebApplicationFactoryClientOptions());
        client.BaseAddress = new Uri("http://localhost:5000");
        return client;
    }
}