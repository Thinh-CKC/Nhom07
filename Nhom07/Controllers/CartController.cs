using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom07.Models;
using Nhom7.Data;

namespace Nhom07.Controllers
{
    public class CartController : Controller
    {
        private readonly Nhom7Context _context;
        public INotyfService _notyfService { get; }
        public CartController(Nhom7Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Route("cart", Name = "Giohang")]
        public async Task<IActionResult> Index()
        {
            string username = HttpContext.Session.GetString("Username");
            var giohang = _context.GioHangs.
                           Include(c => c.TaiKhoan).
                           Include(c => c.SanPham).
                           Where(c => c.TaiKhoan.Email == username);
            return View(await giohang.ToListAsync());

        }

        [HttpPost]
       
        public IActionResult Add(int ProductId, int Quantity)
        {
            string username = HttpContext.Session.GetString("Username");
            //string username = "admin";
            if (username == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var accountsId = _context.TaiKhoans.FirstOrDefault(a => a.Email == username).ID;
            var cart = _context.GioHangs.Where(c => c.TaiKhoanID == accountsId && c.SanPhamID == ProductId).FirstOrDefault();

            if (cart != null)
            {
                cart.SoLuong += Quantity;
                _context.GioHangs.Update(cart);
            }
            else
            {
                cart = new GioHang
                {
                    TaiKhoanID = accountsId,
                    SanPhamID = ProductId,
                    SoLuong = Quantity =1
                };
                _context.GioHangs.Add(cart);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int? id, int quantity)
        {
            if (id == null || _context.GioHangs == null)
            {
                return NotFound();
            }

            var cart = await _context.GioHangs
                .Include(c => c.TaiKhoan)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            cart.SoLuong = quantity;
            if (cart == null)
            {
                return NotFound();
            }
            if (cart.SanPham.TonKho < cart.SoLuong)
            {
                ViewBag.ErrorMsg = "Login failed!";
                cart.SoLuong = cart.SanPham.TonKho;
                _context.GioHangs.Update(cart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            _context.GioHangs.Update(cart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GioHangs == null)
            {
                return NotFound();
            }

            var cart = await _context.GioHangs
                .Include(c => c.TaiKhoan)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cart == null)
            {
                return NotFound();
            }
            _context.GioHangs.Remove(cart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
