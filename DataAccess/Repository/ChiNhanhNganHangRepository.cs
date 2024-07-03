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
    public class ChiNhanhNganHangRepository : Repository<ChiNhanhNganHang>, IChiNhanhNganHangRepository
    {
        private readonly ApplicationDbContext _db;
        public ChiNhanhNganHangRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(ChiNhanhNganHang chiNhanhNganHang)
        {
            _db.Update(chiNhanhNganHang);
        }
    }
}
