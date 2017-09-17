using Core.SeedWork;
using System;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IFamiliarityWayRepository
    /// </summary>
    /// <seealso cref="Core.SeedWork.IRepository" />
    public interface IProductGroupRepository : IRepository
    {
        /// <summary>
        /// Adds the product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        void AddProductGroup(ProductGroupEntity productGroup);

        /// <summary>
        /// Checks the product group exist by title asynchronous.
        /// </summary>
        /// <param name="groupTypeId">The group type identifier.</param>
        /// <param name="title">The title.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckProductGroupExistByTitleAsync(int groupTypeId, string title);

        /// <summary>
        /// Edits the product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>
        Task<OperationResult> EditProductGroupAsync(ProductGroupEntity productGroup);

        /// <summary>
        /// Gets the product group by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ProductGroupEntity&gt;.</returns>
        Task<ProductGroupEntity> GetProductGroupByIdAsync(int id);

        /// <summary>
        /// Romeves the product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Task&lt;OperationResult&gt;.</returns>

        OperationResult RemoveProductGroup(ProductGroupEntity productGroup);

        /// <summary>
        /// Gets the products count by product group identifier asynchronous.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [Obsolete("This method no longer required. please use CheckHasProductsByIdAsync instead.")]
        Task<int> GetProductsCountByProductGroupIdAsync(int productGroupId);

        /// <summary>
        /// Checks the product group has any products by identifier asynchronous.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckHasProductsByIdAsync(int productGroupId);
    }
}