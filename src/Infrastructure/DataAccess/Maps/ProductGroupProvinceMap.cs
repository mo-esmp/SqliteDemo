using Core.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Maps
{
    internal class ProductGroupProvinceMap : IEntityMap
    {
        public ProductGroupProvinceMap(ModelBuilder builder)
        {
            builder.Entity<ProductGroupProvinceEntity>(b =>
            {
                //b.HasKey(e => e.Id);
                b.HasKey(bc => new { bc.ProvinceId, bc.ProductGroupId });

                b.HasOne(bc => bc.ProductGroup)
                    .WithMany(bc => bc.ProductGroupProvinces)
                    .HasForeignKey(bc => bc.ProductGroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}