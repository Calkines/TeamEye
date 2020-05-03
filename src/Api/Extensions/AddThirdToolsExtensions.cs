using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamEye.Core.Crosscutting.Automapper;
using TeamEye.Core.Interfaces;
using TeamEye.Infra.Leitores;

namespace TeamEye.WebApi.Extensions
{
    public static class AddThirdToolsExtensions
    {
        public static void AddThirdTools(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<ILeitorDadosCampeonato, LeitorTxtDadosCampeonato>();
        }
    }
}

