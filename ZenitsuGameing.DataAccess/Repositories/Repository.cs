using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.DataAcess.Data;

namespace ZenitsuGameing.DataAccess.Repositories
{
    public class Repository<t> : IRepository<t> where t : class
    {
        public readonly ApplicationDbContext _db;
        internal DbSet<t> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<t>();
            _db.Products.Include(u => u.Category).Include(u=> u.CategoryId);
        }
        public void Add(t entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<t> GetAll(string? includeprop = null)
        {
            IQueryable<t> query = dbSet;

            if (!String.IsNullOrEmpty(includeprop))
            {
                foreach(var includeProps in includeprop.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProps);
                }
            }

            return query.ToList();
        }

        public t GetFirstOrDefault(Expression<Func<t, bool>> filter, string? includeprop = null)
        {
            IQueryable<t> query = dbSet;
            query = query.Where(filter);
            if(!String.IsNullOrEmpty(includeprop))
            {
                foreach (var includeProps in includeprop.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProps);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(t entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<t> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
