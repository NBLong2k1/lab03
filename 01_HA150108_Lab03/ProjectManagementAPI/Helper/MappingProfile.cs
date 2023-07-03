using AutoMapper;
using BusinessObjects.Models.Entities;
using ProductManagementAPI.DTO;

namespace ProductManagementAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
