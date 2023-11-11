using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trif_Andrei_Lab2.Data;
using Trif_Andrei_Lab2.Models;

namespace Trif_Andrei_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Trif_Andrei_Lab2Context _context;

        public IndexModel(Trif_Andrei_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public BookData BookData { get; set; } = default!;

        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public string TitleSort { get; set; } = string.Empty;
        public string AuthorSort { get; set; } = string.Empty;

        public string CurrentFilter { get; set; } = string.Empty;

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BookData = new BookData();

            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";

            CurrentFilter = searchString;

            BookData.Books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                BookData.Books = BookData.Books.Where(b => 
                    (b.Author?.AuthorName ?? string.Empty).Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                    b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (id != null)
            {
                BookID = id.Value;
                var book = BookData.Books.Where(i => i.ID == id.Value).Single();
                BookData.Categories = book.BookCategories?.Select(s => s.Category) ?? Enumerable.Empty<Category>();
            }

            BookData.Books = sortOrder switch
            {
                "title_desc" => BookData.Books.OrderByDescending(b => b.Title),
                "author_desc" => BookData.Books.OrderByDescending(b => b.Author?.AuthorName ?? string.Empty),
                "author" => BookData.Books.OrderBy(b => b.Author?.AuthorName ?? string.Empty),
                _ => BookData.Books.OrderBy(b => b.Title),
            };
        }
    }
}
