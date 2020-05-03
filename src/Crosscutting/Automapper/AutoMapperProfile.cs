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
            CreateMap<LineDatailViewModel, DetalheRodada>().ForMember(x => x.Time, c => c.MapFrom(p => new Time(p.NomeTime, new Estado(p.SiglaEstado)))).ReverseMap();
        }
    }
}
