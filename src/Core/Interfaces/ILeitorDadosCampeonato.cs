using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Core.Interfaces
{
    public interface ILeitorDadosCampeonato
    {
        Rodada InterpretarDadosCampeonato(Stream dados);
    }
}
