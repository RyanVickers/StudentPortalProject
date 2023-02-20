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
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lectures
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.Include(c => c.Lectures).ThenInclude(l => l.LectureFiles).FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Lectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lectures == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .Include(l => l.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        /*
		 * Function to get create lectures view
		 */
        public IActionResult Create(int id)
        {
            var course = _context.Course.Include(c => c.Lectures).FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var model = new Lecture { CourseId = id };

            return View(model);
        }

        /*
		 * Function to create lectures
		 */
        [HttpPost]
        public async Task<IActionResult> Create(int id, [Bind("Title,Description")] Lecture lecture, IFormFileCollection files)
        {
            var course = _context.Course.Include(c => c.Lectures).FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {

                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        var fileData = ms.ToArray();

                        var newFile = new LectureFile
                        {
                            FileName = file.FileName,
                            FileData = fileData,
                            Lecture = lecture,
                        };
                        lecture.LectureFiles.Add(newFile);
                    }
                }
            }

            lecture.Course = course;
            _context.Lectures.Add(lecture);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { id });
        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lectures == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", lecture.CourseId);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CourseId")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lectures == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .Include(l => l.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lectures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lectures'  is null.");
            }
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture != null)
            {
                _context.Lectures.Remove(lecture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(int id)
        {
          return _context.Lectures.Any(e => e.Id == id);
        }

        public IActionResult DownloadFile(int id)
        {
            var file = _context.LectureFiles.Find(id);

            if (file == null)
            {
                return NotFound();
            }

            return File(file.FileData, "application/octet-stream", file.FileName);
        }
    }
}
