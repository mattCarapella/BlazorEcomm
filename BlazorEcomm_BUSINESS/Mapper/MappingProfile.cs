using AutoMapper;
using BlazorEcomm_DATA;
using BlazorEcomm_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomm_BUSINESS.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();

        CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();

    }
}
