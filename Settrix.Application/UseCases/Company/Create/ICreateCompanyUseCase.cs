using Settrix.Comunication.DTO_s.Request.Company;
using Settrix.Comunication.DTO_s.Response.Company;

namespace Settrix.Application.UseCases.Company.Create;

public interface ICreateCompanyUseCase
{
    Task<ResponseCreatedCompanyJson> Execute(RequestRegisterCompanyJson company);
}