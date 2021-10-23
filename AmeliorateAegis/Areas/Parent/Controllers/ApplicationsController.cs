using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmeliorateAegis.Data;
using AmeliorateAegis.Models.Applications;

namespace AmeliorateAegis.Areas.Parent.Controllers
{
    [Area("Parent")]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parent/Applications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Application.Include(a => a.Centre).Include(a => a.Parent).Include(a => a.Pupil);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parent/Applications/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Centre)
                .Include(a => a.Parent)
                .Include(a => a.Pupil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Parent/Applications/Create
        public IActionResult Create()
        {
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Id");
            ViewData["ParentId"] = new SelectList(_context.Parents, "Id", "Id");
            ViewData["PupilId"] = new SelectList(_context.Pupils, "Id", "Id");
            return View();
        }

        // POST: Parent/Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreationTime,ModifiedTime,ParentId,PupilId,CentreId,Status")] Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Id", application.CentreId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "Id", "Id", application.ParentId);
            ViewData["PupilId"] = new SelectList(_context.Pupils, "Id", "Id", application.PupilId);
            return View(application);
        }

        // GET: Parent/Applications/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Id", application.CentreId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "Id", "Id", application.ParentId);
            ViewData["PupilId"] = new SelectList(_context.Pupils, "Id", "Id", application.PupilId);
            return View(application);
        }

        // POST: Parent/Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CreationTime,ModifiedTime,ParentId,PupilId,CentreId,Status")] Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Id", application.CentreId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "Id", "Id", application.ParentId);
            ViewData["PupilId"] = new SelectList(_context.Pupils, "Id", "Id", application.PupilId);
            return View(application);
        }

        // GET: Parent/Applications/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Centre)
                .Include(a => a.Parent)
                .Include(a => a.Pupil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Parent/Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var application = await _context.Application.FindAsync(id);
            _context.Application.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(long id)
        {
            return _context.Application.Any(e => e.Id == id);
        }
    }
}
