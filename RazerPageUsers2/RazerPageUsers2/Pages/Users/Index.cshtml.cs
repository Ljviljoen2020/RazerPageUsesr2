using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazerPageUsers2.Data;
using RazerPageUsers2.Models;

namespace RazerPageUsers2.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RazerPageUsers2.Data.RazerPageUsers2Context _context;

        public IndexModel(RazerPageUsers2.Data.RazerPageUsers2Context context)
        {
            _context = context;
        }
        public IList<User> User { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SurnameGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.User
                                            orderby m.Surname
                                            select m.Surname;

            var users = from m in _context.User
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                users = users.Where(s => s.Fullname.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SurnameGenre))
            {
                users = users.Where(x => x.Surname == SurnameGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            User = await users.ToListAsync();
        }
    }
}
