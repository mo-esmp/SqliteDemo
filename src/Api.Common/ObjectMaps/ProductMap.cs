using AutoMapper;
using Core.Products;

namespace Api.Common.ObjectMaps
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<ProductGroupTypeEntity, ProductGroupTypeDto>();

            CreateMap<ProductGroupEntity, ProductGroupDto>();

            CreateMap<ProductEntity, ProductDto>();
        }
    }
}