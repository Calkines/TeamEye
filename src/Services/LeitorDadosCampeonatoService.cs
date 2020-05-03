using AutoMapper;
using System;
using TeamEye.Services.Interfaces;
using TeamEye.Services.ViewModel;

namespace TeamEye.Services
{
    public class LeitorDadosCampeonatoService : ILeitorDadosCampeonatoService
    {
        private readonly IMapper _mapper;
        public LeitorDadosCampeonatoService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public DadosCampeonatoViewModel BuscarDados()
        {
            throw new NotImplementedException();
        }
    }
}
