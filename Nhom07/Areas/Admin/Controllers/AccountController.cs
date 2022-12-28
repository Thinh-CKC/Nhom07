using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom07.Models;
using Nhom7.Data;
using System.Security.Principal;

namespace Nhom07.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
		private Nhom7Context _context;

		public AccountController(Nhom7Context context)
		{
			_context = context;
		}

        public IActionResult Index()
        {
            return View(_context.TaiKhoans.ToList());
        }

		public IActionResult Create()
		{
			return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ID,HoTen,Email,SDT,DiaChi,Password,IsAdmin")] TaiKhoan account)
        {
            if (_context.TaiKhoans.Any(a => a.Email == account.Email))
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại.";
                return View();
            }
            else
            {
                _context.TaiKhoans.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Detail(int? id)
		{
            if (id == null)
            {
                return NotFound();
            }
            var account = _context.TaiKhoans.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
		}

		public IActionResult Edit(int? id)
		{
            if (id == null)
            {
                return NotFound();
            }
            var account = _context.TaiKhoans.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
		}

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID,HoTen,Email,SDT,DiaChi,Password,IsAdmin")] TaiKhoan account)
        {
            if (id != account.ID)
            {
                return NotFound();
            }
            if (account.Password == null)
            {
                account.Password = _context.TaiKhoans.AsNoTracking()
                                           .FirstOrDefault(a => a.ID == id).Password;
            }
            _context.TaiKhoans.Update(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = _context.TaiKhoans.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            _context.TaiKhoans.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
