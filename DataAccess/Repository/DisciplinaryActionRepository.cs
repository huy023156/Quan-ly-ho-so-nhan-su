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
    public class DisciplinaryActionRepository : Repository<DisciplinaryAction>, IDisciplinaryActionRepository
    {
        private readonly ApplicationDbContext _db;
        public DisciplinaryActionRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(DisciplinaryAction disciplinaryAction)
        {
            _db.Update(disciplinaryAction);
        }
    }
}
