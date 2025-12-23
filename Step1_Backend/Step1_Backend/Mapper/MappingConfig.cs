using AutoMapper;
using Step1_Backend.DTOs.AuthDTOs;
using Step1_Backend.Models;

namespace Step1_Backend.Mapper
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
        }
    }
}
