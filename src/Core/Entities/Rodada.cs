using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Core.Entities
{
    public class Rodada
    {
        private List<DetalheRodada> _detalhesRodada = new List<DetalheRodada>();
        public Rodada(int ano, string nomeCampeonato = "")
        {
            Ano = ano;
            Nome = nomeCampeonato;
        }
        public int Ano { get; private set; }
        public string Nome { get; private set; }
        public IReadOnlyList<DetalheRodada> DetalhesRodada { get { return _detalhesRodada; } }

        public void RegistrarDetalhesDaRodada(DetalheRodada detalheRodada)
        {
            _detalhesRodada.Add(detalheRodada);
        }
    }
}
