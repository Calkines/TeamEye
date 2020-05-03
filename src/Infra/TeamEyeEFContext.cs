using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra
{
    public class TeamEyeEFContext : DbContext
    {
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<DetalheCampeonato> DetalheCampeonatos { get; set; }
        public DbSet<Time> Times { get; set; }

        public TeamEyeEFContext(DbContextOptions<TeamEyeEFContext> opt) : base(opt)
        {
        }
    }
}
