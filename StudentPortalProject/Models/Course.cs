using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentPortalProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; }
        public virtual ICollection<ApplicationUser> Students { get; set; }
        //public virtual ICollection<Group> Groups { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

    }
}
