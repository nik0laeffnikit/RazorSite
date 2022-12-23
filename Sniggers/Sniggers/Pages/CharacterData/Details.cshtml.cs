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
    public class DetailsModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public DetailsModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

      public CharactersData CharactersData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CharactersData == null)
            {
                return NotFound();
            }

            var charactersdata = await _context.CharactersData.FirstOrDefaultAsync(m => m.id == id);
            if (charactersdata == null)
            {
                return NotFound();
            }
            else 
            {
                CharactersData = charactersdata;
            }
            return Page();
        }
    }
}
