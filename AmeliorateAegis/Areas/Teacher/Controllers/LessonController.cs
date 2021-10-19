using AmeliorateAegis.Data;
using AmeliorateAegis.Models;
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
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public LessonController(ApplicationDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var lessonVM = new LessonViewModel
            {
                LessonPlans = await _db.LessonPlans.ToListAsync()
            };
            return View(lessonVM);
        }

        // Lessons
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonViewModel lessonVm)
        {
            if (ModelState.IsValid)
            {
                var lesson = new LessonPlan
                {
                    Description = lessonVm.Lesson.Description,
                    TeacherId = 1,
                    StartTime = DateTime.Now,
                    Day = lessonVm.Lesson.Day,
                    EndTime = DateTime.Now.AddHours(2)
                };
                _db.Add(lesson);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(lessonVm);
        }
    }
}
