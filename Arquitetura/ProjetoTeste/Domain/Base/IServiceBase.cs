using System.Collections.Generic;

namespace ProjetoTeste.Domain.Base
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}