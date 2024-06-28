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
    public class QuanHuyenRepository : Repository<QuanHuyen>, IQuanHuyenRepository
    {
        private readonly ApplicationDbContext _db;
        public QuanHuyenRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(QuanHuyen quanHuyen)
        {
            _db.Update(quanHuyen);
        }
    }
}
