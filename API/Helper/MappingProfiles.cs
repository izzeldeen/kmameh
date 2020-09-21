using API.Dtos;
using AutoMapper;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.CategoryArName, o => o.MapFrom(s => s.Category.ArName))
                .ForMember(d => d.CategryName, o => o.MapFrom(s => s.Category.Name))
            .ForMember(d => d.ProductPictures, o => o.MapFrom(s => s.ProductPictures))
            .ForMember(d => d.SupplierName, o => o.MapFrom(s => s.Supplier.SupplierName));

            CreateMap<User, UserWithPictuerDto>()
                .ForMember(d => d.PictuerUrl, o => o.MapFrom(s => s.Picture.URL));
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<RegisterDto, User>();
           
        }
    }
}
