namespace StudentPortalProject.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}
