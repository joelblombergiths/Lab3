namespace VocabularyApp
{
    public class MessageEvent : EventArgs
    {
        public string? Message { get; set; }

        public MessageEvent(string? message)
        {
            Message = message;
        }
    }
}
