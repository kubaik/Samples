using System.Collections.Generic;

namespace ProjetoTeste.Domain.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}