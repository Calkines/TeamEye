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
            builder.HasKey(k => new { k.Ano, k.Nome });
        }
    }
}
