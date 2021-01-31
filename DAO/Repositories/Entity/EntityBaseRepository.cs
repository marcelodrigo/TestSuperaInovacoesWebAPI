using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO.Repositories.Entity
{
    public abstract class EntityBaseRepository<TEntity> : IRepositorioBD<TEntity>
        where TEntity : class
    {
        protected readonly DataContext _context;
        protected DbSet<TEntity> _dbSetEntity;

        public EntityBaseRepository(
            DataContext context)
        {
            _context = context;
            _dbSetEntity = _context.Set<TEntity>();
        }

        public EntityBaseRepository()
            : this(new DataContext())
        { }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        #region IRepositorioBD

        public virtual IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }

        public virtual TEntity ObterPeloId(long id)
        {
            return _dbSetEntity.Find(id);
        }

        public virtual List<TEntity> ObterTodos()
        {
            return _dbSetEntity.ToList();
        }

        public virtual TEntity Inserir(TEntity obj)
        {
            _dbSetEntity.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual TEntity Alterar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }

        public virtual List<TEntity> Alterar(List<TEntity> listEntity)
        {
            foreach (var obj in listEntity)
                _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return listEntity;
        }

        public virtual TEntity Remover(TEntity obj)
        {
            _dbSetEntity.Attach(obj);
            _dbSetEntity.Remove(obj);
            _context.SaveChanges();
            return obj;
        }

        #endregion
    }
}
