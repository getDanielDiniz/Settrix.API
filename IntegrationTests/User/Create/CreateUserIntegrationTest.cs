using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json;
using CommunTestsUtilities;
using FluentAssertions;
using IntegrationTests.InlineData;
using Newtonsoft.Json;
using Settrix.Comunication.Resources.User;

namespace IntegrationTests.User.Create;

public class CreateUserIntegrationTest : CustomClassFixture
{
    
    private readonly string URI = "api/user/register";

    public CreateUserIntegrationTest(CustomWebApplicationFactory factory) : base(factory){}
    
    [Fact]
    public async Task CreateUser_Success()
    {
        var request = RequestRegisterUserBuilder.Build();
        
        var curlMessage = await DoPost(URI, request);
        var body = await curlMessage.Content.ReadAsStreamAsync();
        var response = await JsonDocument.ParseAsync(body);
        
        curlMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        response.RootElement.GetProperty("email").GetString().Should().Be(request.Email);
        response.RootElement.GetProperty("token").GetString().Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task CreateUser_Error()
    {
        var request = RequestRegisterUserBuilder.Build();
        request.Email = String.Empty;
        
        var curlMessage = await DoPost(URI, request);
        var body = await curlMessage.Content.ReadAsStreamAsync();
        var response = await JsonDocument.ParseAsync(body);
        
        curlMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.RootElement.GetProperty("errors").EnumerateArray().Should().HaveCount(1);
    }
    
    [Theory]
    [ClassData(typeof(CulturesInlineData))]
    public async Task CreateUser_CultureTesting(string culture)
    {
        var request = RequestRegisterUserBuilder.Build();
        request.Email = String.Empty;
        
        var curlMessage = await DoPost(url:URI, data:request, culture:culture);
        var body = curlMessage.Content.ReadAsStreamAsync().Result;
        var response = await JsonDocument.ParseAsync(body);
        var resource = UserResource.ResourceManager.GetString("EMPTY_EMAIL", CultureInfo.GetCultureInfo(culture));
        
        curlMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.RootElement.GetProperty("errors").EnumerateArray().Should().HaveCount(1);
        response.RootElement.GetProperty("errors").EnumerateArray().First().GetString().Should().Be(resource);

    }
}