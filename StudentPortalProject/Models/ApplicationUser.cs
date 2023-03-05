using Microsoft.AspNetCore.Identity;

namespace StudentPortalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }

        public virtual ICollection<Course> ?EnrolledCourses { get; set; }
    }
}
