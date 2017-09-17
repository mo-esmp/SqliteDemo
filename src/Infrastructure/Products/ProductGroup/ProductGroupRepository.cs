using Microsoft.EntityFrameworkCore;
using Core.Products;
using Core.SeedWork;
using Infrastructure.DataAccess;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly DataContext _context;

        public ProductGroupRepository(DataContext context)
        {
            _context = context;
        }

        public void AddProductGroup(ProductGroupEntity productGroup)
        {
            _context.Add(productGroup);
        }

        public async ValueTask<bool> CheckProductGroupExistByTitleAsync(int groupTypeId, string title)
        {
            return await _context.ProductGroups.AnyAsync(pg => pg.ProductGroupTypeId == groupTypeId && pg.Title == title);
        }

        public async Task<OperationResult> EditProductGroupAsync(ProductGroupEntity productGroup)
        {
            ProductGroupEntity productdGroupDbObj = await GetProductGroupByIdAsync(productGroup.Id);

            var prop = _context.Entry(productdGroupDbObj);
            prop.CurrentValues.SetValues(productGroup);

            return OperationResult.Success();
        }

        public async Task<ProductGroupEntity> GetProductGroupByIdAsync(int id)
        {
            return await _context.ProductGroups.FindAsync(id);
        }

        public OperationResult RemoveProductGroup(ProductGroupEntity productGroup)
        {
            //ProductGroupEntity productGroupDb = await GetProductGroupByIdAsync(productGroup.Id);
            // _context.ProductGroupProvinces.RemoveRange(productGroup.ProductGroupProvinces);
            _context.Remove(productGroup);
            return OperationResult.Success();
        }

        public async Task<int> GetProductsCountByProductGroupIdAsync(int productGroupId)
        {
            return await _context.Products.CountAsync(p => p.ProductGroupId == productGroupId);
        }

        public async ValueTask<bool> CheckHasProductsByIdAsync(int productGroupId)
        {
            return await _context.Products.AnyAsync(p => p.ProductGroupId == productGroupId);
        }
    }
}