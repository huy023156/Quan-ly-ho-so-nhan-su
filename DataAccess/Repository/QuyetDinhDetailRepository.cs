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
    public class QuyetDinhDetailRepository : Repository<QuyetDinhDetail>, IQuyetDinhDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public QuyetDinhDetailRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(QuyetDinhDetail quyetDinhDetail)
        {
            _db.Update(quyetDinhDetail);
        }
    }
}
