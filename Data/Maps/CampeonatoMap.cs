using AgenciaApostas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgenciaApostas.Data.Maps
{
    public class CampeonatoMap : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.ToTable("Campeonato");
            builder.HasKey(x => x.id);
        }
    }
}
