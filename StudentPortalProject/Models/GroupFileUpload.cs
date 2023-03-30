using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortalProject.Models
{
    public class GroupFileUpload
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual ICollection<GroupFile> GroupFiles { get; set; }
    }
}
