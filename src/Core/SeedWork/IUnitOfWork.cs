using System.Threading;
using System.Threading.Tasks;

namespace Core.SeedWork
{
    /// <summary>
    /// Represent APIs for saving data into the database.
    /// </summary>
    public interface IUnitOfWork : IService
    {
        /// <summary>
        /// Commits all changes made in this context to the database.
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Commits all changes made in this context to the database asynchronous.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}