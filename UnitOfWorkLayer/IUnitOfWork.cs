using Round2Api.Models;
using Round2Api.Repositories.Interfaces;

namespace Round2Api.UnitOfWorkLayer
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TModel> Repository<TModel>() where TModel : BaseModel;
        Task<int> CompleteAsync();
    }
}
