using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Interfaces;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;

namespace TeamEye.Services
{
    public class DetalheCampeonatoService : IDetalheCampeonatoService
    {
        private readonly IDetalheCampeonatoRepostiory _repo;
        private readonly IMapper _mapper;
        public DetalheCampeonatoService(IDetalheCampeonatoRepostiory repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public List<DetalheCampeonatoViewModel> SelecionarDetalheCampeonatoPorTime(int timeId)
        {
            return _mapper.Map<List<DetalheCampeonatoViewModel>>(_repo.SelecionarDetalheCampeonatoPorTime(timeId));
        }
        public List<DetalheCampeonatoViewModel> SelecionarDetalheCampeonatoPorTime(List<int> timesId)
        {
            return _mapper.Map<List<DetalheCampeonatoViewModel>>(_repo.SelecionarDetalheCampeonatoPorTime(timesId));
        }
    }
}
