using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductGroupValidator
    /// </summary>
    /// <seealso cref="Core.SeedWork.IService" />
    public interface IProductGroupValidator : IService
    {
        /// <summary>
        /// Validates the product group asynchronous.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> ValidateProductGroupAsync(ProductGroupEntity productGroup);
    }
}