using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra.Map
{
    public class DetalheCampeonatoMap : IEntityTypeConfiguration<DetalheCampeonato>
    {
        public void Configure(EntityTypeBuilder<DetalheCampeonato> builder)
        {
            builder.HasIndex(i => new { i.CampeonatoId, i.TimeId }).IsUnique();

            builder.HasOne(x => x.Campeonato).WithMany(x => x.DetalhesCampeonato).HasForeignKey(x => x.CampeonatoId);
        }
    }
}
