using Bogus;
using Bogus.Extensions.Brazil;
using Settrix.Comunication.DTO_s.Request.Company;
using Settrix.Domain.Types;

namespace CommonTestsUtilities.Company;

public static class RequestRegisterCompanyBuilder
{
    
    public static RequestRegisterCompanyJson Build()
    {
        return new Faker<RequestRegisterCompanyJson>()
            .RuleFor(rc => rc.Name, f => f.Company.CompanyName())
            .RuleFor(rc => rc.Cnpj, f => f.Company.Cnpj())
            .RuleFor(rc => rc.Function, f => f.PickRandom<CompanyFunctionType>());
    }
}