using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sniggers.CharacterModels;
using Sniggers.Data;

namespace Sniggers.Pages.CharacterData
{
    public class IndexModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public IndexModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

        public IList<CharactersData> CharactersData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CharactersData != null)
            {
                CharactersData = await _context.CharactersData.ToListAsync();
            }
        }
    }
}
