using Microsoft.AspNetCore.Mvc;
using Nhom07.Models;
using Nhom7.Data;
using System.Diagnostics;

namespace Nhom07.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Nhom7Context _context;
        public HomeController(Nhom7Context context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }



        public IActionResult Index()
        {

            var men = _context.SanPhams.Where(x => x.NoiBat == true).Where(x => x.LoaiSanPhamID == 1).ToList();
            var women = _context.SanPhams.Where(x => x.NoiBat == true).Where(x => x.LoaiSanPhamID == 2).ToList();
            var product = _context.SanPhams.ToList();
            ViewBag.men=men;
            ViewBag.women=women;

            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}