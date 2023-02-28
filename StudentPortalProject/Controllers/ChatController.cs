using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortalProject.Data;
using StudentPortalProject.Models;

namespace StudentPortalProject.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ChatController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pusher()
        {
            var groups = _context.GroupMembers
                .Where(gp => gp.StudentId == _userManager.GetUserId(User))
                .Join(_context.Groups, ug => ug.GroupId, g => g.Id, (ug, g)=>
                    new GroupMemberViewModel
                    {
                        UserName = ug.Student.UserName,
                        GroupId = g.Id,
                        GroupName = ug.Group.GroupName,
                    })
                .ToList();
            ViewData["GroupMembers"] = groups;
            ViewData["Users"] = _userManager.Users;
            return View();
        }
    }
}
