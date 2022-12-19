
using LogicaAccesoADatosUsuarios;
using LogicaAccesoADatosUsuarios.BDD;
using LogicaAplicacion.CasoDeUso.CPais;
using LogicaAplicacion.CasoDeUso.CRegion;
using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaAplicacionUsuarios.CRoles;
using LogicaAplicacionUsuarios.CUsuarios;
using LogicaAplicacionUsuarios.ICRoles;
using LogicaAplicacionUsuarios.ICUsuarios;
using LogicaDeAccesoADatos.BDD;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocioUsuarios;
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

namespace MundialProg3
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

            services.AddControllersWithViews();
            services.AddSession();

            // MUNDIAL
            services.AddScoped<IRepositorio<Region>, RepositorioRegion>();
            services.AddScoped<IRepositorioPais, RepositorioPais>();
            services.AddScoped<IRepositorio<Seleccion>, RepositorioSeleccion>();
            services.AddScoped<IRepositorio<Partido>, RepositorioPartido>();
            services.AddScoped<IAltaPais, AltaPais>();
            services.AddScoped<IEditarPais, EditarPais>();
            services.AddScoped<IEliminarPais, EliminarPais>();
            services.AddScoped<IMostrarPaises, MostrarPaises>();
            services.AddScoped<IObtenerPorRegion, ObtenerPorRegion>();
            services.AddScoped<IBuscarPaisPorAlfa3, BuscarPaisPorAlfa3>();
            services.AddScoped<IBuscarPaisPorID, BuscarPaisPorID>();
            services.AddScoped<IMostrarRegion, MostrarRegion>();
            services.AddScoped<IMostrarRegiones, MostrarRegiones>();

            // USUARIOS

            services.AddScoped<IRepositorioU<Roles>,RepositorioRoles>();
            services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            services.AddScoped<IFindAll, BuscarRoles>();
            services.AddScoped<IFindById, BuscarPorId>();
            services.AddScoped<IAdd, AddRol>();
            services.AddScoped<IAltaUsuario, AltaUsuario>();
            services.AddScoped<IBuscarUsuarioPorNombre, BuscarPorNombre>();
            services.AddScoped<ILogin, UserLog>();


            string miConexion = Configuration.GetConnectionString("MiConexion");
            string conexionUsuarios = Configuration.GetConnectionString("ConexionUsuarios");
            string urlServicios = Configuration.GetConnectionString("UrlServicio");


            services.AddDbContext<MundialContext>(options => options.UseSqlServer(miConexion));
            services.AddDbContext<UsuariosContext>(options => options.UseSqlServer(conexionUsuarios));


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
                    pattern: "{controller=Usuario}/{action=InicioSesion}");
            });
       
        }
    }
}
