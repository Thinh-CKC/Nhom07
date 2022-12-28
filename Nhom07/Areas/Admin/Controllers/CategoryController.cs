using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom07.Models;
using Nhom7.Data;

namespace Nhom07.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private Nhom7Context _context;

        public CategoryController(Nhom7Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.LoaiSanPhams.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ID,LoaiSP")] LoaiSanPham category)
        {
            if (_context.LoaiSanPhams.Any(a => a.LoaiSP == category.LoaiSP))
            {
                ViewBag.Error = "Loại sản phẩm đã tồn tại.";
                return View();
            }
            else
            {
                _context.LoaiSanPhams.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }             

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _context.LoaiSanPhams.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID,LoaiSP")] LoaiSanPham category)
        {
            if (id != category.ID)
            {
                return NotFound();
            }
            if (category.LoaiSP == null)
            {
                category.LoaiSP = _context.LoaiSanPhams.AsNoTracking()
                                           .FirstOrDefault(a => a.ID == id).LoaiSP;
            }
            _context.LoaiSanPhams.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _context.LoaiSanPhams.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.LoaiSanPhams.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
