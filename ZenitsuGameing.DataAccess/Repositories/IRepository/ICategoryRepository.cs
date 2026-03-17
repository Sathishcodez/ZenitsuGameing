using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.DataAccess.Repositories.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category category);

    }
}
