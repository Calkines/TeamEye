using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Crosscutting.ViewModel
{
    public class RetornoPorTimeViewModel
    {
        public int Posicao { get; set; }
        public string NomeTimeNormalizado { get; set; }
        public int TotalPontos { get; set; }
        public int QuantidadeCampeonatosDisputados { get; set; }
        public int TotalJogos { get; set; }
        public int TotalVitorias { get; set; }
        public int TotalEmpates { get; set; }
        public int TotalDerrotas { get; set; }
        public int TotalGolsPro { get; set; }
        public int TotalGolsContra { get; set; }
        public int SaldoGols { get { return TotalGolsPro - TotalGolsContra;  } set { } }

    }
}
