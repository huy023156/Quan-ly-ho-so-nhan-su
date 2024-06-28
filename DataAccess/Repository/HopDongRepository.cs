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
    public class HopDongRepository : Repository<HopDong>, IHopDongRepository
    {
        private readonly ApplicationDbContext _db;
        public HopDongRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(HopDong hopDong)
        {
            _db.Update(hopDong);
        }
    }
}
