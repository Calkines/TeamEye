using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Interfaces;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;

namespace TeamEye.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repo;
        private readonly IMapper _mapper;
        public TimeService(ITimeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<TimeViewModel> RecuperarDadosTime()
        {
            return _mapper.Map<List<TimeViewModel>>(_repo.SelecionarTodos());
        }
    }
}
