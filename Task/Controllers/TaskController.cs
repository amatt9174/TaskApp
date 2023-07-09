using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Threading.Tasks;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            var vm = new TaskViewModel();

            var tasks = FileHandler.GetOpenTaskData();
            if (!tasks.Any())
            {
                return BadRequest();
            }
            vm.Tasks = tasks;
            
            return View(vm);
        }
        public IActionResult AllTasks()
        {
            var vm = new TaskViewModel();

            var tasks = FileHandler.GetAllTaskData();
            if (!tasks.Any())
            {
                return BadRequest();
            }
            vm.Tasks = tasks;

            return View(vm);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            var vm = new TaskViewModel();

            var tasks = FileHandler.GetTaskData(id);
            if (!tasks.Any())
            {
                return BadRequest();
            }

            vm.Id = tasks.First().Id;
            vm.Title = tasks.First().Title;
            vm.CreatedOn = tasks.First().CreatedOn;
            vm.Comments = tasks.First().Comments;
            vm.AssignedTo = tasks.First().AssignedTo;
            vm.Priority = tasks.First().Priority;
            vm.Status = tasks.First().Status;

            var users = FileHandler.GetUserData();
            if (!users.Any())
            {
                return BadRequest();
            }

            vm.Users = users;
            vm.UserSelectList = new List<SelectListItem>();

            foreach (var user in users)
            {
                vm.UserSelectList.Add(new SelectListItem { Text = user.Name, Value = user.Id.ToString() });   
            }

            var priorities = FileHandler.GetPriorityData();
            if (!priorities.Any())
            {
                return BadRequest();
            }
            vm.Priorities = priorities;
            vm.PrioritySelectList = new List<SelectListItem>();

            foreach (var priority in priorities)
            {
                vm.PrioritySelectList.Add(new SelectListItem { Text = priority.Name, Value = priority.Id.ToString() });
            }

            var statuses = FileHandler.GetStatusData();
            if (!statuses.Any())
            {
                return BadRequest();
            }
            vm.Statuses = statuses;
            vm.StatusSelectList = new List<SelectListItem>();

            foreach (var status in statuses)
            {
                vm.StatusSelectList.Add(new SelectListItem { Text = status.Name, Value = status.Id.ToString() });
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = FileHandler.UpdateTaskData(model);
                if (result) return RedirectToAction("AllTasks");
            }
            return View();
        }
    }
}
