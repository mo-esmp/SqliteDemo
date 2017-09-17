using Core.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Maps
{
    internal class ProductGroupTypeMap : IEntityMap
    {
        public ProductGroupTypeMap(ModelBuilder builder)
        {
            builder.Entity<ProductGroupTypeEntity>(a =>
            {
                a.Property(b => b.Title).HasMaxLength(50).IsRequired();
                a.Property(b => b.Icon).IsRequired();
                a.Property(b => b.SettingDescription).IsRequired(false);

                a.HasMany(c => c.ProductGroups)
                    .WithOne(e => e.ProductGroupType)
                    .HasForeignKey(e => e.ProductGroupTypeId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}