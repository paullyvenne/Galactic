namespace AnnouncementAPI
{
    [Serializable]
    public class AnnoucementParams
    {
        public DateTime AnnoucementDate { get; set; }

        public string? Subject { get; set; }

        public string? Author { get; set; }

        public string? Content { get; set; } //XML/HTML Markup
    }
}