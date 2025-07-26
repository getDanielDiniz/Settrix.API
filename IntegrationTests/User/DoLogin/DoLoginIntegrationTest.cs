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

public class DoLoginIntegrationTest : CustomClassFixture
{
    private readonly string URI = "api/user/login";
    private UserEntityManager _employee { get;}
    
    public DoLoginIntegrationTest(CustomWebApplicationFactory factory) : base(factory)
    {
        _employee = factory.User_Employee!;
    }

    [Fact]
    public async Task Login_Success()
    {
        var request = new RequestLoginCredentialsJson()
        {
            Password = _employee.GetNotHashedPassword,
            Email = _employee.GetUser.Email
        };
        var curlMessage = await DoPost(URI, request);
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
        
        var curlMessage = await DoPost(URI, request, culture: culture);
        var body = await curlMessage.Content.ReadAsStreamAsync();
        var response = await JsonDocument.ParseAsync(body);
        var message = UserResource.ResourceManager.GetString("INCORRECT_CREDENTIALS", new CultureInfo(culture));
        
        curlMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        response.RootElement.GetProperty("errors").EnumerateArray().Should().HaveCount(1);
        response.RootElement.GetProperty("errors").EnumerateArray().First().GetString().Should().Be(message);
    }
}