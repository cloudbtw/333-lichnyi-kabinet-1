namespace UrmetJournal.Models
{
    public class Attedanse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonsId { get; set; }
        public bool IsPresent { get; set; }
        public string Note { get; set; }
    }
}
