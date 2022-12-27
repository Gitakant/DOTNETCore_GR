using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageIntro.Model;

namespace RazorPageIntro.Data
{
    public class RazorPageIntroContext : DbContext
    {
        public RazorPageIntroContext (DbContextOptions<RazorPageIntroContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPageIntro.Model.BookCollections> BookCollections { get; set; } = default!;
    }
}
