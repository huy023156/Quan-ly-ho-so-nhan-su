using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ChucDanh> ChucDanhTable { get; set; }
        public DbSet<HopDong> HopDongTable { get; set; }
        public DbSet<QuocGia> QuocGiaTable { get; set; }
        public DbSet<TinhThanh> TinhThanhTable { get; set; }
        public DbSet<QuanHuyen> QuanHuyenTable { get; set; }
        public DbSet<XaPhuong> XaPhuongTable { get; set; }
        public DbSet<TaiSanCapPhat> TaiSanCapPhatTable { get; set; }
        public DbSet<PhuCap> PhuCapTable { get; set; }
        public DbSet<CheDoPhucLoi> CheDoPhucLoiTable { get; set; }
        public DbSet<NganHang> NganHangTable { get; set; }
        public DbSet<ChiNhanhNganHang> ChiNhanhNganHangTable { get; set; }
        public DbSet<PhongBan> PhongBanTable { get; set; }
        public DbSet<PhongBanChucDanh> PhongBanChucDanhTable { get; set; }
        public DbSet<NoiKhamChuaBenh> NoiKhamChuaBenhTable { get; set; }
        public DbSet<Employee> EmployeeTable { get; set; }
        public DbSet<HopDongDetail> HopDongDetailTable { get; set; }
        public DbSet<QuyetDinh> QuyetDinhTable { get; set; }
        public DbSet<QuyetDinhDetail> QuyetDinhDetailTable { get; set; }
        public DbSet<HoSoLuong> HoSoLuongTable { get; set; }
        public DbSet<HoSoLuongCheDoPhucLoi> HoSoLuongCheDoPhucLoiTable { get; set; }
        public DbSet<HoSoLuongPhuCap> HoSoLuongPhuCapTable { get; set; }
        public DbSet<EmployeeTaiSanCapPhat> EmployeeTaiSanCapPhatTable { get; set; }

        public DbSet<DiaChi> DiaChiTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChucDanh>().HasData(
                new ChucDanh { Id = 1, Name = "Giám đốc trung tâm" },
                new ChucDanh { Id = 2, Name = "Phó giám đốc trung tâm" },
                new ChucDanh { Id = 3, Name = "Leader" },
                new ChucDanh { Id = 4, Name = "Nhân viên" }
                );

            modelBuilder.Entity<HopDong>().HasData(
                new HopDong { Id = 1, Name = "Hợp đồng đào tạo" },
                new HopDong { Id = 2, Name = "Hợp đồng học viên" },
                new HopDong { Id = 3, Name = "Hợp đồng thử việc" },
                new HopDong { Id = 4, Name = "Hợp đồng chính thức" },
                new HopDong { Id = 5, Name = "Hợp đồng cộng tác viên" }
                );

            modelBuilder.Entity<QuocGia>().HasData(
                new QuocGia { Id = 1, Name = "Việt Nam" },
                new QuocGia { Id = 2, Name = "Nhật Bản" },
                new QuocGia { Id = 3, Name = "Hoa Kỳ" });

            modelBuilder.Entity<TinhThanh>().HasData(
                new TinhThanh { Id = 1, Name = "Hà Nội", QuocGiaId = 1 },
                new TinhThanh { Id = 2, Name = "Thành phố Hồ Chí Minh", QuocGiaId = 1 },
                new TinhThanh { Id = 3, Name = "Đà Nẵng", QuocGiaId = 1 },
                new TinhThanh { Id = 4, Name = "Tokyo", QuocGiaId = 2 }
                );

            modelBuilder.Entity<QuanHuyen>().HasData(
                new QuanHuyen { Id = 1, Name = "Hà Đông", TinhThanhId = 1 },
                new QuanHuyen { Id = 2, Name = "Đống Đa", TinhThanhId = 1 },
                new QuanHuyen { Id = 3, Name = "Hoàng Mai", TinhThanhId = 1 },
                new QuanHuyen { Id = 4, Name = "Cầu Giấy", TinhThanhId = 1 },
                new QuanHuyen { Id = 5, Name = "Ba Đình", TinhThanhId = 1 },
                new QuanHuyen { Id = 6, Name = "Quận 1", TinhThanhId = 2 }
                );

            modelBuilder.Entity<XaPhuong>().HasData(
                new XaPhuong { Id = 1, Name = "La Khê", QuanHuyenId = 1 },
                new XaPhuong { Id = 2, Name = "Khâm Thiên", QuanHuyenId = 2 },
                new XaPhuong { Id = 3, Name = "Phương Liệt", QuanHuyenId = 3 },
                new XaPhuong { Id = 4, Name = "Dịch Vọng", QuanHuyenId = 4 },
                new XaPhuong { Id = 5, Name = "Mỹ Khê", QuanHuyenId = 5 },
                new XaPhuong { Id = 6, Name = "Tân Định", QuanHuyenId = 6 },
                new XaPhuong { Id = 7, Name = "Yên Hòa", QuanHuyenId = 4 }
                );

            modelBuilder.Entity<DiaChi>().HasData(
                new DiaChi { Id = 1, QuocGiaId = 1, TinhThanhId = 1, QuanHuyenId = 1, XaPhuongId = 1 },
                new DiaChi { Id = 2, QuocGiaId = 1, TinhThanhId = 1, QuanHuyenId = 2, XaPhuongId = 2 },
                new DiaChi { Id = 3, QuocGiaId = 1, TinhThanhId = 1, QuanHuyenId = 3, XaPhuongId = 3 },
                new DiaChi { Id = 4, QuocGiaId = 1, TinhThanhId = 1, QuanHuyenId = 4, XaPhuongId = 4 }
                );

            modelBuilder.Entity<TaiSanCapPhat>().HasData(
                new TaiSanCapPhat { Id = 1, Name = "Máy tính" },
                new TaiSanCapPhat { Id = 2, Name = "Chuột" },
                new TaiSanCapPhat { Id = 3, Name = "Bàn phím" },
                new TaiSanCapPhat { Id = 4, Name = "Ổ cứng" }
                );

            modelBuilder.Entity<PhuCap>().HasData(
                new PhuCap { Id = 1, Name = "Bảo hiểm y tế" },
                new PhuCap { Id = 2, Name = "Bảo hiểm xã hội" },
                new PhuCap { Id = 3, Name = "Bảo hiểm thất nghiệp" },
                new PhuCap { Id = 4, Name = "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp" },
                new PhuCap { Id = 5, Name = "Hưu trí" }
                );

            modelBuilder.Entity<CheDoPhucLoi>().HasData(
                new CheDoPhucLoi { Id = 1, Name = "Bảo hiểm y tế" },
                new CheDoPhucLoi { Id = 2, Name = "Bảo hiểm xã hội" },
                new CheDoPhucLoi { Id = 3, Name = "Bảo hiểm thất nghiệp" },
                new CheDoPhucLoi { Id = 4, Name = "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp" },
                new CheDoPhucLoi { Id = 5, Name = "Hưu trí" }
                );

            modelBuilder.Entity<NganHang>().HasData(
                new NganHang { Id = 1, Name = "MB Bank" },
                new NganHang { Id = 2, Name = "VP Bank" },
                new NganHang { Id = 3, Name = "Techcombank" },
                new NganHang { Id = 4, Name = "Viettinbank" }
                );

            modelBuilder.Entity<ChiNhanhNganHang>().HasData(
                new ChiNhanhNganHang { Id = 1, NganHangId = 1, DiaChiId = 1, DiaChiDetail = "12 Le Trong Tan" },
                new ChiNhanhNganHang { Id = 2, NganHangId = 2, DiaChiId = 2, DiaChiDetail = "20 Duong Lang" },
                new ChiNhanhNganHang { Id = 3, NganHangId = 3, DiaChiId = 3, DiaChiDetail = "50 Duong Mac Thai Tong" }
                );

            modelBuilder.Entity<PhongBan>().HasData(
                new PhongBan { Id = 1, Name = "C12" },
                new PhongBan { Id = 2, Name = "C10" },
                new PhongBan { Id = 3, Name = "C9" },
                new PhongBan { Id = 4, Name = "C3" },
                new PhongBan { Id = 5, Name = "C6" },
                new PhongBan { Id = 6, Name = "DU" }
                );

            modelBuilder.Entity<PhongBanChucDanh>().HasData(
                new PhongBanChucDanh { Id = 1, PhongBanId = 1, ChucDanhId = 1 },
                new PhongBanChucDanh { Id = 2, PhongBanId = 1, ChucDanhId = 2 },
                new PhongBanChucDanh { Id = 3, PhongBanId = 1, ChucDanhId = 3 },
                new PhongBanChucDanh { Id = 4, PhongBanId = 1, ChucDanhId = 4 },
                new PhongBanChucDanh { Id = 5, PhongBanId = 2, ChucDanhId = 1 },
                new PhongBanChucDanh { Id = 6, PhongBanId = 2, ChucDanhId = 2 },
                new PhongBanChucDanh { Id = 7, PhongBanId = 2, ChucDanhId = 3 },
                new PhongBanChucDanh { Id = 8, PhongBanId = 2, ChucDanhId = 4 },
                new PhongBanChucDanh { Id = 9, PhongBanId = 3, ChucDanhId = 1 },
                new PhongBanChucDanh { Id = 10, PhongBanId = 3, ChucDanhId = 2 },
                new PhongBanChucDanh { Id = 11, PhongBanId = 3, ChucDanhId = 3 },
                new PhongBanChucDanh { Id = 12, PhongBanId = 3, ChucDanhId = 4 },
                new PhongBanChucDanh { Id = 13, PhongBanId = 4, ChucDanhId = 1 },
                new PhongBanChucDanh { Id = 14, PhongBanId = 4, ChucDanhId = 2 },
                new PhongBanChucDanh { Id = 15, PhongBanId = 4, ChucDanhId = 3 },
                new PhongBanChucDanh { Id = 16, PhongBanId = 4, ChucDanhId = 4 },
                new PhongBanChucDanh { Id = 17, PhongBanId = 5, ChucDanhId = 1 },
                new PhongBanChucDanh { Id = 18, PhongBanId = 5, ChucDanhId = 2 },
                new PhongBanChucDanh { Id = 19, PhongBanId = 5, ChucDanhId = 3 },
                new PhongBanChucDanh { Id = 20, PhongBanId = 5, ChucDanhId = 4 }
                );

            modelBuilder.Entity<NoiKhamChuaBenh>().HasData(
                new NoiKhamChuaBenh { Id = 1, Name = "Phong kham Tre Viet", DiaChiDetail = "18 Hoang Son", DiaChiId = 8 }
                );

            modelBuilder.Entity<QuyetDinh>().HasData(
                new QuyetDinh { Id = 1, Name = "Quyết định tuyển dụng" },
                new QuyetDinh { Id = 2, Name = "Quyết định đuổi việc" },
                new QuyetDinh { Id = 3, Name = "Quyết định thăng chức" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Nguyen Quang Huy",
                    ChiNhanhNganHangId = 1,
                    ChucDanhId = 1,
                    DateOfBirth = new DateTime(2003, 4, 9),
                    PhoneNumber = "0369694076",
                    Email = "huy023156@gmail.com",
                    Gender = true,
                    PhongBanId = 1,
                    DiaChiDetail = "số 13 ngõ 5 đường ngô đình mẫn",
                    DiaChiId = 12,
                    NguoiTao = "Admin",
                    NgayTao = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    Name = "Nguyen Phuong Mai",
                    ChiNhanhNganHangId = 2,
                    ChucDanhId = 2,
                    DateOfBirth = new DateTime(2002, 9, 6),
                    PhoneNumber = "0123485682",
                    Email = "miaf@mai.com",
                    Gender = false,
                    DiaChiDetail = "số 16 đường chiến thắng",
                    DiaChiId = 13,
                    PhongBanId = 2,
                    NguoiTao = "Admin",
                    NgayTao = DateTime.Now
                }
                );

            modelBuilder.Entity<HoSoLuong>().HasData(
                new HoSoLuong
                { Id = 1, EmployeeId = 1, BacLuong = 4.3f, LuongCoBan = 20000, RanhLuongMin = 70000, RanhLuongMax = 150000, NguoiTao = "Admin", NgayTao = DateTime.Now },
                new HoSoLuong
                { Id = 2, EmployeeId = 2, BacLuong = 3.9f, LuongCoBan = 16000, RanhLuongMin = 50000, RanhLuongMax = 100000, NguoiTao = "Admin", NgayTao = DateTime.Now }
                );

            modelBuilder.Entity<HoSoLuongCheDoPhucLoi>().HasData(
                new HoSoLuongCheDoPhucLoi { Id = 1, HoSoLuongId = 1, CheDoPhucLoiId = 1, Amount = 500 },
                new HoSoLuongCheDoPhucLoi { Id = 2, HoSoLuongId = 1, CheDoPhucLoiId = 2, Amount = 300 },
                new HoSoLuongCheDoPhucLoi { Id = 3, HoSoLuongId = 1, CheDoPhucLoiId = 1, Amount = 450 },
                new HoSoLuongCheDoPhucLoi { Id = 4, HoSoLuongId = 1, CheDoPhucLoiId = 3, Amount = 1500 }
                );

            modelBuilder.Entity<HoSoLuongPhuCap>().HasData(
                new HoSoLuongPhuCap { Id = 1, HoSoLuongId = 1, PhuCapId = 1, Amount = 100 },
                new HoSoLuongPhuCap { Id = 2, HoSoLuongId = 1, PhuCapId = 3, Amount = 10 },
                new HoSoLuongPhuCap { Id = 3, HoSoLuongId = 1, PhuCapId = 4, Amount = 30 },
                new HoSoLuongPhuCap { Id = 4, HoSoLuongId = 2, PhuCapId = 1, Amount = 80 },
                new HoSoLuongPhuCap { Id = 5, HoSoLuongId = 2, PhuCapId = 3, Amount = 7 },
                new HoSoLuongPhuCap { Id = 6, HoSoLuongId = 2, PhuCapId = 4, Amount = 25 }
                );

            modelBuilder.Entity<QuyetDinhDetail>().HasData(
                new QuyetDinhDetail
                {
                    Id = 1,
                    QuyetDinhId = 1,
                    NgayQuyetDinh = new DateTime(2023, 11, 8),
                    NgayHieuLuc = new DateTime(2023, 11, 10),
                    NgayHetHieuLuc = new DateTime(2025, 11, 10),
                    NoiDung = "Tuyển dụng anh Huy vào vị trí Giám đốc",
                    NguoiTao = "Admin",
                    NgayTao = DateTime.Now
                },
                new QuyetDinhDetail
                {
                    Id = 2,
                    QuyetDinhId = 1,
                    NgayQuyetDinh = new DateTime(2023, 12, 8),
                    NgayHieuLuc = new DateTime(2023, 12, 10),
                    NgayHetHieuLuc = new DateTime(2025, 12, 10),
                    NoiDung = "Tuyển dụng chị Mai vào vị trí Phó giám đốc",
                    NguoiTao = "Admin",
                    NgayTao = DateTime.Now
                }
                );

            modelBuilder.Entity<HopDongDetail>().HasData(
                new HopDongDetail
                {
                    Id = 1,
                    EmployeeId = 1,
                    HopDongId = 6,
                    HoSoLuongId = 1,
                    QuyetDinhDetailId = 1,
                    NgayBatDau = new DateTime(2023, 11, 10),
                    NgayKetThuc = new DateTime(2025, 11, 10),
                    NguoiTao = "Admin",
                    NgayTao = DateTime.Now
                },
                new HopDongDetail
                {
                    Id = 2,
                    EmployeeId = 2,
                    HopDongId = 6,
                    HoSoLuongId = 2,
                    QuyetDinhDetailId = 2,
                    NgayBatDau = new DateTime(2023, 12, 10),
                    NgayKetThuc = new DateTime(2025, 12, 10),
                    NguoiTao = "Admin",
                    NgayTao = DateTime.Now
                }
                );

            modelBuilder.Entity<EmployeeTaiSanCapPhat>().HasData(
                new EmployeeTaiSanCapPhat { Id = 1, EmployeeId = 1, TaiSanCapPhatId = 1, Amount = 1},
                new EmployeeTaiSanCapPhat { Id = 2, EmployeeId = 1, TaiSanCapPhatId = 2, Amount = 1 },
                new EmployeeTaiSanCapPhat { Id = 3, EmployeeId = 1, TaiSanCapPhatId = 3, Amount = 1 },
                new EmployeeTaiSanCapPhat { Id = 4, EmployeeId = 1, TaiSanCapPhatId = 4, Amount = 3 },
                new EmployeeTaiSanCapPhat { Id = 5, EmployeeId = 2, TaiSanCapPhatId = 1, Amount = 1 },
                new EmployeeTaiSanCapPhat { Id = 6, EmployeeId = 2, TaiSanCapPhatId = 2, Amount = 1 },
                new EmployeeTaiSanCapPhat { Id = 7, EmployeeId = 2, TaiSanCapPhatId = 3, Amount = 1 },
                new EmployeeTaiSanCapPhat { Id = 8, EmployeeId = 2, TaiSanCapPhatId = 4, Amount = 2 }
                );
        }
    }
}
