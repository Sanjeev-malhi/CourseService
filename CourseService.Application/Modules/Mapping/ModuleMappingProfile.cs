using AutoMapper;
using CourseService.Application.Modules.DTOs;

namespace CourseService.Application.Modules.Mapping
{
    public class ModuleMappingProfile : Profile
    {
        public ModuleMappingProfile()
        {
            CreateMap<Domain.Entites.Modules, ModuleDto>()
                .ReverseMap();
        }
    }
}
