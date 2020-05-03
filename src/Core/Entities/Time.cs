using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TeamEye.Core.Attributes;
using TeamEye.Core.Extensions;
using TeamEye.Core.Interfaces;

namespace TeamEye.Core.Entities
{
    public class Time : IEntity
    {
        #region . : Constructors : .
        public Time(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
            NomeNormalizado = nome.CorrigeGrafia().TrocaSiglaEstadoPorAdjetivoPatrio().NormalizarString();
        }
        public Time()
        {

        }
        #endregion

        #region . : Properties : .
        public int Id { get; set; }
        [TxtDataSource(PositionOrder = 2)]
        public string Nome { get; private set; }        
        public string NomeNormalizado { get; private set; }
        public Estado Estado { get; private set; }
        #endregion
    }
}
