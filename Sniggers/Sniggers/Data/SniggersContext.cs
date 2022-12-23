using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sniggers.Models;
using Sniggers.CharacterModels;

namespace Sniggers.Data
{
    public class SniggersContext : DbContext
    {
        public SniggersContext (DbContextOptions<SniggersContext> options)
            : base(options)
        {
        }

        public DbSet<Sniggers.Models.UsersData> UsersData { get; set; } = default!;

        public DbSet<Sniggers.CharacterModels.CharactersData> CharactersData { get; set; } = default!;
    }
}
