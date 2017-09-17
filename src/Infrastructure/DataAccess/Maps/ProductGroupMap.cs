using Microsoft.EntityFrameworkCore;
using Core.Products;

namespace Infrastructure.DataAccess.Maps
{
    internal class ProductGroupMap : IEntityMap
    {
        public ProductGroupMap(ModelBuilder builder)
        {
            builder.Entity<ProductGroupEntity>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Title).HasMaxLength(50).IsRequired();
                b.Property(e => e.Icon).IsRequired();
                b.HasMany(c => c.Products)
                    .WithOne(e => e.ProductGroup)
                    .HasForeignKey(e => e.ProductGroupId)
                    //.IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}