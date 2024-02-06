using GameStoreManagement.Shared.Domain;

namespace GameStoreManagement.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Game> Games { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<Staff> Staffs { get; }
    }  
}