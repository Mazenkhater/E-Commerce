using System.Linq.Expressions;

namespace E_Commerce.Core.Interfaces.Base
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById (int id);

        Task ADD (T entity);

        Task Update(int id, T entity);

        Task Delete (int id);
        Task<IEnumerable<T>> Queryable(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            Func<IQueryable<T>, IQueryable<T>>? orderby = null,
            int? pagenumber = null, int? pagesize = null);




    }
}
