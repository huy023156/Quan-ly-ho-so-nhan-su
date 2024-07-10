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
    public class DiaChiRepository : Repository<DiaChi>, IDiaChiRepository
    {
        private readonly ApplicationDbContext _db;
        public DiaChiRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(DiaChi diaChi)
        {
            _db.Update(diaChi);
        }
    }
}
