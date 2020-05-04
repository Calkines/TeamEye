using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamEye.Services;
using TeamEye.Services.Interfaces;

namespace TeamEye.WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            services.AddScoped<ILeitorDadosCampeonatoService, LeitorDadosCampeonatoService>();
            services.AddScoped<ICampeonatoService, CampeonatoService>();
            services.AddScoped<ITimeService, TimeService>();
        }
    }
}
