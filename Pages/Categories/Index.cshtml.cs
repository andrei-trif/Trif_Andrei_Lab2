using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trif_Andrei_Lab2.Data;
using Trif_Andrei_Lab2.Models;
using Trif_Andrei_Lab2.Models.ViewModels;

namespace Trif_Andrei_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Trif_Andrei_Lab2Context _context;

        public IndexModel(Trif_Andrei_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryIndexData CategoryData { get; set; } = default!;
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)
                .ThenInclude(i => i.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                CategoryData.Books = CategoryData.Categories.SelectMany(x => x.BookCategories ?? Enumerable.Empty<BookCategory>()).Select(x => x.Book).Distinct();
            }
        }
    }
}
