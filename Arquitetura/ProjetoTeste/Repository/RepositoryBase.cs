using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Context;
using ProjetoTeste.Entitiy;

namespace ProjetoTeste.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly TesteContext _context;
        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        protected RepositoryBase(TesteContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll() => DbSet.ToList();

        public TEntity Get(int id) => DbSet.Find(id);

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}