namespace AnnouncementAPI
{
    [Serializable]
    public class Annoucement: AnnoucementParams
    {
        public int ID { get; set; }

        public Annoucement CopyParams(AnnoucementParams param)
        {
            this.AnnoucementDate = param.AnnoucementDate;
            this.Content = param.Content;
            this.Subject = param.Subject;
            this.Author = param.Author;
            return this;
        }

    }
}