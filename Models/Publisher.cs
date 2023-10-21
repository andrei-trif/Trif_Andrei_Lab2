using System.ComponentModel.DataAnnotations;

namespace Trif_Andrei_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }

        [Display(Name = "Publisher")]
        public string PublisherName { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }
    }
}
