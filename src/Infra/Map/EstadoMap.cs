using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra.Map
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasIndex(i => i.Sigla).IsUnique();

            builder.HasMany(x => x.Times).WithOne(x => x.Estado).HasForeignKey(x => x.EstadoId);
        }
    }
}
