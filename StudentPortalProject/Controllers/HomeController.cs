using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
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

		/*
		 * Returns a list of groups that the user is in
		 */
		public async Task<List<Group>> getGroups(GroupMember userMember)
		{
			var groups = await _context.Groups
				.Where(g => g.Id == userMember.GroupId)
				.ToListAsync();

			return groups;
		}

		/*
		 * Returns a list of group members of the groups gathered.
		 */
		public async Task<List<GroupMember>> getGroupMembers(Group group)
		{
			var groupMembers = await _context.GroupMembers
				.Where(g => g.GroupId == group.Id)
				.ToListAsync();

			return groupMembers;
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

				//List of groups that only the user is in.
				List<Group> groupList = new List<Group>();
				//List of group members from above groups.
				List<GroupMember> groupMemberList = new List<GroupMember>();
				//List of user's instances in groups
				List<GroupMember> userGroupMemberList = new List<GroupMember>();

				if (role.Contains("Student"))
				{
					courses = await _context.Course
						.Include(c => c.Students)
						.Where(c => c.Students.Any(e => e.Id == user.Id))
						.ToListAsync();

					userGroupMemberList = await _context.GroupMembers
						.Where(g => g.StudentId == user.Id)
						.ToListAsync();

					foreach (Course c in courses)
					{
						assignmentList.AddRange(await getAssignments(c));
					}

					//Grabbing each group the user is a part of.
					foreach (GroupMember u in userGroupMemberList)
					{
						groupList.AddRange(await getGroups(u));
					}

					//Only grabbing members from groups the user is in.
					foreach (Group g in groupList)
					{
						groupMemberList.AddRange(await getGroupMembers(g));
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
				ViewData["Groups"] = groupList;
				ViewData["GroupMembers"] = groupMemberList;
				return View(courses);

			}
		}
	}
}