using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenitsuGameing.DataAccess.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        ICompanyRepository Company { get; }

        IShoppingCart shoppingCart { get; }

        void Save();
    }
}
