using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;

namespace TeamEye.Infra.Repository
{
    public class DetalheCampeonatoRepostiory : AbstractRepostiory<DetalheCampeonato>
    {
        public DetalheCampeonatoRepostiory(TeamEyeEFContext context): base(context)
        {
        }
    }
}
