using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageIntro.Data;
using RazorPageIntro.Model;

namespace RazorPageIntro.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageIntro.Data.RazorPageIntroContext _context;

        public IndexModel(RazorPageIntro.Data.RazorPageIntroContext context)
        {
            _context = context;
        }

        public IList<BookCollections> BookCollections { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            var books = from b in _context.BookCollections
                        select b;
            if(!string.IsNullOrEmpty(SearchString))
            {
                books = _context.BookCollections.Where(s => s.Title!.Contains(SearchString));
            }
            if (_context.BookCollections != null)
            {
                BookCollections = await books.ToListAsync();
            }
        }
    }   
}
