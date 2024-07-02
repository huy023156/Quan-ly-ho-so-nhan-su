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
    public class PhuCapRepository : Repository<PhuCap>, IPhuCapRepository
    {
        private readonly ApplicationDbContext _db;
        public PhuCapRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(PhuCap phuCap)
        {
            _db.Update(phuCap);
        }
    }
}
