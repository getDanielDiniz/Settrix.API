using AutoMapper;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Request.Company;
using Settrix.Comunication.DTO_s.Response;
using Settrix.Comunication.DTO_s.Response.Company;
using Settrix.Domain.Entities;

namespace Settrix.Application.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        //User mappers
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(u => u.Password, opt => opt.Ignore());
        
        //Company mappers
        CreateMap<RequestRegisterCompanyJson, Company>();
    }
    
    private void EntityToResponse()
    {
        //User mappers
        
        //Company mappers
        CreateMap<Company,ResponseCreatedCompanyJson>();
    }
}
