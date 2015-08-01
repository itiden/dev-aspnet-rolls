using Microsoft.Data.Entity;

namespace Rolls.Models
{
    public class RollsContext : DbContext
    {
        public DbSet<Roll> Rolls { get; set; }
    }
}