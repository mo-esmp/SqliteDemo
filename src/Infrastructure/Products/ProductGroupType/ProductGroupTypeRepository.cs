using Core.Products;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupTypeRepository : IProductGroupTypeRepository
    {
        private readonly DataContext _context;

        public ProductGroupTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void AddProductGroupType(ProductGroupTypeEntity entity)
        {
            _context.Add(entity);
        }

        public async ValueTask<bool> CheckProductGroupTypeExistByTitleAsync(string title)
        {
            return await _context.ProductGroupTypes.AnyAsync(a => a.Title == title);
        }

        public async ValueTask<bool> CheckProductGroupTypeExistByTitleAsync(string title, int productId)
        {
            return await _context.ProductGroupTypes.AnyAsync(a => a.Title == title && a.Id != productId);
        }

        public void EditProductGroupType(ProductGroupTypeEntity entity)
        {
            _context.ProductGroupTypes.Update(entity);
        }

        public async Task<ProductGroupTypeEntity> GetProductGroupTypeByIdAsync(int id)
        {
            return await _context.ProductGroupTypes.FindAsync(id);
        }

        public void RemoveProductGroupType(ProductGroupTypeEntity entity)
        {
            _context.ProductGroupTypes.Remove(entity);
        }

        public async ValueTask<bool> CheckHasChildByIdAsync(int productTypeId)
        {
            return await _context.ProductGroups.AnyAsync(b => b.ProductGroupTypeId == productTypeId);
        }
    }
}