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
    public class HoSoLuongCheDoPhucLoiRepository : Repository<HoSoLuongCheDoPhucLoi>, IHoSoLuongCheDoPhucLoiRepository
    {
        private readonly ApplicationDbContext _db;
        public HoSoLuongCheDoPhucLoiRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(HoSoLuongCheDoPhucLoi hoSoLuongCheDoPhucLoi)
        {
            _db.Update(hoSoLuongCheDoPhucLoi);
        }
    }
}
