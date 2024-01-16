using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05.Entity
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<CongThuc> CongThuc { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V5E7153\\SQLEXPRESS;Database=EF_05;Trusted_Connection = True;TrustServerCertificate=True");
        }
    }
}
