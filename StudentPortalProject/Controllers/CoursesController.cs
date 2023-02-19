using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
using StudentPortalProject.Data.Migrations;
using StudentPortalProject.Models;
using System.Data;

namespace StudentPortalProject.Controllers
{
	[Authorize]
	public class CoursesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public CoursesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
		{
			_context = context;
			_userManager = userManager;
			_userManager.Users.ToList();

		}

		//TODO: Let teacher or admin view all students and assign them to classes

		// GET: Courses
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			var role = await _userManager.GetRolesAsync(user);
			List<Course> courses;
			if (role.Contains("Student"))
			{
				courses = await _context.Course
					.Include(c => c.Students)
					.Where(c => c.Students.Any(e => e.Id == user.Id))
					.ToListAsync();
			}
			else if (role.Contains("Teacher"))
			{
				courses = await _context.Course
					.Where(c => c.TeacherId == user.Id)
					.ToListAsync();
			}
			else if (role.Contains("Admin"))
			{
				courses = await _context.Course.ToListAsync();
			}
			else
			{
				courses = new List<Course>();
			}
			return View(courses);
		}

		// GET: Courses/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Course == null)
			{
				return NotFound();
			}

			var course = await _context.Course
				.FirstOrDefaultAsync(m => m.Id == id);
			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// GET: Courses/Create
		public async Task<IActionResult> CreateAsync()
		{
			//Populate dropdown with teachers
			var teachers = await _userManager.GetUsersInRoleAsync("teacher");
			ViewBag.Teachers = new SelectList(teachers, "Id", "UserName");
			return View();
		}

		// POST: Courses/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Teacher, Admin")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,CourseName,CourseDescription,Teacher")] Course course)
		{
			//Populate dropdown with teachers
			var teachers = await _userManager.GetUsersInRoleAsync("teacher");
			ViewBag.Teachers = new SelectList(teachers, "Id", "UserName");
			//Save teacher and course
			var teacher = await _userManager.FindByIdAsync(course.Teacher.Id);
			course.Teacher = teacher;
			_context.Add(course);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Courses/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Course == null)
			{
				return NotFound();
			}

			var course = await _context.Course.FindAsync(id);
			if (course == null)
			{
				return NotFound();
			}
			var users = _userManager.Users.ToList();
			ViewBag.Teachers = new SelectList(users, "Id", "UserName");
			return View(course);
		}

		// POST: Courses/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,CourseDescription,Teacher")] Course course)
		{
			//Populate dropdown of teachers fore edit page
			var users = _userManager.Users.ToList();
			ViewBag.Teachers = new SelectList(users, "Id", "UserName");
			if (id != course.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var teacher = await _userManager.FindByIdAsync(course.Teacher.Id);
					course.Teacher = teacher;
					_context.Update(course);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CourseExists(course.Id))
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
			return View(course);
		}

		// GET: Courses/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Course == null)
			{
				return NotFound();
			}

			var course = await _context.Course
				.FirstOrDefaultAsync(m => m.Id == id);
			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// POST: Courses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Course == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Course'  is null.");
			}
			var course = await _context.Course.FindAsync(id);
			if (course != null)
			{
				_context.Course.Remove(course);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CourseExists(int id)
		{
			return _context.Course.Any(e => e.Id == id);
		}

		/*
		 * Function to get students to add to the course
		 */
		[HttpGet]
		[Authorize(Roles = "Teacher, Admin")]
		public async Task<IActionResult> AddStudents(int id)
		{
			//Gets list of students
			var students = await _userManager.GetUsersInRoleAsync("student");
			//Populates multiselect
			ViewBag.Students = new MultiSelectList(students, "Id", "UserName");
			return View(new AddStudentsViewModel { CourseId = id });
		}

		/*
		 * Function to save student to a course
		 */
		[HttpPost]
		[Authorize(Roles = "Teacher, Admin")]
		public async Task<IActionResult> AddStudents(AddStudentsViewModel model)
		{
			var course = await _context.Course.FindAsync(model.CourseId);
			if (course == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				//Creates enrollment object with a course and student
				foreach (var studentId in model.SelectedStudents)
				{
					var student = await _context.ApplicationUsers.FindAsync(studentId);
					if (student != null)
					{
						var enrollment = new Enrollment
						{
							Course = course,
							Student = student
						};
						_context.Enrollments.Add(enrollment);
					}
				}
				await _context.SaveChangesAsync();
				return RedirectToAction("Details", "Courses", new { id = model.CourseId });
			}
			return View();
		}

		/*
		 * Function to display a list of students in a course
		 */
		public async Task<IActionResult> ClassList(int id)
		{
			var course = await _context.Course
				.Include(c => c.Students)
				.FirstOrDefaultAsync(c => c.Id == id);
			if (course == null)
			{
				return NotFound();
			}
			return View(course);
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

        /*
		 * Function to get lectures view
		 */
        public async Task<IActionResult> Lectures(int? id)
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

        /*
		 * Function to get create lectures view
		 */
        public IActionResult CreateLecture(int id)
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
        public async Task<IActionResult> CreateLecture(int id, [Bind("Title,Description")] Lecture lecture, IFormFileCollection files)
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

            return RedirectToAction("Lectures", new { id = course.Id });
        }

    }
}
