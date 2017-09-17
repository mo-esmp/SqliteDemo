using Core.Products;
using Core.Resources;
using Core.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupValidator : IProductGroupValidator
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public async Task<OperationResult> ValidateProductGroupAsync(ProductGroupEntity productGroup)
        {
            var errors = new List<ValidationResult>();

            if (productGroup.ProductGroupProvinces == null || !productGroup.ProductGroupProvinces.Any())
                errors.Add(string.Format(ErrorMessageResource.NoObjectHasSelected, DisplayNameResource.Province));

            if (await ValidateDuplicateTitleAsync(productGroup.ProductGroupTypeId, productGroup.Title))
                errors.Add(string.Format(ErrorMessageResource.DuplicateItemError, DisplayNameResource.ProductGroupTitle));

            return errors.Any() ? OperationResult.Failed(errors) : OperationResult.Success();
        }

        private async ValueTask<bool> ValidateDuplicateTitleAsync(int productGroupTypeId, string title)
        {
            return await _productGroupRepository.CheckProductGroupExistByTitleAsync(productGroupTypeId, title);
        }
    }
}