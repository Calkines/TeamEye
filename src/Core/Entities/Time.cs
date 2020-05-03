using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TeamEye.Core.Attributes;
using TeamEye.Core.Extensions;

namespace TeamEye.Core.Entities
{
    public class Time
    {
        public Time(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
            NomeNormalizado = nome.CorrigeGrafia().TrocaSiglaEstadoPorAdjetivoPatrio().NormalizarString();
        }

        [TxtDataSource(PositionOrder = 2)]
        public string Nome { get; private set; }        
        public string NomeNormalizado { get; private set; }
        public Estado Estado { get; private set; }
    }
}
