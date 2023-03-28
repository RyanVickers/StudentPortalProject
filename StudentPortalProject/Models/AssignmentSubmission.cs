using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortalProject.Models
{
    public class AssignmentSubmission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ?Grade { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual ICollection<SubmissionFile> SubmissionFiles { get; set; }
    }
}
