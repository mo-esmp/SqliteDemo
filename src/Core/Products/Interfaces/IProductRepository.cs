using Core.SeedWork;
using System.Threading.Tasks;

namespace Core.Products
{
    /// <summary>
    /// Interface IProductRepository
    /// </summary>
    /// <seealso cref="Core.SeedWork.IRepository" />
    public interface IProductRepository : IRepository
    {
        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        void AddProduct(ProductEntity product);

        /// <summary>
        /// Edits the product.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void EditProduct(ProductEntity entity);

        /// <summary>
        /// Checks the product exist by title asynchronous.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckProductExistByTitleAsync(string title, int productGroupId);

        /// <summary>
        /// Checks the product exist by title asynchronous.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <param name="id"></param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> CheckProductExistByTitleAsync(string title, int productGroupId, int id);

        /// <summary>
        /// Gets the product by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ProductEntity&gt;.</returns>
        Task<ProductEntity> GetProductByIdAsync(int id);

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>OperationResult.</returns>
        OperationResult RemoveProduct(ProductEntity product);
    }
}