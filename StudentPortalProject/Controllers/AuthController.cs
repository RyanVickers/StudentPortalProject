using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentPortalProject.Models;
using Microsoft.AspNetCore.Identity;
using PusherServer;
using StudentPortalProject.Models;
using StudentPortalProject.Data;

namespace StudentPortalProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult ChannelAuth(string channel_name, string socket_id)
        {
            int group_id;
            if (!User.Identity.IsAuthenticated)
            {
                return new ContentResult { Content = "Access forbidden", ContentType = "application/json" };
            }

            try
            {
                group_id = Int32.Parse(channel_name.Replace("private-", ""));
            }
            catch (FormatException e)
            {
                return Json(new { Content = e.Message });
            }

            var IsInChannel = _context.GroupMembers
                                      .Where(gb => gb.GroupId == group_id
                                            && gb.StudentId == _userManager.GetUserId(User))
                                      .Count();

            if (IsInChannel > 0)
            {
                var options = new PusherOptions
                {
                    Cluster = "us2",
                    Encrypted = true
                };
                var pusher = new Pusher(
					"1561045",
					"c69f92acb27498142097",
					"83f4b81196a28cbe83de",
                    options
                );

                var auth = pusher.Authenticate(channel_name, socket_id).ToJson();
                return new ContentResult { Content = auth, ContentType = "application/json" };
            }
            return new ContentResult { Content = "Access forbidden", ContentType = "application/json" };
        }
    }
}