using MediatR;

namespace Core.Products
{
    public class ProductGroupTypeGetQuery : IRequest<ProductGroupTypeEntity>
    {
        public int ProductGroupTypeId { get; set; }
    }
}