using AutoMapper;
using System;
using System.IO;
using TeamEye.Core.Entities;
using TeamEye.Core.Interfaces;
using TeamEye.Crosscutting.ViewModel;
using TeamEye.Services.Interfaces;

namespace TeamEye.Services
{
    public class LeitorDadosCampeonatoService : ILeitorDadosCampeonatoService
    {
        private readonly IMapper _mapper;
        private readonly ICampeonatoRepository _repo;
        private readonly ILeitorDadosCampeonato _leitor;
        public LeitorDadosCampeonatoService(IMapper mapper, ICampeonatoRepository repo, ILeitorDadosCampeonato leitor)
        {
            _mapper = mapper;
            _repo = repo;
            _leitor = leitor;
        }
        public DadosCampeonatoViewModel ImportarDados(Stream stream)
        {
            var result = _leitor.InterpretarDadosCampeonato(stream);
            _repo.Incluir(result);
            return _mapper.Map<DadosCampeonatoViewModel>(result);
        }
    }
}
