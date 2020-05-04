using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamEye.Core.Interfaces;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;
using TeamEye.Crosscutting.Utils;

namespace TeamEye.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly ICampeonatoRepository _repo;
        private readonly IMapper _mapper;
        public CampeonatoService(ICampeonatoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<CampeonatoViewModel> RecuperarDadosCampeonato()
        {            
            return _mapper.Map<List<CampeonatoViewModel>>(_repo.SelecionarTodos()).OrdernarPorPosicao();
        }

        public CampeonatoViewModel RecuperarDadosCampeonato(int ano)
        {
            return _mapper.Map<CampeonatoViewModel>(_repo.SelecionarCampeonatoPorAno(ano)).OrdernarPorPosicao();
        }
    }
}
