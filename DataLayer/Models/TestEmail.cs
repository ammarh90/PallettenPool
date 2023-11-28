namespace SendGridAPI.Models
{
    public class TestEmail
    {
        // public int EmailId { get; set; }
        public string FromEmailAddress { get; set; }
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
