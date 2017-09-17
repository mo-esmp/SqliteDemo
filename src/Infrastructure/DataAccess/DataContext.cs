using Core.Products;
using Core.SeedWork;
using Infrastructure.DataAccess.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<ProductGroupEntity> ProductGroups { get; set; }

        public DbSet<ProductGroupProvinceEntity> ProductGroupProvinces { get; set; }

        public DbSet<ProductGroupTypeEntity> ProductGroupTypes { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added).ToList();

            foreach (var entry in entries)
                entry.Entity.CreateDate = DateTime.Now;

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added).ToList();

            foreach (var entry in entries)
                entry.Entity.CreateDate = DateTime.Now;

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.;Database=Sqlite;Integrated Security=True;MultipleActiveResultSets=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterMaps(builder);

            base.OnModelCreating(builder);
        }

        private void RegisterMaps(ModelBuilder builder)
        {
            var maps = typeof(DataContext).Assembly
                        .GetTypes()
                        .Where(type => !string.IsNullOrWhiteSpace(type.Namespace) && type.IsClass && typeof(IEntityMap).IsAssignableFrom(type)).ToList();

            foreach (var type in maps)
                Activator.CreateInstance(type, new object[] { builder });
        }
    }
}