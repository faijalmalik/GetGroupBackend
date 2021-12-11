using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Employee, EmployeReadDto>();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeReadDto, EmployeePublishedDto>();
            CreateMap<Employee, GrpcPlatformModel>()
                .ForMember(dest => dest.PlatformId, opt => opt.MapFrom(src =>src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>src.Name))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src =>src.Company));
        }
    }
}