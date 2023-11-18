using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trif_Andrei_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Author")]
        public int? AuthorID { get; set; }

        public Author? Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publish Date")]
        public DateTime PublishingDate { get; set; }

        [Display(Name = "Publisher")]
        public int? PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        [Display(Name = "Book Categories")]
        public ICollection<BookCategory>? BookCategories { get; set; }

        public int? BorrowingID { get; set; }

        public Borrowing? Borrowing { get; set; }

        public string BookFullName => Author != null
            ? $"{Title} - {Author.LastName} {Author.FirstName}" : Title;

        public override bool Equals(object? obj)
        {
            return obj is Book other && Equals(other);
        }

        public bool Equals(Book other)
        {
            return ID == other.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
