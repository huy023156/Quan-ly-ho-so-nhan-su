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
    public class PhongBanRepository : Repository<PhongBan>, IPhongBanRepository
    {
        private readonly ApplicationDbContext _db;
        public PhongBanRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(PhongBan phongBan)
        {
            _db.Update(phongBan);
        }
    }
}
