using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductGroupTypeValidator
    /// </summary>
    /// <seealso cref="Core.SeedWork.IService" />
    public interface IProductGroupTypeValidator : IService
    {
        /// <summary>
        /// Validates the type of the product group.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>OperationResult.</returns>
        Task<OperationResult> ValidateProductGroupTypeAsync(ProductGroupTypeEntity entity);
    }
}