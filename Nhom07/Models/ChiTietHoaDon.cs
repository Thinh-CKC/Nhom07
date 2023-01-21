using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom07.Models
{
    public class ChiTietHoaDon
    {
        public int ID { get; set; }

        [DisplayName("Hóa đơn")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public int HoaDonID { get; set; }

        // Reference navigation property cho khóa ngoại đến HoaDon
        [DisplayName("Hóa đơn")]
        public HoaDon HoaDon { get; set; }

        [DisplayName("Sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public int SanPhamID { get; set; }

        // Reference navigation property cho khóa ngoại đến SanPham
        [DisplayName("Sản phẩm")]
        public SanPham SanPham { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        [DisplayName("Giá")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Gia { get; set; }
    }
}
