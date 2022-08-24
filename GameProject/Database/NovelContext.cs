using Microsoft.EntityFrameworkCore;
using GameProject.Models;

namespace GameProject.Database
{
    public class NovelContext : DbContext
    {
        public DbSet<Novel> Novels { get; set; }
        public DbSet<Author> Authors { get; set; }
        public string DbPath;
        public NovelContext(DbContextOptions<NovelContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "novel.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

    }
}
