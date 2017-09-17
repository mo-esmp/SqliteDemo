using Core.Products;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class DataContextSeed
    {
        private readonly DataContext _context;

        public DataContextSeed(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.ProductGroupTypes.AnyAsync())
            {
                await _context.ProductGroupTypes.AddAsync(
                    new ProductGroupTypeEntity
                    {
                        Title = "Test",
                        IsActive = true,
                        Icon = GetIconBinary(),
                        ProductGroups = new[]
                        {
                            new ProductGroupEntity
                            {
                                Title = "Test 1",
                                IsActive = true,
                                Icon = GetIconBinary(),
                            },
                            new ProductGroupEntity
                            {
                                Title = "Test 2",
                                IsActive = true,
                                Icon = GetIconBinary(),
                            }
                        }
                    }
                );
            }

            await _context.SaveChangesAsync();
        }

        private byte[] GetIconBinary()
        {
            string path;
            try
            {
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.GetDirectories("Resources")[0].FullName;
            }
            catch
            {
                path = Directory.GetDirectories(Directory.GetCurrentDirectory(), "Resources")[0];
            }

            return File.ReadAllBytes($"{path}/Domain.png");
        }
    }
}