﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240704041753_addPhongBanChucDanhTableAndSeedData")]
    partial class addPhongBanChucDanhTableAndSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.CheDoPhucLoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CheDoPhucLoiTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bảo hiểm y tế"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bảo hiểm xã hội"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bảo hiểm thất nghiệp"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hưu trí"
                        });
                });

            modelBuilder.Entity("Models.ChiNhanhNganHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NganHangId")
                        .HasColumnType("int");

                    b.Property<int>("XaPhuongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NganHangId");

                    b.HasIndex("XaPhuongId");

                    b.ToTable("ChiNhanhNganHangTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiaChi = "12 đường Lê Trọng Tấn",
                            NganHangId = 1,
                            XaPhuongId = 1
                        },
                        new
                        {
                            Id = 2,
                            DiaChi = "69 đường Tôn Thất Thuyết",
                            NganHangId = 2,
                            XaPhuongId = 4
                        });
                });

            modelBuilder.Entity("Models.ChucDanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChucDanhTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Giám đốc trung tâm"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phó giám đốc trung tâm"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Leader"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nhân viên"
                        });
                });

            modelBuilder.Entity("Models.HopDong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HopDongTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hợp đồng đào tạo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hợp đồng học viên"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hợp đồng thử việc"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hợp đồng chính thức"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hợp đồng cộng tác viên"
                        });
                });

            modelBuilder.Entity("Models.NganHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NganHangTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MB Bank"
                        },
                        new
                        {
                            Id = 2,
                            Name = "VP Bank"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Techcombank"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Viettinbank"
                        });
                });

            modelBuilder.Entity("Models.PhongBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhongBanTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C12"
                        },
                        new
                        {
                            Id = 2,
                            Name = "C10"
                        },
                        new
                        {
                            Id = 3,
                            Name = "C9"
                        },
                        new
                        {
                            Id = 4,
                            Name = "C3"
                        },
                        new
                        {
                            Id = 5,
                            Name = "C6"
                        },
                        new
                        {
                            Id = 6,
                            Name = "DU"
                        });
                });

            modelBuilder.Entity("Models.PhongBanChucDanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChucDanhId")
                        .HasColumnType("int");

                    b.Property<int>("PhongBanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChucDanhId");

                    b.HasIndex("PhongBanId");

                    b.ToTable("PhongBanChucDanhTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChucDanhId = 1,
                            PhongBanId = 1
                        },
                        new
                        {
                            Id = 2,
                            ChucDanhId = 2,
                            PhongBanId = 1
                        },
                        new
                        {
                            Id = 3,
                            ChucDanhId = 3,
                            PhongBanId = 1
                        },
                        new
                        {
                            Id = 4,
                            ChucDanhId = 4,
                            PhongBanId = 1
                        },
                        new
                        {
                            Id = 5,
                            ChucDanhId = 1,
                            PhongBanId = 2
                        },
                        new
                        {
                            Id = 6,
                            ChucDanhId = 2,
                            PhongBanId = 2
                        },
                        new
                        {
                            Id = 7,
                            ChucDanhId = 3,
                            PhongBanId = 2
                        },
                        new
                        {
                            Id = 8,
                            ChucDanhId = 4,
                            PhongBanId = 2
                        },
                        new
                        {
                            Id = 9,
                            ChucDanhId = 1,
                            PhongBanId = 3
                        },
                        new
                        {
                            Id = 10,
                            ChucDanhId = 2,
                            PhongBanId = 3
                        },
                        new
                        {
                            Id = 11,
                            ChucDanhId = 3,
                            PhongBanId = 3
                        },
                        new
                        {
                            Id = 12,
                            ChucDanhId = 4,
                            PhongBanId = 3
                        },
                        new
                        {
                            Id = 13,
                            ChucDanhId = 1,
                            PhongBanId = 4
                        },
                        new
                        {
                            Id = 14,
                            ChucDanhId = 2,
                            PhongBanId = 4
                        },
                        new
                        {
                            Id = 15,
                            ChucDanhId = 3,
                            PhongBanId = 4
                        },
                        new
                        {
                            Id = 16,
                            ChucDanhId = 4,
                            PhongBanId = 4
                        },
                        new
                        {
                            Id = 17,
                            ChucDanhId = 1,
                            PhongBanId = 5
                        },
                        new
                        {
                            Id = 18,
                            ChucDanhId = 2,
                            PhongBanId = 5
                        },
                        new
                        {
                            Id = 19,
                            ChucDanhId = 3,
                            PhongBanId = 5
                        },
                        new
                        {
                            Id = 20,
                            ChucDanhId = 4,
                            PhongBanId = 5
                        });
                });

            modelBuilder.Entity("Models.PhuCap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhuCapTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bảo hiểm y tế"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bảo hiểm xã hội"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bảo hiểm thất nghiệp"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hưu trí"
                        });
                });

            modelBuilder.Entity("Models.QuanHuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TinhThanhId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TinhThanhId");

                    b.ToTable("QuanHuyenTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hà Đông",
                            TinhThanhId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Đống Đa",
                            TinhThanhId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hoàng Mai",
                            TinhThanhId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cầu Giấy",
                            TinhThanhId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ba Đình",
                            TinhThanhId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Quận 1",
                            TinhThanhId = 2
                        });
                });

            modelBuilder.Entity("Models.QuocGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuocGiaTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Việt Nam"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nhật Bản"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hoa Kỳ"
                        });
                });

            modelBuilder.Entity("Models.TaiSanCapPhat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaiSanCapPhatTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Máy tính"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chuột"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bàn phím"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ổ cứng"
                        });
                });

            modelBuilder.Entity("Models.TinhThanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuocGiaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuocGiaId");

                    b.ToTable("TinhThanhTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hà Nội",
                            QuocGiaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thành phố Hồ Chí Minh",
                            QuocGiaId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Đà Nẵng",
                            QuocGiaId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tokyo",
                            QuocGiaId = 2
                        });
                });

            modelBuilder.Entity("Models.XaPhuong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuanHuyenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuanHuyenId");

                    b.ToTable("XaPhuongTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "La Khê",
                            QuanHuyenId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Khâm Thiên",
                            QuanHuyenId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phương Liệt",
                            QuanHuyenId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dịch Vọng",
                            QuanHuyenId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mỹ Khê",
                            QuanHuyenId = 5
                        },
                        new
                        {
                            Id = 6,
                            Name = "Tân Định",
                            QuanHuyenId = 6
                        },
                        new
                        {
                            Id = 7,
                            Name = "Yên Hòa",
                            QuanHuyenId = 4
                        });
                });

            modelBuilder.Entity("Models.ChiNhanhNganHang", b =>
                {
                    b.HasOne("Models.NganHang", "NganHang")
                        .WithMany()
                        .HasForeignKey("NganHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.XaPhuong", "XaPhuong")
                        .WithMany()
                        .HasForeignKey("XaPhuongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NganHang");

                    b.Navigation("XaPhuong");
                });

            modelBuilder.Entity("Models.PhongBanChucDanh", b =>
                {
                    b.HasOne("Models.ChucDanh", "ChucDanh")
                        .WithMany()
                        .HasForeignKey("ChucDanhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.PhongBan", "PhongBan")
                        .WithMany()
                        .HasForeignKey("PhongBanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucDanh");

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("Models.QuanHuyen", b =>
                {
                    b.HasOne("Models.TinhThanh", "TinhThanh")
                        .WithMany()
                        .HasForeignKey("TinhThanhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TinhThanh");
                });

            modelBuilder.Entity("Models.TinhThanh", b =>
                {
                    b.HasOne("Models.QuocGia", "QuocGia")
                        .WithMany()
                        .HasForeignKey("QuocGiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuocGia");
                });

            modelBuilder.Entity("Models.XaPhuong", b =>
                {
                    b.HasOne("Models.QuanHuyen", "QuanHuyen")
                        .WithMany()
                        .HasForeignKey("QuanHuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuanHuyen");
                });
#pragma warning restore 612, 618
        }
    }
}