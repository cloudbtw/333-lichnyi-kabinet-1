namespace Urmetjournal.models
{
    public class achievment
    {
        public int Id { get; set; }
        public int StudentProfileId { get; set; }
        public DateTime dateachieved { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string Icon { get; set; }
    }
}