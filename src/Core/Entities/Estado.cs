using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Attributes;
using TeamEye.Core.Interfaces;

namespace TeamEye.Core.Entities
{
    public class Estado : IEntity
    {
        #region . : Constructor : .
        public Estado(string sigla)
        {
            Sigla = sigla;
        }
        #endregion

        #region . : Properties : .
        public int Id { get; private set; }
        [TxtDataSource(PositionOrder = 3)]
        public string Sigla { get; private set; }
        #endregion
    }
}
