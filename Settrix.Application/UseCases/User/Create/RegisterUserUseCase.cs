using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Settrix.Application.Validators;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Response;
using Settrix.Comunication.Resources.User;
using UserEnt = Settrix.Domain.Entities.User;
using Settrix.Domain.Repositories;
using Settrix.Domain.Security.Authentication;
using Settrix.Domain.Security.Criptography;
using Settrix.Domain.Services.LoggedUser;
using Settrix.Exception.BaseExceptions;

namespace Settrix.Application.UseCases.User.Create;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IWriteOnlyUserRepository _writeOnlyRepository;
    private readonly IReadOnlyUserRepository _readOnlyRepository;
    private readonly ICriptographyHanddle _criptographyHanddle;
    private readonly IMapper _mapper;
    private readonly ILogginUser _logginUser;
    private readonly ILoggedUserProvider _loggedUserProvider;
    
    public RegisterUserUseCase(IWriteOnlyUserRepository writeOnlyRepository,
        IMapper mapper,
        ICriptographyHanddle criptographyHanddle,
        ILogginUser logginUser,
        IReadOnlyUserRepository readOnlyRepository,
        ILoggedUserProvider loggedUserProvider)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _mapper = mapper;
        _criptographyHanddle = criptographyHanddle;
        _logginUser = logginUser;
        _readOnlyRepository = readOnlyRepository;
        _loggedUserProvider = loggedUserProvider;
    }
    public async Task<ResponseLoggedUserJson> Execute(RequestRegisterUserJson newUser)
    {
        await ValidateRequest(newUser);
        var loggedUser = await _loggedUserProvider.Get();
        
        UserEnt user = new() {
            CreatedBy = loggedUser.Id,
            CompanyId = loggedUser.CompanyId,
            CreatedAt = DateTime.UtcNow,
            SecurityId = Guid.NewGuid(),
            Password = _criptographyHanddle.HashPassword(newUser.Password),
        };

        _mapper.Map(newUser,user);
        await _writeOnlyRepository.CreateUser(user);
        var token = _logginUser.Generate(user);

        return new ResponseLoggedUserJson()
        {
            Email = newUser.Email,
            Token = token,
        };
    }
    
    private async Task ValidateRequest(RequestRegisterUserJson newUser)
    {
        //Request Validation
        RequestNewUserValidator validator = new();
        
        var result = validator.Validate(newUser);
        
        var responseMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

        if (result.IsValid == false)
        {
            throw new ErrorOnUserValidation(responseMessages);
        }
        
        var usedEmail = await _readOnlyRepository.EmailAlreadyExists(newUser.Email);

        if (usedEmail is true)
        {
            throw new ErrorEmailAlreadyInUse(UserResource.USED_EMAIL);
        }
    }
}
