using Catalogo.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositories
{
    internal abstract class RepositoryBase<TEntity>
        where TEntity : class
    {
        protected readonly AppDbContext _context;

        protected RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            SaveChanges();

            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            SaveChanges();
        }


        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}