using Core.SeedWork;
using MediatR;

namespace Core.Products
{
    public class ProductGroupEditCommand : IRequest<OperationResult>
    {
        public ProductGroupEntity ProductGroup { get; set; }
    }
}