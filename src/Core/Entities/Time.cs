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
        #endregion

        #region . : Navegation Properties : .
        public int EstadoId { get; set; }
        public Estado Estado { get; private set; }
        #endregion

        #region . : Methods : .
        public void SetEstado(Estado estado)
        {
            Estado = estado;
        }
        #endregion
    }
}
