using System.Collections.Generic;
using ProjetoTeste.Entitiy;

namespace ProjetoTeste.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}