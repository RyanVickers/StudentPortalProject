namespace StudentPortalProject.Models
{
    public class GroupMember
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}
