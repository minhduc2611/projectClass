using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.DataModels
{
    public class MyDbContext : DbContext
    {
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<QuaTang> QuaTangs { get; set; }
        public DbSet<NhanQua> NhanQuas { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }
    }
}
