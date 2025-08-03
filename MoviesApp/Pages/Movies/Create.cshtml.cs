using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Data;
using MoviesApp.Models;
using System.Threading.Tasks;

public class CreateModel : PageModel
{
    private readonly MoviesContext _context;

    public CreateModel(MoviesContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Movie Movie { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Movies.Add(Movie);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
