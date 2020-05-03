using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra.Map
{
    public class CampeonatoMap : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.HasIndex(x => new { x.Ano, x.Nome }).IsUnique();

            builder.HasMany(x => x.DetalhesCampeonato).WithOne(x => x.Campeonato).HasForeignKey(x => x.CampeonatoId);
        }
    }
}
