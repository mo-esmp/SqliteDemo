namespace Core.SeedWork
{
    /// <summary>
    /// Default base interface for services. other service interfaces must inherit this interface.
    /// DI container registers all implementation of interfaces that inherit <see cref="IService"/>
    /// </summary>
    public interface IService
    {
    }
}