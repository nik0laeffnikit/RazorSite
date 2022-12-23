using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sniggers.CharacterModels;
using Sniggers.Data;
using Sniggers.Models;

namespace Sniggers.Pages.UserData
{
    public class CreateModel : PageModel
    {
        public string messageName, messagePath;
        private readonly Sniggers.Data.SniggersContext _context;

        public CreateModel(Sniggers.Data.SniggersContext context)
        {
            _context = context;
        }

        public List<CharactersData> characterModels = new List<CharactersData>()
        {
            new CharactersData()
            {
                name = "Леон", desciption = "", id = 0, photoPath = "Leon.png"
            },
            new CharactersData()
            {
                name = "Эль Примо", desciption = "", id = 1, photoPath = "ElPrimo.png"
            },
            new CharactersData()
            {
                name = "Кольт", desciption = "", id = 2, photoPath = "Colt.png"
            },
            new CharactersData()
            {
                name = "Шелли", desciption = "", id = 2, photoPath = "Shelly.png"
            },
            new CharactersData()
            {
                name = "Ворон", desciption = "", id = 2, photoPath = "Voron.png"
            },
            new CharactersData()
            {
                name = "Спайк", desciption = "", id = 2, photoPath = "Spike.png"
            }
        };

        public CharactersData GetRandom()
        {
            Random rand = new Random();
            int random = rand.Next(0, characterModels.Count);
            return characterModels[random];
        }

        public IActionResult OnGet()
        {
            CharactersData tmp = GetRandom();
            messageName = tmp.name;
            messagePath = tmp.photoPath;
            return Page();
        }

        [BindProperty]
        public UsersData UsersData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UsersData == null || UsersData == null)
            {
                return Page();
            }

            _context.UsersData.Add(UsersData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
