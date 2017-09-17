using MediatR;
using Core.Products;
using Core.SeedWork;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupTypeCommandHandler :
        IAsyncRequestHandler<ProductGroupTypeAddCommand, OperationResult>,
        IAsyncRequestHandler<ProductGroupTypeEditCommand, OperationResult>,
        IAsyncRequestHandler<ProductGroupTypeRemoveCommand, OperationResult>
    {
        private readonly IProductGroupTypeRepository _repository;
        private readonly IProductGroupTypeService _service;

        public ProductGroupTypeCommandHandler(IProductGroupTypeRepository repository, IProductGroupTypeService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(ProductGroupTypeAddCommand message)
        {
            var result = await _service.AddProductGroupTypeAsync(message.ProductGroupType);

            if (result.Succeeded)
                _repository.AddProductGroupType(message.ProductGroupType);

            return result;
        }

        public async Task<OperationResult> Handle(ProductGroupTypeEditCommand message)
        {
            return await _service.EditProductGroupTypeAsync(message.ProductGroupType);
        }

        public async Task<OperationResult> Handle(ProductGroupTypeRemoveCommand message)
        {
            return await _service.RemoveProductGroupTypeAsync(message.ProductGroupTypeId);
        }
    }
}