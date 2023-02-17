using AutoMapper;
using Solution.Data.Entities;
using Solution.Data.Models.CategoryModels;
using Solution.Data.Models.ProductModels;

namespace ECommerceAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
