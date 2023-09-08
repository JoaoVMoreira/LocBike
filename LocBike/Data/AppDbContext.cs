using LocBike.Models;
using Microsoft.EntityFrameworkCore;

namespace LocBike.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<LocacaoModel> Locacao { get; set; }
    }
}
