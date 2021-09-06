using AgenciaApostas.Data;
using AgenciaApostas.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddResponseCompression();
            services.AddControllers();

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<TimeRepository, TimeRepository>();
            services.AddTransient<PartidaRepository, PartidaRepository>();
            services.AddTransient<CampeonatoRepository, CampeonatoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
