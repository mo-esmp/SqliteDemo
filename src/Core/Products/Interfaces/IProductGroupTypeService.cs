using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductGroupTypeService
    /// </summary>
    /// <seealso cref="Core.SeedWork.IService" />
    public interface IProductGroupTypeService : IService
    {
        /// <summary>
        /// Adds the product group type asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> AddProductGroupTypeAsync(ProductGroupTypeEntity entity);

        /// <summary>
        /// Edits the product group type asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> EditProductGroupTypeAsync(ProductGroupTypeEntity entity);

        /// <summary>
        /// Deletes the type of the product group.
        /// </summary>
        /// <param name="productGroupTypeId"></param>
        Task<OperationResult> RemoveProductGroupTypeAsync(int productGroupTypeId);
    }
}