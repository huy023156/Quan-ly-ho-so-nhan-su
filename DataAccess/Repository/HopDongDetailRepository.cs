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
    public class HopDongDetailRepository : Repository<HopDongDetail>, IHopDongDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public HopDongDetailRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(HopDongDetail hopDongDetail)
        {
            _db.Update(hopDongDetail);
        }
    }
}
