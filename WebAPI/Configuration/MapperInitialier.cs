using AutoMapper;
using WebAPI.Data.Models;
using WebAPI.ModelsDTO;

namespace WebAPI.SnackShop.Configuration
{
    public class MapperInitialier : Profile
    {
        public MapperInitialier()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerDetailsDTO>().ReverseMap();
            CreateMap<CustomerDTO, CustomerDetailsDTO>().ReverseMap();
            //CreateMap<CustomerDTO, CustomerOrdersDTO>().ReverseMap();
            CreateMap<CustomerDetailsDTO, CreateCustomerDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, DisplayProductDTO>().ReverseMap();
        }
    }
}
