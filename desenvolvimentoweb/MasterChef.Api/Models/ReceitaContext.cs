using Microsoft.EntityFrameworkCore;

namespace MasterChef.Api.Models
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> options)
            : base(options)
        {
        }

        public DbSet<Receita> Receita { get; set; }
        
    }
}