using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductGroupTypeRepository
    /// </summary>
    /// <seealso cref="Core.SeedWork.IRepository" />
    public interface IProductGroupTypeRepository : IRepository
    {
        /// <summary>
        /// Adds the type of the product group.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void AddProductGroupType(ProductGroupTypeEntity entity);

        /// <summary>
        /// Checks the product group type exist by title asynchronous.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckProductGroupTypeExistByTitleAsync(string title);

        /// <summary>
        /// Checks the product group type exist by title asynchronous.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckProductGroupTypeExistByTitleAsync(string title, int productId);

        /// <summary>
        /// Edits the type of the product group.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void EditProductGroupType(ProductGroupTypeEntity entity);

        /// <summary>
        /// Gets the product group type by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ProductGroupTypeEntity&gt;.</returns>
        Task<ProductGroupTypeEntity> GetProductGroupTypeByIdAsync(int id);

        /// <summary>
        /// Deletes the type of the product group.
        /// </summary>
        /// <param name="entity">The ProductGroupType entity.</param>
        void RemoveProductGroupType(ProductGroupTypeEntity entity);

        /// <summary>
        /// Checks the exist product group by product group type identifier.
        /// </summary>
        /// <param name="productTypeId">The product type identifier.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckHasChildByIdAsync(int productTypeId);
    }
}