using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenitsuGameing.DataAcess.Data;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.DataAccess.Repositories.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
           void update(Product product);
        
    }
}
