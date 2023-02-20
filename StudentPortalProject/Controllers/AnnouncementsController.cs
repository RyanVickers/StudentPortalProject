using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
using StudentPortalProject.Models;

namespace StudentPortalProject.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.Include(c => c.Announcements).FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Announcement == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        [HttpGet]
        public IActionResult Create(int id)
        {
            var course = _context.Course.Include(c => c.Announcements).FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var model = new Announcement { CourseId = id };

            return View(model);
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Title,Message,Date")] Announcement announcement)
        {
            var course = await _context.Course.Include(c => c.Announcements).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
                announcement.Course = course;
                announcement.Date = DateTime.Now;
                _context.Add(announcement);
                await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id });
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Announcement == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", announcement.CourseId);
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Message,Date,CourseId")] Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", announcement.CourseId);
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Announcement == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcement
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Announcement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Announcement'  is null.");
            }
            var announcement = await _context.Announcement.FindAsync(id);
            if (announcement != null)
            {
                _context.Announcement.Remove(announcement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
          return _context.Announcement.Any(e => e.Id == id);
        }
    }
}
