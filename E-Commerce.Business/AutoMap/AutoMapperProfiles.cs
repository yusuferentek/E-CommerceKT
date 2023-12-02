using AutoMapper;
using E_Commerce.Business.Dtos;
using E_Commerce.Shared.Models;
using static E_Commerce.Business.Dtos.ProductDto;

namespace E_Commerce.Business.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>();
            
            CreateMap<Product, ProductDto>().ForMember(c => c.CategoryName, opt => opt.MapFrom(x => x.Category.CategoryName));
            CreateMap<ProductDto, Product>();
        }
    }
}
