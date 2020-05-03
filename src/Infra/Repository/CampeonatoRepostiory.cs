using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class CampeonatoRepostiory : AbstractRepostiory<Campeonato>, ICampeonatoRepository
    {
        public CampeonatoRepostiory(TeamEyeEFContext context) : base(context)
        {
        }

        public override void Incluir(Campeonato entity)
        {
            base.Incluir(entity);
        }
    }
}
