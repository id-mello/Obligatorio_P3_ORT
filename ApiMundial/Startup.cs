using LogicaAplicacion.CasoDeUso.CPais;
using LogicaAplicacion.CasoDeUso.CPartidosDeGrupo;
using LogicaAplicacion.CasoDeUso.CRegion;
using LogicaAplicacion.CasoDeUso.CSeleccion;
using LogicaAplicacion.CasoDeUso.CSelecion;
using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeAccesoADatos.BDD;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMundial
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Repositorio
            services.AddScoped<IRepositorio<Region>, RepositorioRegion>();
            services.AddScoped<IRepositorioPartidoDeGrupo, RepositorioPartidoDeGrupo>(); 
            services.AddScoped<IRepositorio<Seleccion>, RepositorioSeleccion>();
            services.AddScoped<IRepositorioPais, RepositorioPais>();
            //Caso de uso
            //region
            services.AddScoped<IMostrarRegion, MostrarRegion>();
            services.AddScoped<IMostrarRegiones, MostrarRegiones>();
            services.AddScoped<IAltaRegion, AltaRegion>();
            services.AddScoped<IEditarRegion, EditarRegion>();
            services.AddScoped<IEliminarRegion, EliminarRegion>();
            // partidoDeGrupo
            services.AddScoped<IMostrarPartidosDeGrupos, MostrarPartidosDeGrupos>();
            services.AddScoped<IAltaPartidoDeGrupo, AltaPartidoDeGrupo>();
            services.AddScoped<IEditarPartidoDeGrupo, EditarPartidoDeGrupo>();
            services.AddScoped<IEliminarPartidoDeGrupo, EliminarPartidoDeGrupo>();
            services.AddScoped<IMostrarPartidoDeGrupo, MostrarPartidoDeGrupo>();
            services.AddScoped<IMostrarPartidosPorGrupo, MostrarPartidosPorGrupo>();
            services.AddScoped<IMostrarPartidosPorPais, MostrarPartidoPorPais>();
            services.AddScoped<IMostrarPartidosPorIso, MostrarPartidoPorIso>();
            services.AddScoped<IMostrarPartidosPorfecha, MostrarPartidosPorfecha>();
            services.AddScoped<IMostrarTablaGrupo, MostrarTablaGrupo>();
            //seleccion
            services.AddScoped<IAltaSeleccion, AltaSeleccion>();
            services.AddScoped<IBuscarSeleccionId, BuscarSeleccion>();
            services.AddScoped<IModificarSelecion, EditarSeleccion>();
            services.AddScoped<IEliminarSeleccion, EliminarSeleccion>();
            services.AddScoped<IListaSeleccion, ListaSeleccion>();


            //Pais
            services.AddScoped<IBuscarPaisPorID, BuscarPaisPorID>();




            // SQL
            string miConexion = Configuration.GetConnectionString("MiConexion");
            services.AddDbContext<MundialContext>(options => options.UseSqlServer(miConexion));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
