using LocBike.Models;
using Microsoft.EntityFrameworkCore;

namespace LocBike.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<LocacaoModel> Locacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LocacaoModel>().HasIndex(e => e.NomeCliente).IsUnique();
            //modelBuilder.Entity<ClienteModel>().HasIndex(e => e.Telefone).IsUnique();
        }
    }
}
