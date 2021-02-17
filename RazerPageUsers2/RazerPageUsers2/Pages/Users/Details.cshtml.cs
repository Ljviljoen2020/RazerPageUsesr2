using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerPageUsers2.Data;
using RazerPageUsers2.Models;

namespace RazerPageUsers2.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly RazerPageUsers2.Data.RazerPageUsers2Context _context;

        public DetailsModel(RazerPageUsers2.Data.RazerPageUsers2Context context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
