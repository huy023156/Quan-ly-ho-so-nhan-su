﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
