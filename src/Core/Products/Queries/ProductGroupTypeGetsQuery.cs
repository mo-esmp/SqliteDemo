using MediatR;
using System.Collections.Generic;

namespace Core.Products
{
    public class ProductGroupTypeGetsQuery : IRequest<IEnumerable<ProductGroupTypeEntity>>
    {
    }
}