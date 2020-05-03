using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Attributes;

namespace TeamEye.Core.Entities
{
    public class DetalheRodada
    {
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
        
        public Rodada Rodada { get; private set; }
        public Time Time { get; private set; }
        
        public DetalheRodada(int pontos, int jogos, int vitorias, int empates, int derrotas, int golsPro, int golsContra, Rodada rodada, Time time)
        {
            Pontos = pontos;
            Jogos = jogos;
            Vitorias = vitorias;
            Empates = empates;
            Derrotas = derrotas;
            GolsPro = golsPro;
            GolsContra = golsContra;
            Rodada = rodada;
            Time = time;
        }
        public DetalheRodada()
        {
        }
        public void SetRodada(Rodada rodada)
        {
            this.Rodada = rodada;
        }
        public void SetTime(Time time)
        {
            this.Time = time;
        }
    }
}

