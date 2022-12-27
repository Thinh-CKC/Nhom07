using Microsoft.AspNetCore.Mvc;

namespace Nhom07.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Detail()
		{
			return View();
		}

		public IActionResult Edit()
		{
			return View();
		}
	}
}
