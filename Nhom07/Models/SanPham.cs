using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom07.Models
{
    public class SanPham
    {
        public int ID { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string TenSP { get; set; }

        [DisplayName("Loại sản phẩm")]
        public int ID_LoaiSP { get; set; }

        // Reference navigation property cho khóa ngoại đến LoaiSanPham 
        [DisplayName("Loại sản phẩm")]
        public LoaiSanPham LoaiSanPham { get; set; }

        [DisplayName("Size")]
        public string Size { get; set; }
        
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }

        [DisplayName("Tồn kho")]
        public int TonKho { get; set; }

        [DisplayName("Mặt kính")]
        public string MatKinh { get; set; }

        [DisplayName("Loại dây")]
        public string LoaiDay { get; set; }
        [DisplayName("Hình ảnh")]
        public string Anh { get; set; }

        [DisplayName("Giá")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Gia { get; set; }

        [DisplayName("Nổi bật")]
        public bool NoiBat { get; set; }

        // Collection navigation property cho khóa ngoại từ GioHang
        public List<GioHang> GioHangs { get; set; }

        // Collection navigation property cho khóa ngoại từ ChiTietHoaDon
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        // Collection navigation property cho khóa ngoại từ HinhAnh
        public List<HinhAnh> HinhAnhs { get; set; }

    }
}
