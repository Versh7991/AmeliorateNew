using AmeliorateAegis.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminUsersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _db.ApplicationUsers
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync();

            return View(users);
        }
    }
}
