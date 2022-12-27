using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageIntro.Data;
using RazorPageIntro.Model;

namespace RazorPageIntro.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly RazorPageIntro.Data.RazorPageIntroContext _context;

        public EditModel(RazorPageIntro.Data.RazorPageIntroContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookCollections BookCollections { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCollections == null)
            {
                return NotFound();
            }

            var bookcollections =  await _context.BookCollections.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcollections == null)
            {
                return NotFound();
            }
            BookCollections = bookcollections;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookCollections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCollectionsExists(BookCollections.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookCollectionsExists(int id)
        {
          return _context.BookCollections.Any(e => e.ID == id);
        }
    }
}
