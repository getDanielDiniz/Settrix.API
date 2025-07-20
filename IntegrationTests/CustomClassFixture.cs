using System.Text;
using System.Text.Json;

namespace IntegrationTests;

public class CustomClassFixture : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CustomClassFixture(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    protected async Task<HttpResponseMessage> DoPost(
        string url,
        object data,
        string token = "",
        string culture = ""
        )
    {
        Authenticate(token);
        Internationalization(culture);
        var jsonEncoded = JsonRequestToStringContent(data);
        
        return await _client.PostAsync(url, jsonEncoded);
    }

    private void Authenticate(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return;
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }
    private void Internationalization(string culture)
    {
        if (string.IsNullOrWhiteSpace(culture)) return;
        _client.DefaultRequestHeaders.Add("Accept-Language", culture);
    }
    private StringContent JsonRequestToStringContent(object data)
    {
        var json = JsonSerializer.Serialize(data);
        return new StringContent(json, Encoding.UTF8, "application/json");;
    }
}