using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using TeamEye.Infra;
using Microsoft.EntityFrameworkCore;
using TeamEye.WebApi.Extensions;

namespace TeamEye.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region . : Custom Services by Extension Methods : .
            services.AddThirdTools();
            services.AddServicesDependency();
            services.AddRepositories();
            #endregion

            services.AddDbContext<TeamEyeEFContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyCS"), x => x.MigrationsAssembly("TeamEye.Infra"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo { 
                        Title = "TeamEye", 
                        Version = "v1", 
                        Description= "Uma api para você ficar de olho no seu time", 
                        Contact = new OpenApiContact() { 
                            Email = "rafael_it@hotmail.com",
                            Name = "Rafael Pinto",
                            Url = new UriBuilder("http://dotartigos.wordpress.com").Uri
                        } 
                    });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
