using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra.Map
{
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasIndex(i => new { i.EstadoId, i.NomeNormalizado }).IsUnique();

            builder.HasOne(x => x.Estado).WithMany(x => x.Times).HasForeignKey(x => x.EstadoId);
        }
    }
}
