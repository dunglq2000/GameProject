using GameProject.Models;

namespace GameProject.Database
{
    public class DataInit
    {
        public static void Initialize(NovelContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any())
            {
                return;
            }
            var authors = new Author[]
            {
                new Author { FirstName = "Quoc Dung", LastName = "Le" },
                new Author { FirstName = "Xuan Ha", LastName = "Nguyen" },
                new Author { FirstName = "Nguyen Hoang Duy", LastName = "Pham" }
            };
            foreach (var author in authors)
            {
                context.Authors.Add(author);
            }
            context.SaveChanges();
        }
    }
}