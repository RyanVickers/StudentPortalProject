namespace StudentPortalProject.Models
{
    public class NewGroupViewModel
    {
        public string GroupName { get; set; }
        public List<ApplicationUser> Students { get; set; }
        public List<string> UserNames { get; set; }
    }
}
