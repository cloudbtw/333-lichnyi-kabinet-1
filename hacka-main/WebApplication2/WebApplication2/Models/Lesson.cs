namespace UrmetJournal.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string DayOfWeek { get; set; } // "пн,вт,ср,чт и т.l"
        public int OrderNumber { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
        public int Floor { get; set; }
    }
}