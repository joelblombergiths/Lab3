namespace VocabularyApp
{
    public class ListEvent : EventArgs
    {
        public string List { get; set; }

        public ListEvent(string list)
        {
            List = list;
        }
    }
}
