﻿using Microsoft.AspNetCore.Mvc;

namespace Nhom07.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Detail()
		{
			return View();
		}
	}
}
