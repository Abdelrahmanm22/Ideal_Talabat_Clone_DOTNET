using System.Collections;
using Microsoft.EntityFrameworkCore;
using Round2Api.Data;
using Round2Api.Models;
using Round2Api.Repositories.Concretes;
using Round2Api.Repositories.Interfaces;

namespace Round2Api.UnitOfWorkLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext dbContext;
        //private Dictionary<string, GenericRepository<>> _repositories; this need casting
        private Hashtable _repositories;

        public UnitOfWork(StoreContext dbContext)
        {
            this.dbContext = dbContext;
            _repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }

        public IGenericRepository<TModel> Repository<TModel>() where TModel : BaseModel
        {
            var type = typeof(TModel).Name; //Product
            if (!_repositories.ContainsKey(type)) {
                //first time
                var Repo = new GenericRepository<TModel>(dbContext);
                _repositories.Add(type, Repo);
            }
            return _repositories[type] as IGenericRepository<TModel>;
        }
    }
}
