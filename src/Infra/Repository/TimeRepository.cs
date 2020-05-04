using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;

namespace TeamEye.Infra.Repository
{
    public class TimeRepository : AbstractRepostiory<Time>, ITimeRepository
    {
        public TimeRepository(TeamEyeEFContext context) : base(context)
        {
        }
    }
}
