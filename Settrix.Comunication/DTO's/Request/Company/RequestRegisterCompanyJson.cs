using Settrix.Domain.Types;

namespace Settrix.Comunication.DTO_s.Request.Company;

public class RequestRegisterCompanyJson
{
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public CompanyFunctionType Function { get; set; } = CompanyFunctionType.Requester;
}