using Microsoft.EntityFrameworkCore;
using Trif_Andrei_Lab2.Models;

namespace Trif_Andrei_Lab2.Data
{
    public class Trif_Andrei_Lab2Context : DbContext
    {
        public Trif_Andrei_Lab2Context (DbContextOptions<Trif_Andrei_Lab2Context> options) : base(options) { }

        public DbSet<Book> Book { get; set; } = default!;

        public DbSet<Publisher>? Publisher { get; set; }

        public DbSet<Author>? Author { get; set; }

        public DbSet<Category>? Category { get; set; }

        public DbSet<Member>? Member { get; set; }

        public DbSet<Borrowing>? Borrowing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
                .WithOne(e => e.Book)
                .HasForeignKey<Book>(e => e.BorrowingID);

            modelBuilder.Entity<Borrowing>()
                .HasOne(e => e.Book)
                .WithOne(e => e.Borrowing)
                .HasForeignKey<Borrowing>(e => e.BookID);
        }

        
    }
}
