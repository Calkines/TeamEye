using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Attributes;
using TeamEye.Core.Interfaces;

namespace TeamEye.Core.Entities
{
    public class DetalheCampeonato : IEntity
    {
        #region . : Constructors : .
        public DetalheCampeonato(int pontos, int jogos, int vitorias, int empates, int derrotas, int golsPro, int golsContra, Campeonato campeonato, Time time)
        {
            Pontos = pontos;
            Jogos = jogos;
            Vitorias = vitorias;
            Empates = empates;
            Derrotas = derrotas;
            GolsPro = golsPro;
            GolsContra = golsContra;
            Campeonato = campeonato;
            Time = time;
        }
        public DetalheCampeonato()
        {
        }
        #endregion

        #region . : Properties : .
        public int Id { get; private set; }
        [TxtDataSource(PositionOrder = 1)]
        public int Posicao { get; private set; }
        [TxtDataSource(PositionOrder = 4)]
        public int Pontos { get; private set; }

        [TxtDataSource(PositionOrder = 5)]
        public int Jogos { get; private set; }

        [TxtDataSource(PositionOrder = 6)]
        public int Vitorias { get; private set; }

        [TxtDataSource(PositionOrder = 7)]
        public int Empates { get; private set; }

        [TxtDataSource(PositionOrder = 8)]
        public int Derrotas { get; private set; }

        [TxtDataSource(PositionOrder = 9)]
        public int GolsPro { get; private set; }

        [TxtDataSource(PositionOrder = 10)]
        public int GolsContra { get; private set; }
        #endregion

        #region . : Navegation Properties : .
        public int CampeonatoId { get; set; }
        public Campeonato Campeonato { get; private set; }
        public int TimeId { get; set; }
        public Time Time { get; private set; }
        #endregion

        #region . : Methods : .
        public void SetCampeonato(Campeonato campeonato)
        {
            Campeonato = campeonato;
        }
        public void SetTime(Time time)
        {
            Time = time;
        }
        #endregion
    }
}

