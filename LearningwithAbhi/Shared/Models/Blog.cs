
namespace LearningwithAbhi.Shared;
public class Blog
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Author { get; set; }
    public string AuthorInitials { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public bool IsList { get; set; }
    public List<string> ListItems { get; set; }
    public List<Resource> Resources { get; set; }
    public int Likes { get; set; }
    public bool IsLiked { get; set; }
    public bool IsBookmarked { get; set; }
}

    public class Resource
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }