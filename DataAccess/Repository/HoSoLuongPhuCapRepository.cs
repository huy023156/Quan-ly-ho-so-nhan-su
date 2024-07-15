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
    public class HoSoLuongPhuCapRepository : Repository<HoSoLuongPhuCap>, IHoSoLuongPhuCapRepository
    {
        private readonly ApplicationDbContext _db;
        public HoSoLuongPhuCapRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(HoSoLuongPhuCap hoSoLuongPhuCap)
        {
            _db.Update(hoSoLuongPhuCap);
        }
    }
}
