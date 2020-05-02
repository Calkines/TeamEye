using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Crosscutting.Attributes;

namespace TeamEye.Core.Entities
{
    public class Estado
    {
        [TxtDataSourceAttribute(PositionOrder = 2)]
        public string Sigla { get; private set; }
    }
}
