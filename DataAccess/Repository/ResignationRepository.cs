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
    public class ResignationRepository : Repository<Resignation>, IResignationRepository
    {
        private readonly ApplicationDbContext _db;
        public ResignationRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Resignation resignation)
        {
            _db.Update(resignation);
        }
    }
}
