using AutoMapper;
using BlazorEcomm_DATA;
using BlazorEcomm_DATA.ViewModel;
using BlazorEcomm_MODELS;

namespace BlazorEcomm_BUSINESS.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();
        CreateMap<OrderHeaderDTO, OrderHeader>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        CreateMap<OrderDTO, Order>().ReverseMap();
    }
}
