
using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MundialProg3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MundialProg3.Controllers
{
    public class PaisController : Controller
    {

        public IAltaPais AltaPais;
        public IEliminarPais EliminarPais;
        public IEditarPais EditarPais;
        public IMostrarPaises MostrarPaises;
        public IObtenerPorRegion ObtenerPorRegion;
        public IBuscarPaisPorAlfa3 BuscarPaisPorAlfa3;
        public IBuscarPaisPorID BuscarPaisPorID;
        public IMostrarRegiones MostrarRegiones;
        public IMostrarRegion MostrarRegion;
        public IWebHostEnvironment WebHostEnvironment;

        public PaisController(IAltaPais altaPais, IEliminarPais eliminarPais, IEditarPais editarPais, IMostrarPaises mostrarPaises, 
            IObtenerPorRegion obtenerPorRegion, IWebHostEnvironment webHost, IBuscarPaisPorAlfa3 buscarPaisPorAlfa3, IBuscarPaisPorID buscarPaisPorID,
            IMostrarRegiones mostrarRegiones, IMostrarRegion mostrarRegionPorId)
        {
            this.AltaPais = altaPais;
            this.EliminarPais = eliminarPais;
            this.EditarPais = editarPais;
            this.MostrarPaises = mostrarPaises;
            this.ObtenerPorRegion = obtenerPorRegion;
            this.BuscarPaisPorAlfa3 = buscarPaisPorAlfa3;
            this.BuscarPaisPorID = buscarPaisPorID;
            this.MostrarRegiones = mostrarRegiones;
            this.MostrarRegion = mostrarRegionPorId;
            this.WebHostEnvironment = webHost;
        }

        public IActionResult AgregarPais()
        {
            ViewModelPaises vmPais = new ViewModelPaises();
            vmPais.TodasLasRegiones = MostrarRegiones.FindAll();
            return View("AgregarPais", vmPais);
        }

        [HttpPost]
        public IActionResult AgregarPais(ViewModelPaises pais)
        {
            try
            {
                Pais miPais = new Pais();
                miPais.IsoAlfa3 = pais.IsoAlfa3.ToUpper(); 
                miPais.PbiPerCapita = pais.PbiPerCapita;
                miPais.Poblacion = pais.Poblacion;
                miPais.Nombre = pais.Nombre;
                miPais.Imagen = pais.ImagenBandera.FileName;
                miPais.IdRegion = pais.IdRegion;
                miPais.Region = MostrarRegion.FindById(pais.IdRegion);
                AltaPais.Add(miPais);

                string rutaRaiz = WebHostEnvironment.WebRootPath;
                string rutaImagenes = Path.Combine(rutaRaiz,"Imagenes");
                string rutaArchivo = Path.Combine(rutaImagenes, pais.ImagenBandera.FileName);
                FileStream streamFoto = new FileStream(rutaArchivo, FileMode.Create);
                pais.ImagenBandera.CopyTo(streamFoto);
                return RedirectToAction("ListarPaises");
            }
            catch (Exception ex)
            {
                pais.TodasLasRegiones = MostrarRegiones.FindAll();
                ViewBag.Error = ex.Message;
                return View("AgregarPais", pais);
            }
        }
        



        public IActionResult ListarPaises()
        {
            IEnumerable<Pais> paises = MostrarPaises.FindAll();
            return View(paises);
        }


        public IActionResult BajaPais(int idPais)
        {
            try
            {
                Pais pais = new Pais();
                pais = BuscarPaisPorID.FindByID(idPais);
                EliminarPais.Delete(pais);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("REFERENCE constraint"))
                {
                    ViewBag.Error = "No se puede eliminar debido a que tiene una selección asignada";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                }
                Pais pais = BuscarPaisPorID.FindByID(idPais);
                return View("VerPais", pais);
            }

            return RedirectToAction("ListarPaises");
        }


        public IActionResult UpdatePais(int idPais)
        {
            ViewModelPaises vmPais = new ViewModelPaises();
            Pais pais = BuscarPaisPorID.FindByID(idPais);
            vmPais.IdPais = pais.Id;
            vmPais.IsoAlfa3 = pais.IsoAlfa3;
            vmPais.PbiPerCapita = pais.PbiPerCapita;
            vmPais.Poblacion = pais.Poblacion;
            vmPais.Nombre = pais.Nombre;
            vmPais.TodasLasRegiones = MostrarRegiones.FindAll();
            vmPais.IdRegion = pais.Region.Id;
            return View("UpdatePais", vmPais);
        }

        [HttpPost]
        public IActionResult UpdatePais(ViewModelPaises paisVM)
        {

            try
            {
                Pais pais = BuscarPaisPorID.FindByID(paisVM.IdPais);
                pais.IsoAlfa3 = paisVM.IsoAlfa3.ToUpper();
                pais.PbiPerCapita = paisVM.PbiPerCapita;
                pais.Poblacion = paisVM.Poblacion;
                pais.Nombre = paisVM.Nombre;
                if (paisVM.ImagenBandera != null) { 
                    pais.Imagen = paisVM.ImagenBandera.FileName;
                    string rutaRaiz = WebHostEnvironment.WebRootPath;
                    string rutaImagenes = Path.Combine(rutaRaiz, "Imagenes");
                    string rutaArchivo = Path.Combine(rutaImagenes, paisVM.ImagenBandera.FileName);
                    FileStream streamFoto = new FileStream(rutaArchivo, FileMode.Create);
                    paisVM.ImagenBandera.CopyTo(streamFoto);
                }
                if (paisVM.IdRegion != null & paisVM.IdRegion != 0)
                {
                    pais.Region = MostrarRegion.FindById(paisVM.IdRegion);

                }
                EditarPais.Update(pais);
            }
            catch (Exception ex)
            {
                paisVM.TodasLasRegiones = MostrarRegiones.FindAll();
                ViewBag.Error = ex.Message;
                return View("UpdatePais", paisVM);

            }

            return RedirectToAction("ListarPaises");

        }

        public IActionResult BuscarPorAlfa3()
        {
            return View("BuscarPorAlfa3");
        }

        
        public IActionResult BuscarPorIsoAlfa3(string codAlfa3)
        {

            try
            {           
                Pais pais = BuscarPaisPorAlfa3.BuscarPaisPorAlfa3(codAlfa3);
            
                
                return View("VerPais",pais);
                
                
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("Sequence contains no elements"))
                {
                    ViewBag.Error = "No se encontró un país por el código ISO ingresado";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                }

                return View("BuscarPorAlfa3");

            }

        }
           
        


        public IActionResult BuscarPaisesPorRegion()
        {
            
            ViewModelPaises vmPais = new ViewModelPaises();
            vmPais.TodasLasRegiones = MostrarRegiones.FindAll();
            return View("BuscarPaisesPorRegion", vmPais);
        }

        [HttpPost]
        public IActionResult BuscarPaisesPorRegion(int idRegion)
        {
            try
            {
                Region region = MostrarRegion.FindById(idRegion);
                IEnumerable<Pais> paises = ObtenerPorRegion.ObtenerPaisesPorRegion(region);
                
                if (paises.Count() != 0)
                {
                    return View("VerPaisesPorRegion", paises);
                }
                else
                {
                    throw new Exception("No se encontraron países de la región seleccionada.");
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("No se encontraron países de la región seleccionada."))
                {
                    ViewBag.Error = "No se encontraron países de la región seleccionada.";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                }

                ViewModelPaises vmPais = new ViewModelPaises();
                vmPais.TodasLasRegiones = MostrarRegiones.FindAll();
                return View("BuscarPaisesPorRegion", vmPais);

            }

        }


        public IActionResult BuscarPaisPorId()
        {
            return View("BuscarPorId");
        }

        [HttpPost]
        public IActionResult BuscarPaisPorId(int id)
        {

            try
            {
                Pais pais = BuscarPaisPorID.FindByID(id);
                return View("VerPais", pais);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("Sequence contains no elements"))
                {
                    ViewBag.Error = "No se encontró un país por el id ingresado";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                }
                return View("BuscarPorId");

            }

        }
    }
}
