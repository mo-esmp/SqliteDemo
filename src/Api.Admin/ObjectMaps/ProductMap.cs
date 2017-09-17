using Api.Admin.ViewModels;
using AutoMapper;
using Core.Products;
using System.Linq;

namespace Api.Admin.ObjectMaps
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<ProductGroupTypeAddViewModel, ProductGroupTypeEntity>();
            CreateMap<ProductGroupTypeEditViewModel, ProductGroupTypeEntity>();

            CreateMap<ProductGroupAddViewModel, ProductGroupEntity>()
                .ForMember(dest => dest.ProductGroupProvinces, opt => opt.ResolveUsing(src =>
                {
                    return src.Provinces.Select(provinceId => new ProductGroupProvinceEntity { ProvinceId = provinceId });
                }));
            CreateMap<ProductGroupEditViewModel, ProductGroupEntity>()
                .ForMember(dest => dest.ProductGroupProvinces, opt => opt.ResolveUsing(src =>
                {
                    return src.Provinces.Select(provinceId => new ProductGroupProvinceEntity { ProvinceId = provinceId });
                }));
        }
    }
}