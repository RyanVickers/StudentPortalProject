using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortalProject.Models
{
    public class GroupFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int SubmissionId { get; set; }
        public GroupFileUpload FileUpload { get; set; }
    }
}
