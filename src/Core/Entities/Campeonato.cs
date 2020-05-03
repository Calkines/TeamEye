using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Interfaces;

namespace TeamEye.Core.Entities
{
    public class Campeonato : IEntity
    {
        #region . : Private Members : .
        private List<DetalheCampeonato> _detalhesCampeonato = new List<DetalheCampeonato>();
        #endregion

        #region . : Constructors : .
        public Campeonato(int ano, string nomeCampeonato = "")
        {
            Ano = ano;
            Nome = nomeCampeonato;
        }
        public Campeonato()
        {

        }
        #endregion

        #region . : Properties : .
        public int Id { get; private set; }
        public int Ano { get; private set; }
        public string Nome { get; private set; }
        public IReadOnlyList<DetalheCampeonato> DetalhesCampeonato { get { return _detalhesCampeonato; } }
        #endregion

        #region . : Methods : . 
        public void RegistrarDetalhesCampeonato(DetalheCampeonato detalheCampeonato)
        {
            _detalhesCampeonato.Add(detalheCampeonato);
        }
        #endregion
    }
}
