using Core.SeedWork;
using System.Collections.Generic;

namespace Core.Products
{
    public class ProductGroupEntity : BaseEntity
    {
        public string Title { get; set; }

        public bool IsActive { get; set; }

        public byte[] Icon { get; set; }

        public int? ParentId { get; set; }

        public ProductGroupEntity Parent { get; set; }

        public int ProductGroupTypeId { get; set; }

        public ProductGroupTypeEntity ProductGroupType { get; set; }

        public ICollection<ProductGroupProvinceEntity> ProductGroupProvinces { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}