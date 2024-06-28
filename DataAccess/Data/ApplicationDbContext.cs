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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucDanh>().HasData(
                new ChucDanh { Id = 1, Name = "Giám đốc trung tâm" },
                new ChucDanh { Id = 2, Name = "Phó giám đốc trung tâm"},
                new ChucDanh { Id = 3, Name = "Leader"},
                new ChucDanh { Id = 4, Name = "Nhân viên"}
                );
        }
}
