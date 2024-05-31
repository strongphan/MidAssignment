using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public abstract class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class
    {
        protected LibraryContext _context;
        protected DbSet<TEntity> _table;
        public BaseRepo(LibraryContext dbContext)
        {
            _context = dbContext;
            _table = _context.Set<TEntity>();
        }
        public async void DeleteAsync(TEntity entity)
        {

            _table.Remove(entity);
            Save();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _table.ToListAsync();

        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            return await _table.FindAsync(Id);
        }

        public void InsertAsync(TEntity entity)
        {
            _table.Add(entity);
            Save();
        }

        public void UpdateAsync(TEntity entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

