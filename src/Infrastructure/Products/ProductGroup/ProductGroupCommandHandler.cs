using MediatR;
using Core.Products;
using Core.SeedWork;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupCommandHandler :
        IAsyncRequestHandler<ProductGroupAddCommand, OperationResult>,
        IAsyncRequestHandler<ProductGroupEditCommand, OperationResult>,
        IAsyncRequestHandler<ProductGroupRemoveCommand, OperationResult>
    {
        private readonly IProductGroupService _service;
        private readonly IProductGroupRepository _repository;

        public ProductGroupCommandHandler(IProductGroupService service, IProductGroupRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ProductGroupAddCommand message)
        {
            return await _service.AddProductGroupAsync(message.ProductGroup);
        }

        public async Task<OperationResult> Handle(ProductGroupEditCommand message)
        {
            return await _service.EditProductGroupAsync(message.ProductGroup);
        }

        public async Task<OperationResult> Handle(ProductGroupRemoveCommand message)
        {
            return await _service.RemoveProductGroupAsync(message.ProductGroupId);
        }
    }
}