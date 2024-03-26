using AutoMapper;
using WebAPI.Data.Models;
using WebAPI.ModelsDTO;

namespace WebAPI.SnackShop.Configuration
{
    public class MapperInitialier : Profile
    {
        public MapperInitialier()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, DisplayProductDTO>().ReverseMap();
        }
    }
}
