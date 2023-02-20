namespace StudentPortalProject.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<AssignmentFile> AssignmentFiles { get; set; } = new List<AssignmentFile>();
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; }
    }
}
