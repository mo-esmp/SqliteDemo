using Core.Products;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupTypeQueryHandler :
        IAsyncRequestHandler<ProductGroupTypeGetsQuery, IEnumerable<ProductGroupTypeEntity>>,
        IAsyncRequestHandler<ProductGroupTypeGetQuery, ProductGroupTypeEntity>
    {
        private readonly DataContext _context;

        public ProductGroupTypeQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductGroupTypeEntity>> Handle(ProductGroupTypeGetsQuery message)
        {
            return await _context.ProductGroupTypes.AsNoTracking().Where(a => a.IsActive).ToListAsync();
        }

        public async Task<ProductGroupTypeEntity> Handle(ProductGroupTypeGetQuery message)
        {
            return await _context.ProductGroupTypes.AsNoTracking().SingleOrDefaultAsync(a => a.Id == message.ProductGroupTypeId && a.IsActive);
        }
    }
}