using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sniggers.CharacterModels;
using Sniggers.Data;

namespace Sniggers.Pages.CharacterData
{
    public class EditModel : PageModel
    {
        private readonly Sniggers.Data.SniggersContext _context;

        public EditModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CharactersData CharactersData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CharactersData == null)
            {
                return NotFound();
            }

            var charactersdata =  await _context.CharactersData.FirstOrDefaultAsync(m => m.id == id);
            if (charactersdata == null)
            {
                return NotFound();
            }
            CharactersData = charactersdata;
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

            _context.Attach(CharactersData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharactersDataExists(CharactersData.id))
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

        private bool CharactersDataExists(int id)
        {
          return (_context.CharactersData?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
