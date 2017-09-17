using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductGroupService
    /// </summary>
    /// <seealso cref="Core.SeedWork.IService" />
    public interface IProductGroupService : IService
    {
        /// <summary>
        /// Adds the product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>OperationResult.</returns>
        Task<OperationResult> AddProductGroupAsync(ProductGroupEntity productGroup);

        /// <summary>
        /// Edits the product group asynchronous.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> EditProductGroupAsync(ProductGroupEntity productGroup);

        /// <summary>
        /// Removes the product group asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> RemoveProductGroupAsync(int id);
    }
}