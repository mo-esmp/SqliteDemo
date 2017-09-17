using MediatR;

namespace Core.Products
{
    public class ProductGroupGetQuery : IRequest<ProductGroupEntity>
    {
        public int ProductGroupId { get; set; }
    }
}