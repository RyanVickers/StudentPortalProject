using System.ComponentModel.DataAnnotations;

namespace StudentPortalProject.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
		[Required]
		public string Message { get; set; }
		[Required]
		public DateTime Date { get; set; }
        public int CourseId { get; set; }
        public Course ?Course { get; set; }
    }
}
