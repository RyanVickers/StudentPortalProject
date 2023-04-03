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
                .Include(c => c.Announcements)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Get students in the course
            var courseStudents = await _context.Course
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);

            // Check if the current user is a student, teacher or admin of the course
            if (!course.Students.Any(s => s.Id == user.Id) && course.Teacher.Id != user.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseName,CourseDescription,Teacher")] Course course)
        {
            //Populate dropdown with teachers
            var teachers = await _userManager.GetUsersInRoleAsync("teacher");
            ViewBag.Teachers = new SelectList(teachers, "Id", "UserName");

            if (ModelState.IsValid)
            {
                //Save teacher and course
                var teacher = await _userManager.FindByIdAsync(course.Teacher.Id);
                course.Teacher = teacher;
                _context.Add(course);
                await _context.SaveChangesAsync();

                // Create default announcement for the course
                var announcement = new Announcement
                {
                    Title = "Welcome to " + course.CourseName + "!",
                    Message = "This is the default announcement for the " + course.CourseName + " course.",
                    Date = DateTime.Now,
                    Course = course
                };

                _context.Add(announcement);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(course);
            }
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Admin")]
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
            //Populate dropdown with teachers
            var teachers = await _userManager.GetUsersInRoleAsync("teacher");
            ViewBag.Teachers = new SelectList(teachers, "Id", "UserName");
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,CourseDescription,Teacher")] Course course)
        {
            //Populate dropdown with teachers
            var teachers = await _userManager.GetUsersInRoleAsync("teacher");
            ViewBag.Teachers = new SelectList(teachers, "Id", "UserName");

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
            else
            {
                return View(course);
            }
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
            //Filter out the students who are already enrolled in the course
            var enrolledStudentIds = await _context.Enrollments
                .Where(e => e.CourseId == id)
                .Select(e => e.StudentId)
                .ToListAsync();
            var studentsNotInCourse = students.Where(s => !enrolledStudentIds.Contains(s.Id));
            //Populates multiselect
            ViewBag.Students = new MultiSelectList(studentsNotInCourse, "Id", "UserName");
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
                        // Check if enrollment already exists
                        var existingEnrollment = await _context.Enrollments
                            .FirstOrDefaultAsync(e => e.CourseId == model.CourseId && e.StudentId == studentId);
                        if (existingEnrollment == null)
                        {
                            var enrollment = new Enrollment
                            {
                                CourseId = model.CourseId,
                                StudentId = studentId
                            };
                            _context.Enrollments.Add(enrollment);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("ClassList", "Courses", new { id = model.CourseId });
            }
            return View();
        }

        /*
		 * Function to remove students
		 */
        [HttpPost]
        [Authorize(Roles = "Teacher, Admin")]
        public async Task<IActionResult> RemoveStudent(int courseId, string studentId)
        {
            var course = await _context.Course.FindAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }

            var student = await _context.Users.FindAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);
            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction("ClassList", "Courses", new { id = courseId });
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

            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Check if the current user is a student, teacher or admin of the course
            if (!course.Students.Any(s => s.Id == user.Id) && course.Teacher.Id != user.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }
            return View(course);
        }

        /*
		 *  Function to display a list of groups within the course
		 */
        public async Task<IActionResult> GroupList(int id)
        {

            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Get the course by id
            var course = await _context.Course
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
            ViewBag.Course = course;

            if (course == null)
            {
                return NotFound();
            }

            // Check if the current user is a student, teacher or admin of the course
            if (!course.Students.Any(s => s.Id == user.Id) && course.Teacher.Id != user.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            var groups = await _context.Course
                .Include(c => c.Groups)
                .FirstOrDefaultAsync(c => c.Id == id);

            var userGroups = _context.GroupMembers
                .Where(gp => gp.StudentId == _userManager.GetUserId(User))
                .Join(_context.Groups.Where(g => g.CourseId == id), ug => ug.GroupId, g => g.Id, (ug, g) =>
                    new GroupMemberViewModel
                    {
                        UserName = ug.Student.UserName,
                        GroupId = g.Id,
                        GroupName = ug.Group.GroupName,
                    })
                .ToList();
            ViewData["UserGroups"] = userGroups;
            if (groups == null)
            {
                return NotFound();
            }
            return View(groups);
        }

        public async Task<IActionResult> Grades(int id)
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Get the course by id
            var course = await _context.Course
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
            ViewBag.Course = course;

            if (course == null)
            {
                return NotFound();
            }

            // Check if the current user is a student, teacher or admin of the course
            if (!course.Students.Any(s => s.Id == user.Id) && course.Teacher.Id != user.Id && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            // Get all assignments for the course
            var assignments = await _context.Assignment
                .Where(a => a.CourseId == id)
                .Select(a => new GradesViewModel
                {
                    AssignmentId = a.Id,
                    AssignmentName = a.Title,
                    CourseId = id,
                    Course = course,
                    Weight = a.Weight,
                    Grade = a.AssignmentSubmissions
                        .Where(s => s.StudentId == user.Id && s.Grade != null)
                        .Select(s => s.Grade)
                        .FirstOrDefault()
                })
                .ToListAsync();

            // Get the total weight of all assignments
            decimal totalWeight = assignments
                .Where(a => a.Grade.HasValue)
                .Sum(a => a.Weight);

            // Calculate the sum of the weighted grades
            decimal weightedGradeSum = assignments
                .Where(a => a.Grade.HasValue)
                .Sum(a => a.Weight * a.Grade.Value);

            // Calculate the overall grade average with weights
            decimal overallGrade = totalWeight > 0
                ? weightedGradeSum / totalWeight
                : 0;

            ViewBag.OverallGrade = overallGrade.ToString("F2");

            return View(assignments);
        }
    }
}
