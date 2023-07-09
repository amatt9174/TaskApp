using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Task.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedOn { get; set; }
        public string? Comments { get; set; }
        public string? AssignedTo { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public string? StatusChangedOn { get; set; }
        public List<UserModel>? Users { get; set; }
        public List<TaskModel>? Tasks { get; set; }
        public List<PriorityModel>? Priorities { get; set; }
        public List<StatusModel>? Statuses { get; set; }
        public string? SelectedUser { get; set; }
        public List<SelectListItem>? UserSelectList { get; set; }
        public string? SelectedPriority { get; set; }
        public List<SelectListItem>? PrioritySelectList { get; set; }
        public string? SelectedStatus { get; set; }
        public List<SelectListItem>? StatusSelectList { get; set; }
    }
}
