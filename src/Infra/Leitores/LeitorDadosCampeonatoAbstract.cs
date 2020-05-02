using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Leitores
{
    public abstract class LeitorDadosCampeonatoAbstract : ILeitorDadosCampeonato
    {
        public abstract DetalhesRodada InterpretarDetalhesRodada(string dado);
    }
}
