using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Crosscutting.ViewModel
{
    public class DadosTimeViewModel
    {
        public List<Time> Campeonatos { get; set; }
    }
    public class TimeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeNormalizado { get; set; }
        public string SiglaEstado { get; set; }
    }
}
