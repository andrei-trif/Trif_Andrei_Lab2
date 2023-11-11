using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trif_Andrei_Lab2.Data;
using Trif_Andrei_Lab2.Models;

namespace Trif_Andrei_Lab2.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly Trif_Andrei_Lab2Context _context;

        public CreateModel(Trif_Andrei_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Member == null || Member == null)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
