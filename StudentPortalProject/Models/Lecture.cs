using System.ComponentModel.DataAnnotations;

namespace StudentPortalProject.Models
{
    public class Lecture
    {
        public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
        public int CourseId { get; set; }
        public virtual Course ?Course { get; set; }
        public List<LectureFile> LectureFiles { get; set; } = new List<LectureFile>();
    }
}