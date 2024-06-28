using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class XaPhuongRepository : Repository<XaPhuong>, IXaPhuongRepository
    {
        private readonly ApplicationDbContext _db;
        public XaPhuongRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(XaPhuong xaPhuong)
        {
            _db.Update(xaPhuong);
        }
    }
}
