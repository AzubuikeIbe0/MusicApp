namespace MusicApp.Media
{
    public class PageItem
    {
        public string Text {get; set; }
        public int PageIndex {get; set;}
        public bool Enabled {get; set;}
        public bool Active {get; set;}
        public PageItem(int pageIndex, bool enabled, string text)
        {
            PageIndex = pageIndex;
            Enabled = enabled;
            Text = text;
        }
    }

    // public class Paging
    // {
    //     public string LinkText { get; set; }
    //     public int PageId { get; set; }

    //     public Paging(int page, string text)
    //     {
    //         PageId = page;
    //         LinkText = text;
    //     }
    // }
}
