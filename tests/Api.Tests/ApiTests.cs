using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory) => _client = factory.CreateClient();

    [Fact]
    public async Task Root_ReturnsOk()
    {
        var res = await _client.GetAsync("/");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        Assert.Contains("dotnet-example", await res.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Personas_ReturnsThreeItems()
    {
        var res = await _client.GetAsync("/personas");
        res.EnsureSuccessStatusCode();
        using var doc = JsonDocument.Parse(await res.Content.ReadAsStringAsync());
        Assert.Equal(3, doc.RootElement.GetArrayLength());
    }

    [Fact]
    public async Task Personas_AllowsCrossOriginRequests()
    {
        var req = new HttpRequestMessage(HttpMethod.Get, "/personas");
        req.Headers.Add("Origin", "http://localhost:8084");
        var res = await _client.SendAsync(req);
        Assert.True(res.Headers.Contains("Access-Control-Allow-Origin"));
    }
}