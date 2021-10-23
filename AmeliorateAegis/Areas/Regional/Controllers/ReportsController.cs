using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Controllers
{
    [Area("Regional")]
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
