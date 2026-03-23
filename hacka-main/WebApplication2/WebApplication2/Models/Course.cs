namespace UrmetJournal.models
{
    public class Course
    {
        public int Id { get; set; }
        public string NameCourse { get; set; }
        public int CourseId { get; set; }
        public string Teacher { get; set; }
        public int Totalectures { get; set; }
        public DateTime? NextDeadLine { get; set; }
        public int TotalLectures { get; set; }
        public int TotalAssigments { get; set; }
        public int TotalHours { get; set; }
}