using System.ComponentModel.DataAnnotations;

namespace Trif_Andrei_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Author")]
        public string AuthorName => $"{LastName}, {FirstName}";

        public ICollection<Book>? Books { get; set; }
    }
}
