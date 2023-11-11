using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trif_Andrei_Lab2.Data;
using Trif_Andrei_Lab2.Models;

namespace Trif_Andrei_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Trif_Andrei_Lab2Context _context;

        public IndexModel(Trif_Andrei_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                    .Include(b => b.Book)
                        .ThenInclude(b => b.Author)
                    .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
