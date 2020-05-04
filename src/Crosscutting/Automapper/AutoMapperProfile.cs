using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Core.Entities;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Core.Crosscutting.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LineDatailViewModel, DetalheCampeonato>().ForMember(x => x.Time, c => c.MapFrom(p => new Time(p.NomeTime, new Estado(p.SiglaEstado)))).ReverseMap();
            CreateMap<DadosCampeonatoViewModel, Campeonato>().ReverseMap();
            CreateMap<CampeonatoViewModel, Campeonato>().ReverseMap();
            CreateMap<DetalheCampeonatoViewModel, DetalheCampeonato>().ReverseMap()
                                                                      .ForMember(x => x.NomeTimeNormalizado, y => y.MapFrom(prop => prop.Time.NomeNormalizado))
                                                                      .ForMember(x => x.SiglaEstado, y => y.MapFrom(prop => prop.Time.Estado.Sigla));
            CreateMap<TimeViewModel, Time>().ReverseMap().ForMember(x => x.SiglaEstado, y => y.MapFrom(prop => prop.Estado.Sigla));
        }
    }
}
