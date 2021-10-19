using AmeliorateAegis.Data;
using AmeliorateAegis.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public DashboardController(ApplicationDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var pupils = await _db.Pupils.OrderByDescending(x => x.CreationTime).Take(8).ToListAsync();
            var dashboardVM = new DashboardViewModel
            {
                Pupils = pupils,
                PupilCount = await _db.Pupils.CountAsync(),
                ParentCount = await _db.Parents.CountAsync(),
                LessonCount = await _db.LessonPlans.CountAsync()
            };
            return View(dashboardVM);
        }
    }
}
