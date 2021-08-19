using Microsoft.EntityFrameworkCore;
using AgenciaApostas.Data.Maps;
using AgenciaApostas.Models;

namespace AgenciaApostas.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Time> Time { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Campeonato> Campeonato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=db_desafio_sydy;User ID=desafiosydy;Password=89UQC@G3GuKVCQV");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TimeMap());
            builder.ApplyConfiguration(new PartidaMap());
            builder.ApplyConfiguration(new CampeonatoMap());
        }
    }
}
