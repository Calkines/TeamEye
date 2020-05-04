using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Core.Interfaces
{
    public interface IDetalheCampeonatoRepostiory : IAbstractRepository<DetalheCampeonato>
    {
        IList<DetalheCampeonato> SelecionarDetalheCampeonatoPorTime(int timeId);
        IList<DetalheCampeonato> SelecionarDetalheCampeonatoPorTime(List<int> timesId);
    }
}
