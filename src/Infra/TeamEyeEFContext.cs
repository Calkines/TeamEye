using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Infra.Map;

namespace TeamEye.Infra
{
    public class TeamEyeEFContext : DbContext
    {
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<DetalheCampeonato> DetalheCampeonatos { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Estado> Estados { get; set; }

        public TeamEyeEFContext(DbContextOptions<TeamEyeEFContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CampeonatoMap());
            builder.ApplyConfiguration(new DetalheCampeonatoMap());
            builder.ApplyConfiguration(new TimeMap());
            builder.ApplyConfiguration(new EstadoMap());
        }
    }
}
