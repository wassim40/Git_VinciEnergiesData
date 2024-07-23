using Microsoft.EntityFrameworkCore;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Dossier> dossiers { get; set; }

        public DbSet<Fichier> fichiers { get; set; }

        public DbSet<VMLogin> vmLogins { get; set; }

        public DbSet<Administrateur> administrateur { get; set; }

    }
}
