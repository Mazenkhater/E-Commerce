using E__Commerce.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_Commerce.Core.Interfaces.Base
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public MainRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<List<T>> GetAll()
        {
           return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        
        public async Task ADD(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task Update(int id, T NewEntity)
        {
            _context.Set<T>().Update(NewEntity);
            _context.SaveChanges();
        }


        public async Task Delete(int id)
        {
           T entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                    throw new Exception("Entity not found");
            }
        }

        public async Task<IEnumerable<T>> Queryable(Expression<Func<T, bool>>? filter=null,
                                                      Func<IQueryable<T>, IQueryable<T>>? include = null,
                                                          Func<IQueryable<T>, IQueryable<T>>? orderby=null,
                                                                int? pagenumber = null, int? pagesize = null)
        {
            IQueryable<T> Query = _context.Set<T>();
            if (filter != null)
            {
                Query = Query.Where(filter);
            }
            if (include != null)
            {
                Query = include(Query);
            }
            if (orderby != null)
            {
                Query = orderby(Query);
            }
           
            if (pagenumber != null && pagesize != null)
            {
                int skip = (pagenumber.Value - 1) * pagesize.Value;
                Query = Query.Skip(skip).Take(pagesize.Value);
            }
            return await Query.ToListAsync();
        }
        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> filter,Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.Where(filter);

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync();
        }
    }
}
