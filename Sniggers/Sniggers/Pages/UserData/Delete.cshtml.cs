using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sniggers.Data;
using Sniggers.Models;

namespace Sniggers.Pages.UserData
{
    public class DeleteModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public DeleteModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UsersData UsersData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersData == null)
            {
                return NotFound();
            }

            var usersdata = await _context.UsersData.FirstOrDefaultAsync(m => m.ID == id);

            if (usersdata == null)
            {
                return NotFound();
            }
            else 
            {
                UsersData = usersdata;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UsersData == null)
            {
                return NotFound();
            }
            var usersdata = await _context.UsersData.FindAsync(id);

            if (usersdata != null)
            {
                UsersData = usersdata;
                _context.UsersData.Remove(UsersData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
