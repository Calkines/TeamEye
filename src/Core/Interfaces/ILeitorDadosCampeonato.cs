using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Core.Interfaces
{
    public interface ILeitorDadosCampeonato
    {
        Campeonato InterpretarDadosCampeonato(Stream dados);
    }
}
