using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom07.Models;
using Nhom7.Data;

namespace Nhom07.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private Nhom7Context _context;

        public ProductController(Nhom7Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.SanPhams.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ID,SKU,TenSP,LoaiSanPhamID,Size,MauSac,MatKinh,LoaiDay,TonKho,Anh,Gia,NoiBat")] SanPham product)
        {
            if (_context.SanPhams.Any(a => a.ID == product.ID))
            {
                ViewBag.Error = "Sản phẩm đã tồn tại.";
                return View();
            }
            else
            {
                _context.SanPhams.Add(product);
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
            var product = _context.SanPhams.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.SanPhams.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID,SKU,TenSP,LoaiSanPhamID,Size,MauSac,MatKinh,LoaiDay,TonKho,Anh,Gia,NoiBat")] SanPham product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }
            if (product.SKU == 0)
            {
                product.SKU = _context.SanPhams.AsNoTracking()
                                           .FirstOrDefault(a => a.ID == id).SKU;
            }
            _context.SanPhams.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.SanPhams.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.SanPhams.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
