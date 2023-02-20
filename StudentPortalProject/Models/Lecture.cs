using System.ComponentModel.DataAnnotations;

namespace StudentPortalProject.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public List<LectureFile> LectureFiles { get; set; } = new List<LectureFile>();
    }
}