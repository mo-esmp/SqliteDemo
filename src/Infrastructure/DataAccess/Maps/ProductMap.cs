using Microsoft.EntityFrameworkCore;
using Core.Products;

namespace Infrastructure.DataAccess.Maps
{
    internal class ProductMap : IEntityMap
    {
        public ProductMap(ModelBuilder builder)
        {
            builder.Entity<ProductEntity>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Title).HasMaxLength(50).IsRequired();
                b.Property(e => e.Icon).IsRequired();
                b.Property(e => e.Priority).IsRequired();
                b.Property(e => e.ProductGroupId).IsRequired();
            });
        }
    }
}