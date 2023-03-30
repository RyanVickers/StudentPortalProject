namespace StudentPortalProject.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        // What course is this group tied to
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public ICollection<GroupFileUpload> ?GroupFileUploads { get; set; }
    }
}
