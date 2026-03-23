namespace UrmetJournal.models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string UserId {  get; set; }
        public string Firstname {  get; set; }
        public string Lastname { get; set; }    
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public DateTime Enrollmen tDate { get; set; }
        public string PhotoUrl { get; set; }
    }
}