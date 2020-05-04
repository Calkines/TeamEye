using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamEye.Core.Interfaces;
using TeamEye.Infra.Repository;

namespace TeamEye.WebApi.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICampeonatoRepository, CampeonatoRepostiory>();
            services.AddScoped<ITimeRepository, TimeRepository>();
        }
    }
}
