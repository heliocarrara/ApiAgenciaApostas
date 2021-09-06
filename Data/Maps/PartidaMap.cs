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
            builder.Property(x => x.Time1).IsRequired();
            builder.Property(x => x.Time2).IsRequired();
            builder.Property(x => x.PontosTime1).IsRequired();
            builder.Property(x => x.PontosTime2).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
