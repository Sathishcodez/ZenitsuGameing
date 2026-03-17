using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.DataAcess.Data;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.DataAccess.Repositories
{
    public class ShoppingCartRepository:Repository<ShoppingCart>, IShoppingCart
    {

        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _db.ShoppingCarts.Update(shoppingCart);
        }
    }
}
