using EFCore.WebAPI.Data;
using EFCore.WebAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI
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
            // adicionar os serviços e injeções declaradas aqui em baixo

            services.AddDbContext<HeroiContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Password=paranoia13;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-T9A7732")));
            // na declaração de services acima, troquei o "DefaultConnection" pela minha string de conexão

            services.AddScoped<IHeroiRepository, HeroiRepository>();
            // declaração de repositório de Interface Heroi e Repositorio Heroi


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/api/HeroiController", async context =>
                {
                    var name = context.Request.RouteValues["HeroiController"];
                    await context.Response.WriteAsync($"Aplicacao Ok{name}!");
                }
                    
                );
            });        
        }
    }
}
