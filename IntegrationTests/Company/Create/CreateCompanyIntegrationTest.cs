using System.Net;
using System.Text.Json;
using CommonTestsUtilities.Company;
using FluentAssertions;
using IntegrationTests.InlineData;
using Settrix.Comunication.Resources.Company;

namespace IntegrationTests.Company.Create;

public class CreateCompanyIntegrationTest : CustomClassFixture
{
    private readonly string _token;
    private readonly string URI = "/api/company";

    public CreateCompanyIntegrationTest(CustomWebApplicationFactory factory) : base(factory)
    {
        _token = factory.User_Employee!.GetToken;
    }

    [Fact]
    public async Task CreateCompany()
    {
        var company = RequestRegisterCompanyBuilder.Build();
        
        var act = await DoPost(URI, company, _token);
        var result = await act.Content.ReadAsStreamAsync();
        var responseBody = await JsonDocument.ParseAsync(result);

        act.StatusCode.Should().Be(HttpStatusCode.Created);
        responseBody.RootElement.GetProperty("name").GetString().Should().Be(company.Name);
        responseBody.RootElement.GetProperty("id").GetInt32().Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task CreateCompany_Error()
    {
        var company = RequestRegisterCompanyBuilder.Build();
        company.Cnpj = String.Empty;
        
        var act = await DoPost(URI, company, _token);
        var result = await act.Content.ReadAsStreamAsync();
        var responseBody = await JsonDocument.ParseAsync(result);
        
        act.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseBody.RootElement.GetProperty("errors")
            .EnumerateArray().Should().HaveCount(1)
            .And.ContainSingle(CompanyResource.INVALID_CNPJ);
    }
    
    [Theory]
    [ClassData(typeof(CulturesInlineData))]
    public async Task CreateCompany_CultureTesting(string culture)
    {
        var company = RequestRegisterCompanyBuilder.Build();
        company.Cnpj = String.Empty;
        
        var act = await DoPost(URI, company, _token, culture);
        var result = await act.Content.ReadAsStreamAsync();
        var responseBody = await JsonDocument.ParseAsync(result);
        
        act.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseBody.RootElement.GetProperty("errors")
            .EnumerateArray().Should().HaveCount(1)
            .And.ContainSingle(CompanyResource.INVALID_CNPJ);
    }
}