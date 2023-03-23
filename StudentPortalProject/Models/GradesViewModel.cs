namespace StudentPortalProject.Models
{
    public class GradesViewModel
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public decimal Weight { get; set; }
        public decimal? Grade { get; set; }
    }
}
