using Core.Products;
using Core.Resources;
using Core.SeedWork;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupTypeService : IProductGroupTypeService
    {
        private readonly IProductGroupTypeValidator _validator;
        private readonly IProductGroupTypeRepository _repository;

        public ProductGroupTypeService(IProductGroupTypeValidator validator, IProductGroupTypeRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<OperationResult> AddProductGroupTypeAsync(ProductGroupTypeEntity entity)
        {
            var validationResult = await _validator.ValidateProductGroupTypeAsync(entity);

            return validationResult;
        }

        public async Task<OperationResult> EditProductGroupTypeAsync(ProductGroupTypeEntity entity)
        {
            var validationResult = await _validator.ValidateProductGroupTypeAsync(entity);

            if (!validationResult.Succeeded)
                return validationResult;

            var productTypeDb = await _repository.GetProductGroupTypeByIdAsync(entity.Id);

            if (productTypeDb == null)
                return OperationResult.Failed(string.Format(ErrorMessageResource.ObjectNotFound, DisplayNameResource.ProductGroupType));

            productTypeDb.Title = entity.Title;
            productTypeDb.IsActive = entity.IsActive;
            productTypeDb.Icon = entity.Icon;

            return validationResult;
        }

        public async Task<OperationResult> RemoveProductGroupTypeAsync(int productGroupTypeId)
        {
            if (await _repository.CheckHasChildByIdAsync(productGroupTypeId))
                return OperationResult.Failed(
                    string.Format(ErrorMessageResource.ObjectRelationsDeleteError, DisplayNameResource.ProductGroupType, DisplayNameResource.ProductGroup));

            var productTypeDb = await _repository.GetProductGroupTypeByIdAsync(productGroupTypeId);

            if (productTypeDb == null)
                return OperationResult.Failed(string.Format(ErrorMessageResource.ObjectNotFound, DisplayNameResource.ProductGroupType));

            _repository.RemoveProductGroupType(productTypeDb);

            return OperationResult.Success();
        }
    }
}