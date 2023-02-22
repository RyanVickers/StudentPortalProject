namespace StudentPortalProject.Models
{
    public class Group
    {
        public Course Course { get; set; }      // What course is this group tied to
        public virtual ICollection<ApplicationUser> Members { get; set; }       // The students that are members
    }
}
