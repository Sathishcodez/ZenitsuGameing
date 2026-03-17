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
    public class ApplicationUsersRepository:Repository<Applicationusers>, IApplicationUsers 
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUsersRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

    }
}
