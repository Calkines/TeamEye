using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Leitores
{
    public abstract class LeitorDadosCampeonatoAbstract : ILeitorDadosCampeonato
    {
        public abstract Campeonato InterpretarDadosCampeonato(Stream dados);
    }
}
