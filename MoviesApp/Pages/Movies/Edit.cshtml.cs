using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MoviesContext _context;

        public EditModel(MoviesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) 
        {
            Movie = await _context.Movies.FindAsync(id);

            if (Movie == null) 
            { 
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Movies.Any(e => e.Id == Movie.Id))
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
    }
}
