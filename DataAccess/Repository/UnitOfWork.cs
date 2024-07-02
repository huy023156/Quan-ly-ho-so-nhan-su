using DataAccess.Data;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IChucDanhRepository ChucDanhTable { get; private set; }
        public IHopDongRepository HopDongTable { get; private set; }
        public IQuocGiaRepository QuocGiaTable { get; private set; }
        public ITinhThanhRepository TinhThanhTable { get; private set; }
        public IQuanHuyenRepository QuanHuyenTable { get; private set; }
        public IXaPhuongRepository XaPhuongTable { get; private set; }
        public ITaiSanCapPhatRepository TaiSanCapPhatTable { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            ChucDanhTable = new ChucDanhRepository(db);
            HopDongTable = new HopDongRepository(db);
            QuocGiaTable = new QuocGiaRepository(db);
            TinhThanhTable = new TinhThanhRepository(db);
            QuanHuyenTable = new QuanHuyenRepository(db);
            XaPhuongTable = new XaPhuongRepository(db);
            TaiSanCapPhatTable = new TaiSanCapPhatRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
