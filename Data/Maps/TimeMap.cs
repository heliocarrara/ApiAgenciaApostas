using AgenciaApostas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgenciaApostas.Data.Maps
{
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.ToTable("Time");
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).IsRequired();
        }
    }
}
