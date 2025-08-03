using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MoviesIndexModel : PageModel
{
    private readonly MoviesContext _context;

    public MoviesIndexModel(MoviesContext context)
    {
        _context = context;
    }

    public IList<Movie> Movies { get; set; } = new List<Movie>();

    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(SearchString))
        {
            query = query.Where(m => m.Title.Contains(SearchString));
        }

        Movies = await query.ToListAsync();
    }
}
