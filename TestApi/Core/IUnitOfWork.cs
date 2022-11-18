using TestApi.Interface.Repositories.Users;

namespace TestApi.Core
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
