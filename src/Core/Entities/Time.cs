using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Core.Entities
{
    public class Time
    {
        public Time(string nome, string estado)
        {
            Nome = nome;
            Estado = estado;
        }
        public string Nome { get; private set; }
        public string NomeNormalizado { get; private set; }
        public string Estado { get; private set; }
    }
}
