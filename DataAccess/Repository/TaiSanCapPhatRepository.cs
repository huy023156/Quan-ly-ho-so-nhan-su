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
    public class TaiSanCapPhatRepository : Repository<TaiSanCapPhat>, ITaiSanCapPhatRepository
    {
        private readonly ApplicationDbContext _db;
        public TaiSanCapPhatRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(TaiSanCapPhat taiSanCapPhat)
        {
            _db.Update(taiSanCapPhat);
        }
    }
}
