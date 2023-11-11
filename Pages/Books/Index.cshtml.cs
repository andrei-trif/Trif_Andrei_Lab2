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

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookData = new BookData();
            
            BookData.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;

                var book = BookData.Books.Where(i => i.ID == id.Value).Single();
                
                BookData.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}
