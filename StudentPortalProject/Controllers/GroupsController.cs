using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
using StudentPortalProject.Data.Migrations;
using StudentPortalProject.Models;
using System.Data;
using GroupMember = StudentPortalProject.Models.GroupMember;

namespace StudentPortalProject.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
			_userManager = userManager;
			_userManager.Users.ToList();
		}

		/*
        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groups.Include(@ => @.Course).Include(@ => @.Student);
            return View(await applicationDbContext.ToListAsync());
        }
        */
		// GET: Groups/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }
        

		// GET: Groups/Create
		[Authorize(Roles = "Admin,Teacher")]
		public IActionResult Create(int id)
        {
            ViewData["Courses"] = new SelectList(_context.Course, "Id", "Id");
            ViewBag.CourseId = id;
            return View();
        }

		// POST: Groups/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin,Teacher")]
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
		[Authorize(Roles = "Admin,Teacher")]
		[HttpGet]
        public async Task<IActionResult> AddStudents(int groupId, int courseId)
        {
            ViewData["CourseId"] = courseId;
            ViewData["GroupId"] = groupId;
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
            var groupMembers = await _context.GroupMembers
                .Where(c => c.GroupId == groupId)
                .Select(c => new GroupMember
                {
                    Student = c.Student,
                })
                .ToListAsync();

            foreach(var stu in groupMembers)
            {
                if(students.Students.Contains(stu.Student))
                {
                    students.Students.Remove(stu.Student);
                }
            }

			ViewBag.Students = new MultiSelectList(students.Students, "Id", "UserName");

            return View(new AddStudentsViewModel { CourseId = groupId });
        }

		// POST: Add students to the group
		[Authorize(Roles = "Admin,Teacher")]
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
            return RedirectToAction("GroupList", "Courses", new { id = group.CourseId });
        }

        // GET: Groups/Edit/5
        /*
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
        */


		// GET: Groups/Delete/5
		[Authorize(Roles = "Admin,Teacher")]
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
		[Authorize(Roles = "Admin,Teacher")]
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
        [Authorize(Roles = "Admin,Teacher, Student")]
        public async Task<IActionResult> Files(int id, int courseId)
        {
            ViewData["GroupId"] = id;
            ViewData["CourseId"] = courseId;

            var assignment = await _context.Groups
                .Include(a => a.GroupFileUploads)
                    .ThenInclude(s => s.Student)
                .Include(a => a.GroupFileUploads)
                    .ThenInclude(s => s.GroupFiles)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        [HttpGet]
        public IActionResult SubmitFile(int id)
        {
            var student = _userManager.GetUserAsync(User).Result;

            
            var group = _context.Groups
                .FirstOrDefault(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            var submission = new GroupFileUpload
            {
                GroupId = group.Id,
                Group = group,
                StudentId = student.Id,
                Student = student,
                SubmissionDate = DateTime.Now
            };
            

            return View(submission);
        }

		[HttpPost]
		public async Task<IActionResult> SubmitFile(int id, IFormFile[] uploadedFiles)
		{
			var student = await _userManager.GetUserAsync(User);
			var group = await _context.Groups.FindAsync(id);

			var fileupload = new GroupFileUpload
			{
				GroupId = group.Id,
				Group = group,
				StudentId = student.Id,
				Student = student,
				SubmissionDate = DateTime.Now,
				GroupFiles = new List<GroupFile>()
			};


			_context.GroupFileUploads.Add(fileupload);
			await _context.SaveChangesAsync();

			foreach (var file in uploadedFiles)
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

					var submissionFile = new GroupFile
					{
						FileName = fileName,
						FileData = fileData,
						SubmissionId = fileupload.Id,
						FileUpload = fileupload
					};

					_context.GroupFiles.Add(submissionFile);
					fileupload.GroupFiles.Add(submissionFile);
				}
			}

			await _context.SaveChangesAsync();

            return RedirectToAction("GroupList", "Courses", new { id = fileupload.Group.CourseId });
        }

		/*
         * Function to download files
         */
		public async Task<IActionResult> DownloadFile(int id, string fileType)
		{
			if (fileType == "GroupFile")
			{
				var file = await _context.GroupFiles.FindAsync(id);
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
            var fileUpload = await _context.GroupFileUploads
    .Include(g => g.Group)
        .ThenInclude(g => g.Course)
    .FirstOrDefaultAsync(g => g.Id == id);
            int courseId = fileUpload.Group.Course.Id;
            if (fileUpload == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (fileUpload.StudentId != user.Id)
            {
                return Forbid();
            }
            
            // Remove the file upload entity
            _context.GroupFileUploads.Remove(fileUpload);
            
            await _context.SaveChangesAsync();

            return RedirectToAction("GroupList", "Courses", new { id = courseId });
        }

    }
}
