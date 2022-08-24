namespace GameProject.Models
{
    public class Novel
    {
        public int NovelID { get; set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
