using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentPortalProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
		[Required]
		[DisplayName("Course Description")]
        public string CourseDescription { get; set; }
		public string ?TeacherId { get; set; }
		public ApplicationUser ?Teacher { get; set; }
        public virtual ICollection<ApplicationUser> ?Students { get; set; }
        public virtual ICollection<Group> ?Groups { get; set; }
        public ICollection<Announcement> ?Announcements { get; set; }
        public virtual ICollection<Lecture> ?Lectures { get; set; }
        public virtual ICollection<Assignment> ?Assignments { get; set; }

	}
}
