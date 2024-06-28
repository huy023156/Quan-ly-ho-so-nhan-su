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
    public class TinhThanhRepository : Repository<TinhThanh>, ITinhThanhRepository
    {
        private readonly ApplicationDbContext _db;
        public TinhThanhRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(TinhThanh tinhThanh)
        {
            _db.Update(tinhThanh);
        }
    }
}
