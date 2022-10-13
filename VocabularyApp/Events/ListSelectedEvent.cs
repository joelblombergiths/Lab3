namespace VocabularyApp
{
    public class ListSelectedEvent : EventArgs
    {
        public string List { get; set; }

        public ListSelectedEvent(string list)
        {
            List = list;
        }
    }
}
