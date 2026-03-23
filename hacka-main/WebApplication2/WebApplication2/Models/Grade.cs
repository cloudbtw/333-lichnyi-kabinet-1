namespace urmetJournal.models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Gradetype { get; set; }
    }
}