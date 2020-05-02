using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Core.Entities
{
    public class Rodada
    {
        public Rodada(int ano, string nomeCampeonato = "")
        {
            Ano = ano;
            Nome = nomeCampeonato;
        }
        public int Ano { get; private set; }
        public string Nome { get; private set; }

    }
}
