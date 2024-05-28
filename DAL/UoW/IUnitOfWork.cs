
namespace DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
        int Save();
       
    }
}
