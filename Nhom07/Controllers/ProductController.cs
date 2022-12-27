using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom7.Data;
using System.Xml.Linq;

namespace Nhom07.Controllers
{
    public class ProductController : Controller
    {
       private Nhom7Context _context;
        public ProductController(Nhom7Context context)
        {
            _context = context;
        }
        [Route("/Shop", Name="ShopProduct")]
        public IActionResult Index()
        {
            var category = _context.LoaiSanPhams.ToList();
            var men = _context.SanPhams.Where(x=>x.NoiBat==true).Where(x=>x.ID_LoaiSP==1).ToList();
            var women = _context.SanPhams.Where(x => x.NoiBat == true).Where(x => x.ID_LoaiSP == 2).ToList();
            var product = _context.SanPhams.ToList();
            ViewBag.category=category;
            return View(product);
        }
        [Route("/product/{id}", Name = "ProductDetails")]
        public IActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var product = _context.SanPhams.Find(id);
            if (product==null)
            {
                return NotFound();
            }
         
            return View(product);
        }
    }
}
