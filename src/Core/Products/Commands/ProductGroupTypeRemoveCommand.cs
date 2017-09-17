using MediatR;
using Core.SeedWork;

namespace Core.Products
{
    public class ProductGroupTypeRemoveCommand : IRequest<OperationResult>
    {
        // public ProductGroupTypeEntity ProductGroupTypeEntity { get; set; }

        public int ProductGroupTypeId { get; set; }
    }
}