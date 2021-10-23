using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Parent.Controllers
{
    [Area("Parent")]
    public class ChildrenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
