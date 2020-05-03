using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Attributes;

namespace TeamEye.Core.Entities
{
    public class Estado
    {
        public Estado(string sigla)
        {
            Sigla = sigla;
        }
        [TxtDataSource(PositionOrder = 3)]
        public string Sigla { get; private set; }
    }
}
