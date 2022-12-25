using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom07.Models
{
    public class TaiKhoan
    {
        public int ID { get; set; }

        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Username { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Password { get; set; }

        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        public string Email { get; set; }

        [DisplayName("SĐT")]
        [RegularExpression(@"0\d{9}", ErrorMessage = "SĐT không hợp lệ")]
        public int SDT { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }

        // Collection navigation property cho khóa ngoại từ HoaDon
        public List<HoaDon> HoaDons { get; set; }

        // Collection navigation property cho khóa ngoại từ GioHang
        public List<GioHang> GioHangs { get; set; }
    }
}
