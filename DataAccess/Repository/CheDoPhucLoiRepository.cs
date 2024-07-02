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
    public class CheDoPhucLoiRepository : Repository<CheDoPhucLoi>, ICheDoPhucLoiRepository
    {
        private readonly ApplicationDbContext _db;
        public CheDoPhucLoiRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(CheDoPhucLoi cheDoPhucLoi)
        {
            _db.Update(cheDoPhucLoi);
        }
    }
}
