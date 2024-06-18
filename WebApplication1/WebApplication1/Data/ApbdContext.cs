using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApbdContext : DbContext
{
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public ApbdContext(DbContextOptions<ApbdContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenre>().HasKey(bg => new { bg.BookId, bg.GenreId });
        modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<PublishingHouse>()
            .HasMany(ph => ph.Books)
            .WithOne(b => b.PublishingHouse)
            .HasForeignKey(b => b.PublishingHouseId);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookGenres)
            .WithOne(bg => bg.Book)
            .HasForeignKey(bg => bg.BookId);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookAuthors)
            .WithOne(ba => ba.Book)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<Author>()
            .HasMany(a => a.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<Genre>()
            .HasMany(g => g.BookGenres)
            .WithOne(bg => bg.Genre)
            .HasForeignKey(bg => bg.GenreId);

        base.OnModelCreating(modelBuilder);
    }
}