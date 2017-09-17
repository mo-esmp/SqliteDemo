using MediatR;
using Core.SeedWork;

namespace Core.Products
{
    public class ProductGroupTypeEditCommand : IRequest<OperationResult>
    {
        public ProductGroupTypeEntity ProductGroupType { get; set; }
    }
}