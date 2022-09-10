using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Kuca> Kuce { get; set; }
        public DbSet<Materijal> Materijali { get; set; }
        public DbSet<Prodavnica> Prodavnice { get; set; }
        public DbSet<Spoj> Spojevi { get; set; }

        public IspitDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
