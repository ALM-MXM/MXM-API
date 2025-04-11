using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Repositories.BaseRepository
{


    public class BaseRepository<T> where T : class
    {

        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public DbContext DbContext => _context;
        public DbSet<T> DbSet => _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }
       
        public async Task<T?> SelecionarEntidadeAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }      

        public async Task<IList<T>> SelecionarListaAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }     
       
        public async Task<bool> ExisteEntidadeAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }      
    }
}
