using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class EstadoRepository : AbstractRepostiory<Estado>, IEstadoRepository
    {
        public EstadoRepository(TeamEyeEFContext context) : base(context)
        {
        }        
    }
}
