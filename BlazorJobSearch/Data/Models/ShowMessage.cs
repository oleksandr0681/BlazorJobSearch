namespace BlazorJobSearch.Data.Models
{
    public class ShowMessage
    {
        public int Id { get; set; }

        public string From { get; set; } = string.Empty;

        public string To { get; set; } = string.Empty;

        public string? Title { get; set; }

        public string Body { get; set; } = string.Empty;

        public DateTime Sent { get; set; } = DateTime.Now;

        public DateTime? Viewed { get; set; }
    }
}
