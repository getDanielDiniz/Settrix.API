using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json;
using ComunTestsUtilities.Builders;
using FluentAssertions;
using IntegrationTests.InlineData;
using IntegrationTests.Managers;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.Resources.User;

namespace IntegrationTests.User.DoLogin;

public class DoLoginIntegrationTest : IClassFixture<CustomWebApplicationFactory>
{
    private readonly string URI = "api/user/login";
    private readonly HttpClient _client;
    private UserEntityManager _employee { get;}
    
    public DoLoginIntegrationTest(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient(); 
        _employee = factory.User_Employee!;
    }

    [Fact]
    public async Task Login_Success()
    {
        var request = new RequestLoginCredentialsJson()
        {
            Password = _employee.GetUser.Password,
            Email = _employee.GetUser.Email
        };
        var jsonRequest = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonRequest,Encoding.UTF8,"application/json");
        
        var curlMessage = await _client.PostAsync(URI, content);
        var body = await curlMessage.Content.ReadAsStreamAsync();
        var response = await JsonDocument.ParseAsync(body);

        curlMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        response.RootElement.GetProperty("email").GetString().Should().Be(_employee.GetUser.Email);
        response.RootElement.GetProperty("token").GetString().Should().NotBeNullOrEmpty();
    }
    
    [Theory]
    [ClassData(typeof(CulturesInlineData))]
    public async Task Login_Error(string culture)
    {
        var request = RequestCredentialLoginBuilder.Build();
        request.Email = _employee.GetUser.Email;
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json,Encoding.UTF8,"application/json");
        _client.DefaultRequestHeaders.Add("Accept-Language", culture);
        
        var curlMessage = await _client.PostAsync(URI, content);
        var body = await curlMessage.Content.ReadAsStreamAsync();
        var response = await JsonDocument.ParseAsync(body);
        var message = UserResource.ResourceManager.GetString("INCORRECT_CREDENTIALS", new CultureInfo(culture));
        
        curlMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        response.RootElement.GetProperty("errors").EnumerateArray().Should().HaveCount(1);
        response.RootElement.GetProperty("errors").EnumerateArray().First().GetString().Should().Be(message);
    }
}