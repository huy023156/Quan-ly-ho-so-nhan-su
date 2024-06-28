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
        }
    }
}
