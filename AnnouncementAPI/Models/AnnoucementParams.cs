namespace AnnouncementAPI
{
    [Serializable]
    public class AnnouncementParams
    {
        public DateTime AnnouncementDate { get; set; }

        public string? Subject { get; set; }

        public string? Author { get; set; }

        public string? Content { get; set; } //XML/HTML Markup
    }
}