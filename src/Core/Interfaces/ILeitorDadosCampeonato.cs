﻿using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Core.Interfaces
{
    public interface ILeitorDadosCampeonato
    {
        DetalhesRodada InterpretarDetalhesRodada(string linha);
    }
}
