
using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDeNegocio.Models;
using LogicaAplicacion.ICasoDeUso.IPais;

namespace MundialProg3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SeleccionController : Controller
    {

        public IAltaSeleccion AltaSeleccion { get; set; }
        public IEliminarSeleccion EliminarSeleccion { get; set; }
        public IModificarSelecion EditarSeleccion { get; set; }
        public IListaSeleccion ListaSeleccion { get; set; }
        public IBuscarSeleccionId BuscarSeleccion { get; set; }
        public IBuscarPaisPorID BuscarPaisPorId { get; set; }



        public SeleccionController(IAltaSeleccion altaSeleccion,
            IEliminarSeleccion eliminarSeleccion,
            IModificarSelecion editarSeleccion, 
            IListaSeleccion mostrarSelecciones,
            IBuscarSeleccionId buscarSeleccion, 
            IBuscarPaisPorID buscarPaisPorId)
        {
            this.AltaSeleccion = altaSeleccion;
            this.EliminarSeleccion = eliminarSeleccion;
            this.EditarSeleccion = editarSeleccion;
            this.ListaSeleccion = mostrarSelecciones;
            this.BuscarSeleccion = buscarSeleccion;
            this.BuscarPaisPorId = buscarPaisPorId;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Seleccion> Selecciones = new List<Seleccion>();
            try
            {
                Selecciones = ListaSeleccion.FindAll();
            }
            catch (Exception ex)
            {
                BadRequest();
            }
            return Ok(Selecciones);
        }

        [HttpGet("{id}")]
        [Route("{id}", Name = "GetSeleccion")]
        public Seleccion Get(int id)
        {
            return BuscarSeleccion.FindByID(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SeleccionRequest data)
        {
            try
            {
                if (data.idPais > 0)
                {
                    if (data.Nombre != "")
                    {
                        IEnumerable<Seleccion> selecciones = new List<Seleccion>();
                        selecciones = ListaSeleccion.FindAll();
                        bool existe = false;
                        foreach (Seleccion s in selecciones)
                        {
                            if (s.IdPais == data.idPais)
                            {
                                existe = true; break;
                            }
                        }
                        if (!existe)
                        {
                            if (data.CantidadApostadores > 0)
                            {
                                Seleccion seleccion = new Seleccion();
                                Pais pais = BuscarPaisPorId.FindByID(data.idPais);
                                seleccion.IdPais = data.idPais;
                                seleccion.Pais = pais;
                                seleccion.Nombre = data.Nombre;
                                seleccion.Email = data.Email;
                                seleccion.Telefono = data.Telefono;
                                seleccion.CantidadApostadores = data.CantidadApostadores;
                                seleccion.Grupo = data.Grupo;
                                AltaSeleccion.Add(seleccion);
                                return Ok(data.Nombre);

                            }
                            else
                            {
                                return BadRequest("La cantidd de apostadores debe ser mayor a 0");
                            }

                        }
                        else
                        {
                            return BadRequest("Ya hay una seleccion con ese pais");
                        }
                    }
                    else
                    {
                        return BadRequest("El nombre no puede ser vacio");
                    }
                }
                else
                {
                    return BadRequest("Error en el pais seleccionado");
                }



            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //return CreatedAtRoute("GetSeleccion", new { Id = seleccion.Id }, seleccion);

        }

    
        [HttpPut]
        public IActionResult Put([FromBody] Seleccion data)
        {
            try
            {
                if (data.Id == null || data.Nombre == "")
                {
                    return BadRequest();

                }
                Seleccion seleccion = new Seleccion();
                seleccion = BuscarSeleccion.FindByID(data.Id);
                Pais pais = BuscarPaisPorId.FindByID(data.IdPais);
                seleccion.Pais = pais;
                seleccion.Nombre = data.Nombre;
                seleccion.Email = data.Email;
                seleccion.Telefono = data.Telefono;
                seleccion.CantidadApostadores = data.CantidadApostadores;
                seleccion.Grupo = data.Grupo;
                seleccion.IdPais = data.IdPais;
                EditarSeleccion.Update(seleccion);
                return CreatedAtRoute("GetSeleccion", new { Id = seleccion.Id }, seleccion);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            //return CreatedAtRoute("Get", new { Id = seleccion.Id }, seleccion);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Seleccion seleccion = new Seleccion();
                seleccion = BuscarSeleccion.FindByID(id);
                EliminarSeleccion.Delete(seleccion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }
    }
}