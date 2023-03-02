using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using StudentPortalProject.Data;
using StudentPortalProject.Data.Migrations;
using StudentPortalProject.Models;
using System.Diagnostics;

namespace StudentPortalProject.Controllers
{

    public class HomeController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;


		public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
		{
			_context = context;
			_userManager = userManager;
			_userManager.Users.ToList();


		}

		private readonly ILogger<HomeController> _logger;

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		/*
		 * Returns a list of assignments that correspond to the given course
		 */
		public async Task<List<Assignment>> getAssignments(Course course)
		{
            var assignments = await _context.Assignment
                .Where(a => a.CourseId == course.Id)
                .ToListAsync();

			return assignments;
        }

		public async Task<IActionResult> Index()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return View();
			}
			else
			{
				var user = await _userManager.GetUserAsync(User);
				var role = await _userManager.GetRolesAsync(user);
				List<Course> courses;
				List<Assignment> assignmentList = new List<Assignment>();
				if (role.Contains("Student"))
				{
					courses = await _context.Course
						.Include(c => c.Students)
						.Where(c => c.Students.Any(e => e.Id == user.Id))
						.ToListAsync();

					foreach(Course c in courses)
					{
						 assignmentList.AddRange(await getAssignments(c));
					}
				}
				else if (role.Contains("Teacher"))
				{
					courses = await _context.Course
						.Where(c => c.TeacherId == user.Id)
						.ToListAsync();

                    foreach (Course c in courses)
                    {
                        assignmentList.AddRange(await getAssignments(c));
                    }
                }
				else if (role.Contains("Admin"))
				{
					courses = await _context.Course.ToListAsync();

                    foreach (Course c in courses)
                    {
                        assignmentList.AddRange(await getAssignments(c));
                    }
                }
				else
				{
					courses = new List<Course>();
				}
				ViewData["Assignments"] = assignmentList;
				return View(courses);
				
			}
		}
	}
}