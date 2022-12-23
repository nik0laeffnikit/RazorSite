using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sniggers.Data;
using Sniggers.Models;

namespace Sniggers.Pages.UserData
{
    public class EditModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public EditModel(Sniggers.Data.SniggersContext context)
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

            var usersdata =  await _context.UsersData.FirstOrDefaultAsync(m => m.ID == id);
            if (usersdata == null)
            {
                return NotFound();
            }
            UsersData = usersdata;
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

            _context.Attach(UsersData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersDataExists(UsersData.ID))
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

        private bool UsersDataExists(int id)
        {
          return (_context.UsersData?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
