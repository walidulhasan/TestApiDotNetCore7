using Microsoft.EntityFrameworkCore;
using TestApi.Data;

namespace TestApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected TestApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(TestApiDbContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet= _context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
        protected DbSet<T> DbSet
        {
            get
            {
                if (dbSet == null)
                    dbSet = _context.Set<T>();
                return dbSet;
            }
        }
        private DbSet<T> dbSet;


        public async Task<object> InsertAsync(T entity, bool saveChanges = true)
        {
            var rtn = await DbSet.AddAsync(entity);
            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
            return rtn;
        }
    }
}
