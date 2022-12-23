using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sniggers.CharacterModels;
using Sniggers.Data;

namespace Sniggers.Pages.CharacterData
{
    public class CreateModel : PageModel
    {

        private readonly Sniggers.Data.SniggersContext _context;

        public CreateModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CharactersData CharactersData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CharactersData == null || CharactersData == null)
            {
                return Page();
            }

            _context.CharactersData.Add(CharactersData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
