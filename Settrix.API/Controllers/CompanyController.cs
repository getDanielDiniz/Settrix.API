using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Settrix.Application.Types;
using Settrix.Application.UseCases.Company.Create;
using Settrix.Comunication.DTO_s.Request.Company;

namespace Settrix.API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CompanyController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create_Company(
        [FromBody]RequestRegisterCompanyJson company,
        [FromServices]ICreateCompanyUseCase useCase
    )
    {
        var response = await useCase.Execute(company);
        return Created(String.Empty, response);
    }
}