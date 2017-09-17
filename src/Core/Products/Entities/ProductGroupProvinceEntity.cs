using Core.SeedWork;

namespace Core.Products
{
    public class ProductGroupProvinceEntity : BaseEntity
    {
        public int ProductGroupId { get; set; }

        public ProductGroupEntity ProductGroup { get; set; }

        public int ProvinceId { get; set; }
    }
}