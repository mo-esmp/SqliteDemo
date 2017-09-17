using Core.Products;
using Core.Resources;
using Core.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductGroupTypeValidator : IProductGroupTypeValidator
    {
        private readonly IProductGroupTypeRepository _repository;

        public ProductGroupTypeValidator(IProductGroupTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> ValidateProductGroupTypeAsync(ProductGroupTypeEntity entity)
        {
            var errors = new List<ValidationResult>();
            if (await ValidateDuplicateTitleAsync(entity))
                errors.Add(string.Format(ErrorMessageResource.DuplicateItemError, DisplayNameResource.ProductGroupTypeTitle));

            return errors.Any() ? OperationResult.Failed(errors) : OperationResult.Success();
        }

        private async ValueTask<bool> ValidateDuplicateTitleAsync(ProductGroupTypeEntity typeEntity)
        {
            return await _repository.CheckProductGroupTypeExistByTitleAsync(typeEntity.Title, typeEntity.Id);
        }
    }
}