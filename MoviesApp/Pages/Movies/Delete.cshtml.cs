using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Models;
using System.Threading.Tasks;

public class DeleteModel : PageModel
{
    private readonly MoviesContext _context;

    public DeleteModel(MoviesContext context)
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
        if (Movie == null)
        {
            return NotFound();
        }

        var movieToDelete = await _context.Movies.FindAsync(Movie.Id);
        if (movieToDelete != null)
        {
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
