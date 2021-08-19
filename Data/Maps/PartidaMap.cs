using AgenciaApostas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgenciaApostas.Data.Maps
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable("Partida");
            builder.HasKey(x => x.id);
            builder.Property(x => x.time1).IsRequired();
            builder.Property(x => x.time2).IsRequired();
            builder.Property(x => x.pontosTime1).IsRequired();
            builder.Property(x => x.pontosTime2).IsRequired();
            builder.Property(x => x.ativo).IsRequired();
        }
    }
}
