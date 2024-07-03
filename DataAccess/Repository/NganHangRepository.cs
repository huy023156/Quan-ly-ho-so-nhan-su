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
    public class NganHangRepository : Repository<NganHang>, INganHangRepository
    {
        private readonly ApplicationDbContext _db;
        public NganHangRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(NganHang nganHang)
        {
            _db.Update(nganHang);
        }
    }
}
