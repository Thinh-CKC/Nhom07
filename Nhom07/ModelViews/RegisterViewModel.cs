using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Nhom07.ModelViews
{
    public class RegisterViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Họ và Tên")]
        [Required(ErrorMessage ="Vui lòng nhập Họ Tên")]
        public string HoTen { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
     
        public string Email { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage ="Vui lòng nhập số điện thoại")]
        [Display(Name ="Điện thoại")]
        [DataType(DataType.PhoneNumber)]
   
        public string SDT { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        [MinLength(5,ErrorMessage ="Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        public string Password { get; set; }

        [MinLength(5,ErrorMessage ="Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        [Display(Name ="Nhập lại mật khẩu")]
        [Compare("Password",ErrorMessage ="Nhập lại mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }
    }
}
