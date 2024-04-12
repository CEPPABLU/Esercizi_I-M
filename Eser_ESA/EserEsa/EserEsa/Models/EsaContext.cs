using Microsoft.EntityFrameworkCore;

namespace EserEsa.Models
{
    public class EsaContext : DbContext
    {
        public EsaContext(DbContextOptions<EsaContext> options) : base(options)
        {

        }

        public DbSet<OggettoCeleste> Oggetti { get; set; }
        public DbSet<Sistema> Sistemi { get; set; }
    }
}
