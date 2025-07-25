using AutoMapper;
using FluentValidation.Results;
using Settrix.Application.Validators.Company;
using Settrix.Comunication.DTO_s.Request.Company;
using Settrix.Comunication.DTO_s.Response.Company;
using Settrix.Comunication.Resources.Company;
using Settrix.Domain.Repositories.Company;
using Settrix.Domain.Services.LoggedUser;
using Settrix.Exception.BaseExceptions;

namespace Settrix.Application.UseCases.Company.Create;

public class CreateCompanyUseCase : ICreateCompanyUseCase
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyCompanyRepository _readRepository;
    private readonly IWriteOnlyCompanyRepository _writeRepository;
    private readonly ILoggedUserProvider _loggedUser;
    
    public CreateCompanyUseCase(
        IMapper mapper,
        IReadOnlyCompanyRepository readRepository,
        IWriteOnlyCompanyRepository writeRepository,
        ILoggedUserProvider loggedUser
        )
    {
        _mapper = mapper;
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _loggedUser = loggedUser;
    }
    
    public async Task<ResponseCreatedCompanyJson> Execute(RequestRegisterCompanyJson company)
    {
        await Validate(company);
        
        var companyEntity = _mapper.Map<Domain.Entities.Company>(company);
        companyEntity.CreatedAt = DateTime.UtcNow;
        companyEntity.CreatedBy = _loggedUser.Get().Id;
        
        await _writeRepository.CreateCompany(companyEntity);
        
        var response = _mapper.Map<ResponseCreatedCompanyJson>(companyEntity);
        
        return response;
    }
    
    private async Task  Validate(RequestRegisterCompanyJson company)
    {
        var validator = new CreateCompanyValidator();
        var result = validator.Validate(company);
        var isCnpjExists = await _readRepository.GetByCNPJ(company.Cnpj);
        
        if(isCnpjExists) 
            result.Errors.Add(
                new ValidationFailure("ErrorMessage",CompanyResource.CNPJ_ALREADY_USED)
            );
        
        if (result.IsValid is false || isCnpjExists)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnRequestValidation(errors);
        }
    }
}