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
    public class HoSoLuongRepository : Repository<HoSoLuong>, IHoSoLuongRepository
    {
        private readonly ApplicationDbContext _db;
        public HoSoLuongRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(HoSoLuong hoSoLuong)
        {
            _db.Update(hoSoLuong);
        }
    }
}
