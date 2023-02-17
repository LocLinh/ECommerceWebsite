using AutoMapper;
using Solution.Data.Entities;
using Solution.Data.Models.ProductModels;

namespace ECommerceAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, LiteProductDto>()
                .ForMember(des => des.CategoryId, src => src.MapFrom(ent => ent.Category.Id));
            CreateMap<Product, DetailProductDto>()
                .ForMember(des => des.CategoryId, src => src.MapFrom(ent => ent.Category.Id))
                .ForMember(des => des.CategoryName, src => src.MapFrom(ent => ent.Category.Name));
        }
    }
}
