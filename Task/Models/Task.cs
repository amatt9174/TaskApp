namespace Task.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedOn { get; set; }
        public string? Comments { get; set; }
        public string? AssignedTo { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public string? StatusChangedOn { get; set; }
    }
}
