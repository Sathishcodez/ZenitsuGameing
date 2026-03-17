using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenitsuGameing.DataAccess.Repositories.IRepository
{
    public interface IRepository<T> where T:class
    {

        IEnumerable<T> GetAll(string? includeprop = null);
        T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeprop = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
