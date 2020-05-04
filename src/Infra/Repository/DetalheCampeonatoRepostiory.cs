using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class DetalheCampeonatoRepostiory : AbstractRepostiory<DetalheCampeonato>, IDetalheCampeonatoRepository
    {
        public DetalheCampeonatoRepostiory(TeamEyeEFContext context): base(context)
        {
        }

        public IList<DetalheCampeonato> SelecionarDetalheCampeonatoPorTime(int timeId)
        {
            return _context.DetalheCampeonatos.Where(x => x.TimeId == timeId).Include(x => x.Time).ThenInclude(x => x.Estado).ToList();
        }
        public IList<DetalheCampeonato> SelecionarDetalheCampeonatoPorTime(List<int> timesIds)
        {
            return _context.DetalheCampeonatos.Where(x => timesIds.Contains(x.TimeId)).Include(x => x.Time).ThenInclude(x => x.Estado).ToList();
        }
    }
}
