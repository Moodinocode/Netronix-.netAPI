using AutoMapper;
using Netronix.API.Models.Domains;
using Netronix.API.Models.DTOs;

namespace Netronix.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Tag, TagDtocs>().ReverseMap();
        }
    }
}
