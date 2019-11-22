using System.Collections.Generic;
using ProjetoTeste.Entitiy;

namespace ProjetoTeste.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        public IEnumerable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity Get()
        {
            throw new System.NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}