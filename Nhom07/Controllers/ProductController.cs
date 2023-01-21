using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom07.Models;
using Nhom7.Data;
using System.Linq;
using System.Xml.Linq;

namespace Nhom07.Controllers
{
    public class ProductController : Controller
    {
        private readonly Nhom7Context _context;
        public ProductController(Nhom7Context context)
        {
            _context = context;
        }
        [Route("/Shop", Name="ShopProduct")]
        public IActionResult Index()
        {
            var category = _context.LoaiSanPhams.ToList();
            var product = _context.SanPhams.ToList();
            ViewBag.category=category;
            return View(product);
        }
        [Route("/product/{id}", Name = "ProductDetails")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
  
            var product = _context.SanPhams.Find(id);
            if (product==null)
            { 
                return NotFound();
            }

            ViewBag.HinhAnhs = _context.HinhAnhs.Where(h => h.SanPhamID == product.ID).ToList();

            return View(product);
        }
    }
}
