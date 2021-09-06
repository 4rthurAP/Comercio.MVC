using AutoMapper;
using Comercio.MVC.Application.Tarefa;
using Comercio.MVC.Application.Tarefa.Contrato;
using Comercio.MVC.Application.Usuario;
using Comercio.MVC.Application.Usuario.Contrato;
using Comercio.MVC.Domain.Interfaces.Repository;
using Comercio.MVC.Domain.Interfaces.RepositoryReadOnly;
using Comercio.MVC.Infra.DataContext;
using Comercio.MVC.Infra.Repositories.Repository;
using Comercio.MVC.Infra.Repositories.RepositoryReadOnly;
using Comercio.MVC.Mapper;
using Comercio.MVC.Services.Criptografia;
using Comercio.MVC.Services.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.MVC
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
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DeafaultConnection"), b => b.MigrationsAssembly("Comercio.MVC.Infra"));
            });
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<Context, Context>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IUsuarioRepositoryReadOnly, UsuarioRepositoryReadOnly>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaRepositoryReadOnly, TarefaRepositoryReadOnly>();
            services.AddScoped<ITarefaApplication, TarefaApplication>();
            services.AddScoped<EnviarEmailHandler, EnviarEmailHandler>();

            services.AddSession();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
