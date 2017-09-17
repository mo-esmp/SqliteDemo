using Core.Products;
using Core.Resources;
using Core.SeedWork;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _repository;
        private readonly IProductGroupValidator _validator;

        public ProductGroupService(IProductGroupValidator validator, IProductGroupRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<OperationResult> AddProductGroupAsync(ProductGroupEntity productGroup)
        {
            var validationResult = await _validator.ValidateProductGroupAsync(productGroup);

            if (!validationResult.Succeeded)
                return validationResult;

            _repository.AddProductGroup(productGroup);
            return validationResult;
        }

        public async Task<OperationResult> EditProductGroupAsync(ProductGroupEntity productGroup)
        {
            var validationResult = await _validator.ValidateProductGroupAsync(productGroup);

            if (!validationResult.Succeeded)
                return validationResult;

            var productGroupDbObject = await _repository.GetProductGroupByIdAsync(productGroup.Id);

            if (productGroupDbObject == null)
                return OperationResult.Failed(string.Format(ErrorMessageResource.ObjectNotFound, DisplayNameResource.ProductGroup));

            productGroupDbObject.Icon = productGroup.Icon;

            if (!await _repository.CheckHasProductsByIdAsync(productGroup.Id))
            {
                productGroupDbObject.Title = productGroup.Title;
                productGroupDbObject.IsActive = productGroup.IsActive;
                productGroupDbObject.ParentId = productGroup.ParentId;
                productGroupDbObject.ProductGroupTypeId = productGroup.ProductGroupTypeId;
                productGroupDbObject.ProductGroupProvinces = productGroup.ProductGroupProvinces;
            }

            await _repository.EditProductGroupAsync(productGroupDbObject);
            return OperationResult.Success();
        }

        public async Task<OperationResult> RemoveProductGroupAsync(int id)
        {
            var productGroupDbObject = await _repository.GetProductGroupByIdAsync(id);

            if (productGroupDbObject == null)
                return OperationResult.Failed(string.Format(ErrorMessageResource.ObjectNotFound, DisplayNameResource.ProductGroup));

            if (await _repository.CheckHasProductsByIdAsync(id))
            {
                return OperationResult.Failed(string.Format(ErrorMessageResource.ObjectRelationsDeleteError, DisplayNameResource.ProductGroup, DisplayNameResource.Product));
            }
            return _repository.RemoveProductGroup(productGroupDbObject);
        }
    }
}