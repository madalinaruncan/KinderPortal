using API.DTOs;
using API.DTOs.Account;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<LoginDto, User>();

            CreateMap<Preschooler, PreschoolerGetDto>().ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group));
            CreateMap<Preschooler, PreschoolerUpdateDto>().ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId));
            CreateMap<PreschoolerUpdateDto, Preschooler>();
            CreateMap<PreschoolerCreateDto, Preschooler>();
            CreateMap<PreschoolerAttendanceDto, Preschooler>();

            CreateMap<Group, GroupGetDto>();
        }
    }
}
