using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
using StudentPortalProject.Data.Migrations;
using StudentPortalProject.Models;

namespace StudentPortalProject.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AssignmentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _userManager.Users.ToList();
        }

        /*
        * Function to get assignments view
        */
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.Include(c => c.Assignments).ThenInclude(l => l.AssignmentFiles).FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Assignments/Details/5
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        [HttpGet]
		[Authorize(Roles = "Admin,Teacher")]
		public IActionResult Create(int id)
        {
            var course = _context.Course.Include(c => c.Assignments).FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var model = new Assignment { CourseId = id };

            return View(model);
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Teacher")]
		public async Task<IActionResult> Create(int id, [Bind("Title,Description,DueDate,Weight")] Assignment assignment, IFormFileCollection files)
		{
			var course = await _context.Course.Include(c => c.Assignments).FirstOrDefaultAsync(c => c.Id == id);
			if (course == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				if (files != null && files.Count > 0)
				{
					foreach (var file in files)
					{
						using (var ms = new MemoryStream())
						{
							await file.CopyToAsync(ms);
							var fileData = ms.ToArray();

							var newFile = new AssignmentFile
							{
								FileName = file.FileName,
								FileData = fileData,
								Assignment = assignment,
							};
							assignment.AssignmentFiles.Add(newFile);
						}
					}
				}

				assignment.Course = course;
				_context.Assignments.Add(assignment);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index), new { id });
			}
			else
			{
				return View(assignment);
			}
		}

		// GET: Assignments/Edit/5
		[Authorize(Roles = "Admin,Teacher")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment.Include(a => a.AssignmentFiles).FirstOrDefaultAsync(a => a.Id == id);
			if (assignment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", assignment.CourseId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Teacher")]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,Weight,CourseId")] Assignment assignment, IFormFileCollection files)
		{
			if (id != assignment.Id)
			{
				return NotFound();
			}

			var course = await _context.Course.FirstOrDefaultAsync(c => c.Id == assignment.CourseId);

			if (course == null)
			{
				return NotFound();
			}

			assignment.Course = course;

			if (ModelState.IsValid)
			{
				try
				{
					if (files != null && files.Count > 0)
					{
						foreach (var file in files)
						{
							using (var ms = new MemoryStream())
							{
								await file.CopyToAsync(ms);
								var fileData = ms.ToArray();

								var newFile = new AssignmentFile
								{
									FileName = file.FileName,
									FileData = fileData,
									Assignment = assignment
								};
								assignment.AssignmentFiles.Add(newFile);
							}
						}
					}

					_context.Update(assignment);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AssignmentExists(assignment.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return RedirectToAction(nameof(Index), new { id = assignment.CourseId });
			}
			else
			{
				return View(assignment);
			}
		}

		// GET: Assignments/Delete/5
		[Authorize(Roles = "Admin,Teacher")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Teacher")]
		public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assignment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Assignment'  is null.");
            }
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignment.Remove(assignment);
            }
            
            await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index), new { id = assignment.CourseId });
		}

        private bool AssignmentExists(int id)
        {
          return _context.Assignment.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult SubmitAssignment(int id)
        {
            var student = _userManager.GetUserAsync(User).Result;

            var assignment = _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefault(a => a.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            var submission = new AssignmentSubmission
            {
                AssignmentId = assignment.Id,
                Assignment = assignment,
                StudentId = student.Id,
                Student = student,
                SubmissionDate = DateTime.Now
            };

            return View(submission);
        }

        /*
         * Function to submit assignments 
         */
        [HttpPost]
        public async Task<IActionResult> SubmitAssignment(int id, IFormFile[] submissionFiles)
        { 
            var student = await _userManager.GetUserAsync(User);
            var assignment = await _context.Assignments.FindAsync(id);
          
            var submission = new AssignmentSubmission
            {
                AssignmentId = assignment.Id,
                Assignment = assignment,
                StudentId = student.Id,
                Student = student,
                SubmissionDate = DateTime.Now,
                Grade = null,
                SubmissionFiles = new List<SubmissionFile>()
            };

           
            _context.AssignmentSubmissions.Add(submission);
            await _context.SaveChangesAsync();
 
            foreach (var file in submissionFiles)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileData = new byte[file.Length];
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        fileData = stream.ToArray();
                    }

                    var submissionFile = new SubmissionFile
                    {
                        FileName = fileName,
                        FileData = fileData,
                        SubmissionId = submission.Id,
                        Submission = submission
                    };

                    _context.SubmissionFiles.Add(submissionFile);
                    submission.SubmissionFiles.Add(submissionFile);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Assignments", new { id = assignment.CourseId });
        }

        /*
         * Function to display Submissions
         */
        [Authorize]
        public async Task<IActionResult> Submissions(int id)
        {
            var assignment = await _context.Assignments
                .Include(a => a.AssignmentSubmissions)
                    .ThenInclude(s => s.Student)
                .Include(a => a.AssignmentSubmissions)
                    .ThenInclude(s => s.SubmissionFiles)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Teacher") || User.IsInRole("Admin"))
            {
                ViewBag.CourseId = assignment.CourseId;
                // Show all submissions
                return View(assignment);
            }
            else if (User.IsInRole("Student"))
            {
                var student = await _userManager.GetUserAsync(User);
                var submissions = assignment.AssignmentSubmissions.Where(s => s.Student.Id == student.Id).ToList();

                // Create a new Assignment object that only includes the current user's submissions
                var assignmentForStudent = new Assignment
                {
                    Id = assignment.Id,
                    Title = assignment.Title,
                    Description = assignment.Description,
                    DueDate = assignment.DueDate,
                    Course = assignment.Course,
                    CourseId= assignment.CourseId,
                    AssignmentSubmissions = submissions
                };
                ViewBag.CourseId = assignment.CourseId;

                return View(assignmentForStudent);
            }
            else
            {
                // The user is not a student or a teacher
                return Forbid();
            }
        }

        /*
         * Function to download assignment files
         */
        public async Task<IActionResult> DownloadFile(int id, string fileType)
        {
            if (fileType == "SubmissionFile")
            {
                var file = await _context.SubmissionFiles.FindAsync(id);
                if (file == null)
                {
                    return NotFound();
                }

                return File(file.FileData, "application/octet-stream", file.FileName);
            }
            else if (fileType == "AssignmentFile")
            {
                var file = await _context.AssignmentFiles.FindAsync(id);
                if (file == null)
                {
                    return NotFound();
                }

                return File(file.FileData, "application/octet-stream", file.FileName);
            }
            else
            {
                return BadRequest("Invalid file type.");
            }
        }

		public async Task<IActionResult> DeleteFile(int id)
		{
			var assignmentFile = await _context.AssignmentFiles.FindAsync(id);

			if (assignmentFile == null)
			{
				return NotFound();
			}

			_context.AssignmentFiles.Remove(assignmentFile);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Edit), new { id = assignmentFile.AssignmentId });
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Teacher")]
		public async Task<IActionResult> Grade(int id, int submissionId, int grade)
        {
            var submission = await _context.AssignmentSubmissions.FindAsync(submissionId);

            if (submission == null)
            {
                return NotFound();
            }

            submission.Grade = grade;

            await _context.SaveChangesAsync();

            return RedirectToAction("Submissions","Assignments", new { id = submission.AssignmentId });
        }
    }
}
