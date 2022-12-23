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
    public class IndexModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public IndexModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

        public IList<UsersData> UsersData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UsersData != null)
            {
                UsersData = await _context.UsersData.ToListAsync();
            }
        }
    }
}
