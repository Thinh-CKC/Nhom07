using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nhom07.Models;
using Nhom7.Data;
using WebShop.Extension;
using Nhom07.ModelViews;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using WebShop.Helpper;
using Microsoft.EntityFrameworkCore;

namespace Nhom07.Controllers
{
    public class AccountController : Controller
    {
        private Nhom7Context _context;
        public INotyfService _notyfService { get; }
        public AccountController(Nhom7Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        //Get register
        //POST: Register

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
                            //Lưu Session MaKh
                            HttpContext.Session.SetString("CustomerId", khachhang.ID.ToString());
                            var taikhoanID = HttpContext.Session.GetString("CustomerId");

                        //Identity
                        var claims = new List<Claim>
                            {

                            new Claim(ClaimTypes.Name,khachhang.HoTen),
                            new Claim("CustomerId", khachhang.ID.ToString())
                            };
                            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimsPrincipal);
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
        [HttpGet]
        [Route("Login", Name = "DangNhap")]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [Route("Login", Name = "DangNhap")]
        public async Task<IActionResult> Login( LoginViewModel taikhoan, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(taikhoan.UserName);
                    if (!isEmail) return View(taikhoan);

                    var khachhang = _context.TaiKhoans.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == taikhoan.UserName);

                    string pass = taikhoan.Password.ToMD5();
                    if (khachhang.Password != pass)
                    {
                        _notyfService.Error("Thông tin đăng nhập chưa chính xác");
                        return View(taikhoan);
                    }
                 
                    //Luu Session MaKh
                    HttpContext.Session.SetString("CustomerId", khachhang.ID.ToString());
                    var taikhoanID = HttpContext.Session.GetString("CustomerId");

                    //Identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.HoTen),
                        new Claim("CustomerId", khachhang.ID.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công");
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                _notyfService.Error("Tài khoản không tồn tại");
              
            }
            return View(taikhoan);

        }

        [HttpGet]
        [Route("Logout", Name = "DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }
    }


  }

