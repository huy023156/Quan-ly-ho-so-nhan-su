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
        public IPhuCapRepository PhuCapTable { get; private set; }
        public ICheDoPhucLoiRepository CheDoPhucLoiTable { get; private set; }
        public INganHangRepository NganHangTable { get; private set; }
        public IChiNhanhNganHangRepository ChiNhanhNganHangTable { get; private set; }
        public IPhongBanRepository PhongBanTable { get; private set; }
        public IPhongBanChucDanhRepository PhongBanChucDanhTable { get; private set; }
        public IDiaChiRepository DiaChiTable { get; private set; }
        public INoiKhamChuaBenhRepository NoiKhamChuaBenhTable { get; private set; }
        public IEmployeeRepository EmployeeTable { get; private set; }
        public IQuyetDinhDetailRepository QuyetDinhDetailTable { get; private set; }
        public IQuyetDinhRepository QuyetDinhTable { get; private set; }
        public IHopDongDetailRepository HopDongDetailTable { get; private set; }
        public IHoSoLuongRepository HoSoLuongTable { get; private set; }
        public IHoSoLuongPhuCapRepository HoSoLuongPhuCapTable { get; private set; }
        public IHoSoLuongCheDoPhucLoiRepository HoSoLuongCheDoPhucLoiTable { get; private set; }
        public IEmployeeTaiSanCapPhatRepository EmployeeTaiSanCapPhatTable { get; private set; }
        public IDisciplinaryActionRepository DisciplinaryActionTable { get; private set; }
        public IRewardRepository RewardTable { get; private set; }
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
            PhuCapTable = new PhuCapRepository(db);
            CheDoPhucLoiTable = new CheDoPhucLoiRepository(db);
            NganHangTable = new NganHangRepository(db);
            ChiNhanhNganHangTable = new ChiNhanhNganHangRepository(db);
            PhongBanTable = new PhongBanRepository(db);
            PhongBanChucDanhTable = new PhongBanChucDanhRepository(db);
            DiaChiTable = new DiaChiRepository(db);
            NoiKhamChuaBenhTable = new NoiKhamChuaBenhRepository(db);
            EmployeeTable = new EmployeeRepository(db);
            QuyetDinhDetailTable = new QuyetDinhDetailRepository(db);
            QuyetDinhTable = new QuyetDinhRepository(db);
            HopDongDetailTable = new HopDongDetailRepository(db);
            HoSoLuongTable = new HoSoLuongRepository(db);
            HoSoLuongPhuCapTable = new HoSoLuongPhuCapRepository(db);
            HoSoLuongCheDoPhucLoiTable = new HoSoLuongCheDoPhucLoiRepository(db);
            EmployeeTaiSanCapPhatTable = new EmployeeTaiSanCapPhatRepository(db);
            DisciplinaryActionTable = new DisciplinaryActionRepository(db);
            RewardTable = new RewardRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
