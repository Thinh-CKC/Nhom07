using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom07.Models;
using Nhom7.Data;
using Nhom07.Extension;
using Nhom07.ModelViews;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Nhom07.Controllers
{
    public class AccountController : Controller
    {
        private readonly Nhom7Context _context;
        public INotyfService _notyfService { get; }
        public AccountController(Nhom7Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        //Get register
       

        [HttpGet]
        [AllowAnonymous]
        [Route("Register", Name = "DangKy")]
        public IActionResult DangkyTaiKhoan()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Register", Name = "DangKy")]
        public async Task<IActionResult> DangkyTaiKhoan(RegisterViewModel taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaiKhoan khachhang = new TaiKhoan
                    {
                        Email = taikhoan.Email,
                        Password = taikhoan.Password.ToMD5(),
                        DiaChi = taikhoan.DiaChi,
                        HoTen = taikhoan.HoTen,
                        SDT = taikhoan.SDT,
                        IsAdmin = false
                    };
                    var check = _context.TaiKhoans.FirstOrDefault(s => s.Email == taikhoan.Email);
                    if (check == null)
                    { _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        

                            _notyfService.Success("Đăng ký thành công");
                            return RedirectToAction("Login");
                    
                    }
                    else
                    {
                        _notyfService.Error("Email already exists");
                        return View();

                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return RedirectToAction("DangkyTaiKhoan", "Account");
            }
           

        }
        [AllowAnonymous]
        [Route("Login", Name = "DangNhap")]
        public IActionResult Login()
        {
       
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Login", Name = "DangNhap")]
        public async Task<IActionResult> Login( LoginViewModel taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var khachhang = _context.TaiKhoans.Where(a => a.Email.Equals(taikhoan.UserName)).FirstOrDefault();

                    if(khachhang!=null)
                    {
                        string pass = taikhoan.Password.ToMD5();
                        if (khachhang.Password == pass)
                        {
                            var indentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, khachhang.HoTen) }, CookieAuthenticationDefaults.AuthenticationScheme);

                            var principal = new ClaimsPrincipal(indentity);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("Username", khachhang.Email);
                            _notyfService.Success("Đăng nhập thành công");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            _notyfService.Error("Thông tin đăng nhập chưa chính xác");
                            return View(taikhoan);
                        }
                     
                    }    
                    else
                            {
                        _notyfService.Error("Tài khoản không tồn tại");
                        return View(taikhoan);

                    }
                }
            }
            catch
            {
                _notyfService.Error("Lỗi");
                return View(taikhoan);
            }
            return View(taikhoan);

        }

        [HttpGet]
        [Route("Logout", Name = "DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Home");
        }

        [Route("my-account", Name = "TaiKhoan")]
        public IActionResult MyAccount()
        {
            var taikhoanUsername = HttpContext.Session.GetString("Username");
            if (taikhoanUsername != null)
            {
                var khachhang = _context.TaiKhoans.AsNoTracking().SingleOrDefault(x => x.Email == taikhoanUsername);
                if (khachhang != null)
                {
                    var lsDonHang = _context.HoaDons
                        .AsNoTracking()
                        .Where(x => x.ID == khachhang.ID)
                        .OrderByDescending(x => x.NgayTao)
                        .ToList();
                    ViewBag.DonHang = lsDonHang;
                    return View(khachhang);
                }

            }
            return RedirectToAction("Login");
        }
    }


  }

