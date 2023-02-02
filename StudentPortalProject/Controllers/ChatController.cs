using Microsoft.AspNetCore.Mvc;

namespace StudentPortalProject.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
