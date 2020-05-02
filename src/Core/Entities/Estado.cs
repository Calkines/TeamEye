using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Crosscutting.Attributes;

namespace TeamEye.Core.Entities
{
    public class Estado
    {
        [TxtDataSource(PositionOrder = 3)]
        public string Sigla { get; private set; }
    }
}
