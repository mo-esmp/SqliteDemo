using Core.SeedWork;
using MediatR;

namespace Core.Products
{
    public class ProductGroupRemoveCommand : IRequest<OperationResult>
    {
        //public ProductGroupEntity ProductGroup { get; set; }
        public int ProductGroupId { get; set; }
    }
}