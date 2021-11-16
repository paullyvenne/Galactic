namespace AnnouncementAPI
{
    [Serializable]
    public class Announcement: AnnouncementParams
    {
        public int ID { get; set; }

        public Announcement CopyParams(AnnouncementParams param)
        {
            this.AnnouncementDate = param.AnnouncementDate;
            this.Content = param.Content;
            this.Subject = param.Subject;
            this.Author = param.Author;
            return this;
        }

    }
}