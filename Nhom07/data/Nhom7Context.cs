using Microsoft.EntityFrameworkCore;
using Nhom07.Models;

namespace Nhom7.Data
{
    public class Nhom7Context : DbContext
    {
        public Nhom7Context(DbContextOptions<Nhom7Context>
        options) : base(options)
        { }
        public DbSet <SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<HinhAnh> HinhAnhs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    }
}

