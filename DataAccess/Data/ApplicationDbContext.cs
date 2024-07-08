using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<TaiSanCapPhat>().HasData(
                new TaiSanCapPhat { Id = 1, Name = "Máy tính" },
                new TaiSanCapPhat { Id = 2, Name = "Chuột"},
                new TaiSanCapPhat { Id = 3, Name = "Bàn phím"},
                new TaiSanCapPhat { Id = 4, Name = "Ổ cứng"}
                );

            modelBuilder.Entity<PhuCap>().HasData(
                new PhuCap { Id = 1, Name = "Bảo hiểm y tế"},
                new PhuCap { Id = 2, Name = "Bảo hiểm xã hội"},
                new PhuCap { Id = 3, Name = "Bảo hiểm thất nghiệp"},
                new PhuCap { Id = 4, Name = "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp"},
				new PhuCap { Id = 5, Name = "Hưu trí"}
				);

            modelBuilder.Entity<CheDoPhucLoi>().HasData(
                new CheDoPhucLoi { Id = 1, Name = "Bảo hiểm y tế" },
				new CheDoPhucLoi { Id = 2, Name = "Bảo hiểm xã hội" },
				new CheDoPhucLoi { Id = 3, Name = "Bảo hiểm thất nghiệp" },
				new CheDoPhucLoi { Id = 4, Name = "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp" },
				new CheDoPhucLoi { Id = 5, Name = "Hưu trí" }
				);

            modelBuilder.Entity<NganHang>().HasData(
                new NganHang { Id = 1, Name = "MB Bank"},
                new NganHang { Id = 2, Name = "VP Bank"},
				new NganHang { Id = 3, Name = "Techcombank" },
				new NganHang { Id = 4, Name = "Viettinbank" }
				);

            modelBuilder.Entity<ChiNhanhNganHang>().HasData(
                new ChiNhanhNganHang 
                { Id = 1, NganHangId = 1, DiaChi = "12 đường Lê Trọng Tấn", XaPhuongId = 1},
                new ChiNhanhNganHang 
                { Id = 2, NganHangId = 2, DiaChi = "69 đường Tôn Thất Thuyết", XaPhuongId = 4}
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
                new PhongBanChucDanh { Id = 1, PhongBanId = 1, ChucDanhId = 1},
                new PhongBanChucDanh { Id = 2, PhongBanId = 1, ChucDanhId = 2},
                new PhongBanChucDanh { Id = 3, PhongBanId = 1, ChucDanhId = 3},
                new PhongBanChucDanh { Id = 4, PhongBanId = 1, ChucDanhId = 4},
                new PhongBanChucDanh { Id = 5, PhongBanId = 2, ChucDanhId = 1},
                new PhongBanChucDanh { Id = 6, PhongBanId = 2, ChucDanhId = 2},
                new PhongBanChucDanh { Id = 7, PhongBanId = 2, ChucDanhId = 3},
                new PhongBanChucDanh { Id = 8, PhongBanId = 2, ChucDanhId = 4},
                new PhongBanChucDanh { Id = 9, PhongBanId = 3, ChucDanhId = 1},
                new PhongBanChucDanh { Id = 10, PhongBanId = 3, ChucDanhId = 2},
                new PhongBanChucDanh { Id = 11, PhongBanId = 3, ChucDanhId = 3},
                new PhongBanChucDanh { Id = 12, PhongBanId = 3, ChucDanhId = 4},
                new PhongBanChucDanh { Id = 13, PhongBanId = 4, ChucDanhId = 1},
                new PhongBanChucDanh { Id = 14, PhongBanId = 4, ChucDanhId = 2},
                new PhongBanChucDanh { Id = 15, PhongBanId = 4, ChucDanhId = 3},
                new PhongBanChucDanh { Id = 16, PhongBanId = 4, ChucDanhId = 4},
                new PhongBanChucDanh { Id = 17, PhongBanId = 5, ChucDanhId = 1},
                new PhongBanChucDanh { Id = 18, PhongBanId = 5, ChucDanhId = 2},
                new PhongBanChucDanh { Id = 19, PhongBanId = 5, ChucDanhId = 3},
                new PhongBanChucDanh { Id = 20, PhongBanId = 5, ChucDanhId = 4}
				);
        }
    }
}
