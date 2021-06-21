using Microsoft.EntityFrameworkCore;
using Manatial_de_Vida.Models;
namespace Manatial_de_Vida.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options) { }
        public DbSet<Manatial_de_Vida.Models.Miembro> Miembro { get; set; }
    }
}
