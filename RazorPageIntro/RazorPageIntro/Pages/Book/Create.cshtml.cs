using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageIntro.Data;
using RazorPageIntro.Model;

namespace RazorPageIntro.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageIntro.Data.RazorPageIntroContext _context;

        public CreateModel(RazorPageIntro.Data.RazorPageIntroContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookCollections BookCollections { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookCollections.Add(BookCollections);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
