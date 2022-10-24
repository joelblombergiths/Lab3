namespace VocabularyApp.Events
{
    public class ListEvent : EventArgs
    {
        public string List { get; }

        public ListEvent(string list)
        {
            List = list;
        }
    }
}
