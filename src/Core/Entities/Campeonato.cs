using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Core.Entities
{
    public class Campeonato
    {
        private List<DetalheCampeonato> _detalhesCampeonato = new List<DetalheCampeonato>();
        public Campeonato(int ano, string nomeCampeonato = "")
        {
            Ano = ano;
            Nome = nomeCampeonato;
        }
        public int Ano { get; private set; }
        public string Nome { get; private set; }
        public IReadOnlyList<DetalheCampeonato> DetalhesCampeonato { get { return _detalhesCampeonato; } }

        public void RegistrarDetalhesCampeonato(DetalheCampeonato detalheCampeonato)
        {
            _detalhesCampeonato.Add(detalheCampeonato);
        }
    }
}
