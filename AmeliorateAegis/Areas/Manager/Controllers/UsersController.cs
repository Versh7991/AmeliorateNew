using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
