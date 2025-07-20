using AutoMapper;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Response;
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
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(u => u.Password, opt => opt.Ignore());
    }
    
    private void EntityToResponse()
    {
        
    }
}
