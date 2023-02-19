namespace StudentPortalProject.Models
{
    public class LectureFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
