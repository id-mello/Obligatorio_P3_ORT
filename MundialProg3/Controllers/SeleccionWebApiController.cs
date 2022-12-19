using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.Extensions.Configuration;
using System.Net;
using Web.Filters;

namespace MundialProg3.Controllers
{

    public class SeleccionWebApiController : Controller
    {


        public string Uri = "";

        public SeleccionWebApiController(IConfiguration configuration)
        {
            Uri = configuration.GetValue<string>("UrlServicio");
            Uri += "Seleccion";
        }

        #region ListarSelecciones
        [Logueado("Admin","Invitado")]
        public ActionResult ListarSelecciones()
        {
            List<Seleccion> selecciones = new List<Seleccion>();

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
                selecciones = JsonConvert.DeserializeObject<List<Seleccion>>(json);


            }
            return View(selecciones);
        }
        #endregion


        #region ADD
        public ActionResult CrearSeleccion()
        {
            return View(new Seleccion());
        }

        // POST: SeleccionWebApiController/CrearSeleccion
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Logueado("Admin")]
        public ActionResult Create(Seleccion nuevaSeleccion)
        {

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.PostAsJsonAsync(Uri, nuevaSeleccion);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("ListarSelecciones");

            }
            else
            {
                ViewBag.Error = respuesta.ReasonPhrase;

            }

            return View();

        }
        #endregion


        #region DELETE
        [Logueado("Admin")]
        public ActionResult Delete(int id)
        {
            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.DeleteAsync(Uri + "/" + id);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ListarSelecciones));
            }

            ViewBag.Error = respuesta.ReasonPhrase;

            return View("CrearSeleccion");
        }

        #endregion


        #region EDIT
        [Logueado("Admin")]
        public ActionResult UpdateSeleccion(int id)
        {
            Seleccion seleccion = new Seleccion();

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri + "/" + id);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {

                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                seleccion = JsonConvert.DeserializeObject<Seleccion>(json);

            }

            return View(seleccion);
        }

            // POST: AutorWebApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Logueado("Admin")]
        public ActionResult UpdateSeleccion(Seleccion seleccion)
        {

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.PutAsJsonAsync(Uri, seleccion);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {

                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                seleccion = JsonConvert.DeserializeObject<Seleccion>(json);

                return View("DatosSeleccionPorId", seleccion);
            }
            else
            {
                return View("DatosSeleccionPorId", seleccion);
            }
        }
        #endregion


        #region BUSCAR_POR_ID

        [Logueado("Admin","Invitado")]
        public ActionResult BuscarPorId()
        {
            return View("BuscarPorId");
        }

        // POST: AutorWebApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Logueado("Admin","Invitado")]
        public ActionResult DatosSeleccionPorId(int id)
        {

            Seleccion seleccion = new Seleccion();

            HttpClient proxy = new HttpClient();
            Task<HttpResponseMessage> tarea = proxy.GetAsync(Uri + "/" + id);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {

                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                seleccion = JsonConvert.DeserializeObject<Seleccion>(json);

            }


            return View(seleccion);

        }
        #endregion




    }
}
