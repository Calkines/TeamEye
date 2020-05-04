using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class DetalheCampeonatoRepostiory : AbstractRepostiory<DetalheCampeonato>, IDetalheCampeonatoRepostiory
    {
        public DetalheCampeonatoRepostiory(TeamEyeEFContext context): base(context)
        {
        }

        public IList<DetalheCampeonato> SelecionarDetalheCampeonatoPorTime(int timeId)
        {
            return _context.DetalheCampeonatos.Where(x => x.TimeId == timeId).ToList();
        }
    }
}
