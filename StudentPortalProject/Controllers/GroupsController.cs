using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
using StudentPortalProject.Models;

namespace StudentPortalProject.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groups.Include(@ => @.Course).Include(@ => @.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(@ => @.Course)
                .Include(@ => @.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }
        */

        // GET: Groups/Create
        public IActionResult Create(int id)
        {
            ViewData["Courses"] = new SelectList(_context.Course, "Id", "Id");
            ViewBag.CourseId = id;
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupName,CourseId")] Group @group)
        {
            var course = await _context.Course.FindAsync(group.CourseId);
            group.Course = course;
            _context.Add(group);
            await _context.SaveChangesAsync();
            return RedirectToAction("GroupList", "Courses", new { id = group.CourseId });
        }

        // GET: Add students to the group
        [HttpGet]
        public async Task<IActionResult> AddStudents(int groupId, int courseId)
        {
            ViewData["CourseId"] = courseId;
            if (groupId == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(groupId);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", @group.CourseId);

            var students = await _context.Course
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == group.CourseId);
            ViewBag.Students = new MultiSelectList(students.Students, "Id", "UserName");

            return View(new AddStudentsViewModel { CourseId = groupId });
        }

        // POST: Add students to the group
        [HttpPost]
        public async Task<IActionResult> AddStudents(AddStudentsViewModel model)
        {
            var group = await _context.Groups.FindAsync(model.CourseId);
            if (group == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //Creates GroupMember object with a group and student
                foreach (var studentId in model.SelectedStudents)
                {
                    var student = await _context.ApplicationUsers.FindAsync(studentId);
                    if (student != null)
                    {
                        var grpMember = new GroupMember
                        {
                            Group = group,
                            Student = student
                        };
                        _context.GroupMembers.Add(grpMember);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("GroupList", "Courses", new { id = group.CourseId });
            }
            return View();
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", @group.CourseId);
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName,CourseId")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", @group.CourseId);
			return RedirectToAction("GroupList", "Courses", new { id = group.CourseId });
		}

        
        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", @group.CourseId);
            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groups == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Groups'  is null.");
            }
            var @group = await _context.Groups.FindAsync(id);
            var groupMembers = await _context.GroupMembers.Where(c => c.GroupId == id).ToListAsync();
            if (groupMembers != null) {
                foreach(var member in groupMembers)
                {
                    _context.GroupMembers.Remove(member);
                }
            }
            if (@group != null)
            {
                _context.Groups.Remove(@group);
            }
            
            await _context.SaveChangesAsync();
			return RedirectToAction("GroupList", "Courses", new { id = group.CourseId });
		}
        
        private bool GroupExists(int id)
        {
          return _context.Groups.Any(e => e.Id == id);
        }
    }
}
