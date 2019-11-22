using System.Collections.Generic;
using System.Linq;

namespace ProjetoTeste.Domain.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Query();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}