using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.DataAcess.Data;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {

        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }


        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
