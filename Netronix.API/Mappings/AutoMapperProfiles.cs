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
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Product, AddProductRequestDto>().ReverseMap();
            CreateMap<Product, UpdateProductRequestDto>().ReverseMap();
            CreateMap<Tag,CreateTagDto>().ReverseMap();
            CreateMap<Tag,UpdateTagDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order,CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderRequestDto>().ReverseMap();
            CreateMap<CreateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<Adress, AdressDto>().ReverseMap();
            CreateMap<VariantOption,VariantOptionsDto>().ReverseMap();
            CreateMap<ProductVariant,VariantsDto>().ReverseMap();
            CreateMap<ProductTags, ProductTagDto>().ReverseMap();
            CreateMap<SelectedVariantOption, SelectedVariantsDto>().ReverseMap();
        
        
        }
    }
}
