using Core.Products;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupQueryHandler :
        IAsyncRequestHandler<ProductGroupGetsQuery, IEnumerable<ProductGroupEntity>>,
        IAsyncRequestHandler<ProductGroupGetQuery, ProductGroupEntity>
    {
        private readonly DataContext _context;

        public ProductGroupQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductGroupEntity>> Handle(ProductGroupGetsQuery message)
        {
            return await _context.ProductGroups.AsNoTracking().ToListAsync();
        }

        public async Task<ProductGroupEntity> Handle(ProductGroupGetQuery message)
        {
            return await _context.ProductGroups.AsNoTracking().SingleOrDefaultAsync(a => a.Id == message.ProductGroupId);
        }
    }
}