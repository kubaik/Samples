using System.Collections.Generic;

namespace ProjetoTeste.Domain.Base
{
    public abstract class ServiceBase<TRepository, TEntity> : IServiceBase<TEntity>
        where TRepository : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected IRepositoryBase<TEntity> Repository { get; }

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            Repository = repository;
        }

        public IEnumerable<TEntity> GetAll() => Repository.GetAll();

        public TEntity Get(int id) => Repository.Get(id);

        public void Insert(TEntity entity) => Repository.Insert(entity);

        public void Update(TEntity entity) => Repository.Update(entity);

        public void Delete(TEntity entity) => Repository.Delete(entity);

        public void SaveChanges() => Repository.SaveChanges();
    }
}