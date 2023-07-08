using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
