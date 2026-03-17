using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.DataAcess.Data;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void update(Product product)
        {
            _db.Products.Update(product);

            var objFromdb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objFromdb != null) 
            { 
                objFromdb.Title = product.Title;
                objFromdb.Description = product.Description;
                objFromdb.Creator = product.Creator;
                objFromdb.Description = product.Description;
                objFromdb.Price = product.Price;
                objFromdb.Price50 = product.Price50;
                objFromdb.Price100 = product.Price100;
                objFromdb.CategoryId = product.CategoryId;
                if(product.ImageUrl != null)
                {
                    objFromdb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
