using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Crosscutting.Attributes;

namespace TeamEye.Core.Entities
{
    public class Time
    {
        public Time(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
            NomeNormalizado = StringNormalizationExtensions.Normalize(nome);
        }

        [TxtDataSource(PositionOrder = 2)]
        public string Nome { get; private set; }        
        public string NomeNormalizado { get; private set; }
        public Estado Estado { get; private set; }
    }
}
