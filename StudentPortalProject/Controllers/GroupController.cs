using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortalProject.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using StudentPortalProject.Data;

namespace StudentPortalProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<GroupMemberViewModel> GetAll()
        {

            var groups = _context.GroupMembers
                          .Where(gp => gp.StudentId == _userManager.GetUserId(User))
                          .Join(_context.Groups, ug => ug.GroupId, g => g.Id, (ug, g) =>
                                        new GroupMemberViewModel()
                                        {
                                            UserName = ug.Student.UserName,
                                            GroupId = g.Id,
                                            GroupName = g.GroupName
                                        })
                           .ToList();

            return groups;
        }

        [HttpPost]
		[Authorize(Roles = "Admin,Teacher")]
		public IActionResult Create([FromBody] NewGroupViewModel group)
        {
            if (group == null || group.GroupName == "")
            {
                return new ObjectResult(
                    new { status = "error", message = "incomplete request" }
                );
            }
            if ((_context.Groups.Any(gp => gp.GroupName == group.GroupName)) == true)
            {
                return new ObjectResult(
                    new { status = "error", message = "group name already exist" }
                );
            }

            Group newGroup = new Group { GroupName = group.GroupName };
            
            // Insert this new group to the database...
            _context.Groups.Add(newGroup);
            _context.SaveChanges();
            //Insert into the user group table, group_id and user_id in the user_groups table...
            foreach (ApplicationUser stu in group.Students)
            {
                _context.GroupMembers.Add(
                    new GroupMember { Student = stu, StudentId = stu.Id, Group = newGroup, GroupId = newGroup.Id }
                );
                _context.SaveChanges();
            }

            return new ObjectResult(new { status = "success", data = newGroup });
        }
    }
}
