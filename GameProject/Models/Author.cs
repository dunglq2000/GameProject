namespace GameProject.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Novel> Novels { get; set; }
    }
}
