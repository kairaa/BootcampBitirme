using AutoMapper;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;

namespace Mvc.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
