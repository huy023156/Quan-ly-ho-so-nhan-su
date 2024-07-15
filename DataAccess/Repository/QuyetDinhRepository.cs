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
    public class QuyetDinhRepository : Repository<QuyetDinh>, IQuyetDinhRepository
    {
        private readonly ApplicationDbContext _db;
        public QuyetDinhRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(QuyetDinh quyetDinh)
        {
            _db.Update(quyetDinh);
        }
    }
}
