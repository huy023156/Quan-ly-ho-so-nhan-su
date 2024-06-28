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
    public class ChucDanhRepository : Repository<ChucDanh>, IChucDanhRepository
    {
        private readonly ApplicationDbContext _db;
        public ChucDanhRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(ChucDanh chucDanh)
        {
            _db.Update(chucDanh);
        }
    }
}
