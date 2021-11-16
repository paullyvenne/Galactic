namespace AnnouncementAPI
{
    [Serializable]
    public class ConfirmationMsg
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public object? Result { get; set; }
    }
}