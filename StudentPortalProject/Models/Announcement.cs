using System.ComponentModel.DataAnnotations;

namespace StudentPortalProject.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
