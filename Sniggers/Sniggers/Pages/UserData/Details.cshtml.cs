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
    public class DetailsModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public DetailsModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

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
    }
}
