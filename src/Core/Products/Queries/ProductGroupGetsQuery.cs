using MediatR;
using System.Collections.Generic;

namespace Core.Products
{
    public class ProductGroupGetsQuery : IRequest<IEnumerable<ProductGroupEntity>>
    {
    }
}