using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom07.Models
{
    public class TaiKhoan
    {
        public int ID { get; set; }


        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
       
        public string Email { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string SDT { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        public string Password { get; set; }

        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }

        // Collection navigation property cho khóa ngoại từ HoaDon
        public List<HoaDon> HoaDons { get; set; }

        // Collection navigation property cho khóa ngoại từ GioHang
        public List<GioHang> GioHangs { get; set; }
    }
}
