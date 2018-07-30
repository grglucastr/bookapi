using Microsoft.EntityFrameworkCore;

namespace BooksApi.Models
{
    public class BookApiContext :  DbContext
    {
        public DbSet<Book> Book {get; set;}

        public BookApiContext(DbContextOptions<BookApiContext> options):base(options)
        {
            
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=booksapi;user=root;password=Senha123");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Book>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title);
                entity.Property(e => e.Author);
                entity.Property(e => e.Genre);
            });
        }
        */
    }
}