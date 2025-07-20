using Microsoft.Extensions.Configuration;

namespace Settrix.Infraestructure.ExtensionMethods;

public static class EnvironmentVerificationExtensionMethod
{
    public static bool IsTestEnvironment(this IConfiguration configuration)
    {
        return bool.Parse(configuration["IntegrationTests"] ?? "false");
    }
}