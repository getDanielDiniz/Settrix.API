using AutoMapper;
using Settrix.Application.Mapping;

namespace CommonTestsUtilities;

public abstract class AutoMapperBuilder
{

    public static IMapper Build()
    {
        return new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile());}));
    }
    
}