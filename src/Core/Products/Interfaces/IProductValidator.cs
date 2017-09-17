using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductValidator
    /// </summary>
    /// <seealso cref="Core.SeedWork.IService" />
    public interface IProductValidator : IService
    {
        /// <summary>
        /// Validates the product asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> ValidateProductAsync(ProductEntity entity);
    }
}