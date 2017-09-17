using Core.SeedWork;
using MediatR;

namespace Core.Products
{
    public class ProductGroupTypeAddCommand : IRequest<OperationResult>
    {
        public ProductGroupTypeEntity ProductGroupType { get; set; }
    }
}