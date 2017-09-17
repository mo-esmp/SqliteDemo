using Core.SeedWork;
using MediatR;

namespace Core.Products
{
    public class ProductGroupAddCommand : IRequest<OperationResult>
    {
        public ProductGroupEntity ProductGroup { get; set; }
    }
}