using Core.SeedWork;

namespace Core.Products
{
    public class ProductEntity : BaseEntity
    {
        public string Title { get; set; }

        public byte[] Icon { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public int ProductGroupId { get; set; }

        public ProductGroupEntity ProductGroup { get; set; }
    }
}