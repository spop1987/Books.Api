using Books.Models.Entities;
using Books.Models.Entities.TypeConfig;
using Microsoft.EntityFrameworkCore;


namespace Books.DataBase.SqlServer
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) {}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurationAllTypeConfig();
        }
    }
}
