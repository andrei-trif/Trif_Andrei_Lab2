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
    }
}
