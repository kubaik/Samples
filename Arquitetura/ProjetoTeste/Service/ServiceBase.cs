using ProjetoTeste.Entitiy;
using ProjetoTeste.Repository;

namespace ProjetoTeste.Service
{
    public abstract class ServiceBase<TRepository, TEntity>
        where TRepository : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repository;

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}