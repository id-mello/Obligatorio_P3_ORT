using DTOS;
using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MundialProg3.Controllers
{
    public class PartidoWebApiController : Controller
    {


        public string Uri = "";

        public PartidoWebApiController(IConfiguration configuration)
        {
            Uri = configuration.GetValue<string>("UrlServicio");
            Uri += "PartidoDeGrupo/";

        }



        #region Listar Partidos
        public ActionResult ListarPartidos(List<PartidoDeGrupo> partidos)
            {

                HttpClient proxy = new HttpClient();
                Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();
                    string json = tarea2.Result;
                    partidos = JsonConvert.DeserializeObject<List<PartidoDeGrupo>>(json);
                }
                return View(partidos);
            }
        #endregion


        #region ViewBusquedas
        public ActionResult BuscarPartidos()
        {
            return View("BuscarPartidos");
        }

        #endregion


        #region BUSCAR_POR_ISO


        public ActionResult BuscarPorIso()
            {
                return View("BuscarPartidos");
            }
            
            // POST: AutorWebApiController/Edit/5
            public ActionResult DatosPartidosPorIso(string iso)
            {
                
                List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();

                HttpClient proxy = new HttpClient();
                Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri + "iso/" + iso);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {

                    HttpContent contenido = respuesta.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();
                    string json = tarea2.Result;
                    partidos = JsonConvert.DeserializeObject<List<PartidoDeGrupo>>(json);


                }


                return View("listarPartidos", partidos);


            }
        #endregion

        #region BUSCAR_POR_PAIS

        public ActionResult BuscarPorPais()
        {
            return View("BuscarPartidos");
        }

        // POST: AutorWebApiController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DatosPartidosPorPais(string nombrePais)
        {
            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri + "pais/" + nombrePais);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {

                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                partidos = JsonConvert.DeserializeObject<List<PartidoDeGrupo>>(json);
            }
            return View("listarPartidos", partidos);
        }
        #endregion


        #region BUSCAR_POR_GRUPO

        public ActionResult BuscarPorGrupo()
        {
            return View("BuscarPartidos");
        }

        // POST: AutorWebApiController/Edit/5
        
        public ActionResult DatosPartidosPorGrupo(string grupo)
        {

            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri + "grupo/" + grupo);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {

                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                partidos = JsonConvert.DeserializeObject<List<PartidoDeGrupo>>(json);
            }
            return View("listarPartidos", partidos);

        }
        #endregion


        #region BUSCAR_POR_FECHAS

        public ActionResult BuscarPorFecha()
        {
            return View("BuscarPartidos");
        }

        // POST: AutorWebApiController/Edit/5
        public ActionResult DatosPartidosPorFecha(string desde, string hasta)
        {

            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri +desde +"/"+hasta);
            Console.WriteLine(Uri);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {

                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                partidos = JsonConvert.DeserializeObject<List<PartidoDeGrupo>>(json);
            }
            return View("listarPartidos", partidos);

        }
        #endregion


        #region MOSTRAR_TABLA_GRUPO

        public ActionResult BuscarTablaGrupo()
        {
            return View("BuscarTablaGrupo");
        }

        public ActionResult MostrarGrupo(string grupo)
        {
            List<SeleccionGrupoDTO> partidos = new List<SeleccionGrupoDTO>();

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri + "tablaGrupo/" + grupo);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                partidos = JsonConvert.DeserializeObject<List<SeleccionGrupoDTO>>(json);
            }
            if(partidos.Count > 0)
            {
                return View(partidos);
            } else {
                ViewBag.Mensaje = "Por favor pruebe con un grupo distinto, letra unica en mayuscula";
                return View("BuscarTablaGrupo");
                    }
        }

        #endregion

    }
}
