using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public override List<Time> SelecionarTodos()
        {
            return _context.Times.Include(x => x.Estado).ToList();
        }
    }
}
