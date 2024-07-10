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
    public class NoiKhamChuaBenhRepository : Repository<NoiKhamChuaBenh>, INoiKhamChuaBenhRepository
    {
        private readonly ApplicationDbContext _db;
        public NoiKhamChuaBenhRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(NoiKhamChuaBenh noiKhamChuaBenh)
        {
            _db.Update(noiKhamChuaBenh);
        }
    }
}
