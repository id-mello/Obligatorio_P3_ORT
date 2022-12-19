using DTOS;
using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiMundial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoDeGrupoController : ControllerBase
    {
        public IAltaPartidoDeGrupo AltaPartidoDeGrupo { get; set; }
        public IEditarPartidoDeGrupo EditarPartidoDeGrupo { get; set; }
        public IEliminarPartidoDeGrupo EliminarPartidoDeGrupo { get; set; }
        public IMostrarPartidosDeGrupos MostrarPartidosDeGrupos { get; set; }
        public IMostrarPartidoDeGrupo MostrarPartidoDeGrupo { get; set; }
        public IBuscarSeleccionId BuscarSeleccionId { get; set; }
        public IMostrarPartidosPorGrupo MostrarPartidosPorGrupo { get; set; }
        public IMostrarPartidosPorPais MostrarPartidosPorPais { get; set; }
        public IMostrarPartidosPorIso MostrarPartidosPorIso { get; set; }
        public IMostrarPartidosPorfecha MostrarPartidosPorFecha { get; set; }
        public IMostrarTablaGrupo MostrarTablaGrupo { get; set; }

        public PartidoDeGrupoController(IAltaPartidoDeGrupo altaPartidoDeGrupo,
             IEditarPartidoDeGrupo editarPartidoDeGrupo,
             IEliminarPartidoDeGrupo eliminarPartidoDeGrupo,
             IMostrarPartidosDeGrupos mostrarPartidosDeGrupos,
             IMostrarPartidoDeGrupo mostrarPartidoDeGrupo,
             IBuscarSeleccionId buscarSeleccionId,
             IMostrarPartidosPorGrupo mostrarPartidosPorGrupo,
             IMostrarPartidosPorPais mostrarPartidosPorPais,
             IMostrarPartidosPorIso mostrarPartidosPorIso,
             IMostrarPartidosPorfecha mostrarPartidosPorFecha,
             IMostrarTablaGrupo mostrarTablaGrupo)


        {
            AltaPartidoDeGrupo = altaPartidoDeGrupo;
            EditarPartidoDeGrupo = editarPartidoDeGrupo;
            EliminarPartidoDeGrupo = eliminarPartidoDeGrupo;
            MostrarPartidosDeGrupos = mostrarPartidosDeGrupos;
            MostrarPartidoDeGrupo = mostrarPartidoDeGrupo;
            BuscarSeleccionId = buscarSeleccionId;
            MostrarPartidosPorGrupo = mostrarPartidosPorGrupo;
            MostrarPartidosPorPais = mostrarPartidosPorPais;
            MostrarPartidosPorIso = mostrarPartidosPorIso;
            MostrarPartidosPorFecha = mostrarPartidosPorFecha;
            MostrarTablaGrupo = mostrarTablaGrupo;
        }
        // GET: api/<PartidoDeGrupoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
            try
            {
                partidos = MostrarPartidosDeGrupos.FindAll();
                return Ok(partidos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }



        // GET api/<PartidoDeGrupoController>/5
        [HttpGet("{id}")]
        [Route("{id}", Name = "GetPartidoG")]
        public IActionResult Get(int id)
        {
            try
            {
                Partido partido = MostrarPartidoDeGrupo.FindByID(id);
                return Ok(partido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        // POST api/<PartidoDeGrupoController>
        [HttpPost]
        public IActionResult Post(PartidoGrupoRequest data)
        {
            PartidoDeGrupo partido = new PartidoDeGrupo();
            try
            {
                Seleccion seleccion1 = BuscarSeleccionId.FindByID(data.idSeleccion1);
                Seleccion seleccion2 = BuscarSeleccionId.FindByID(data.idSeleccion2);
                if (seleccion1 != null && seleccion2 != null)
                {
                    if (seleccion1.Id != seleccion2.Id)
                    {
                        if (seleccion1.Grupo == seleccion2.Grupo)
                        {
                            partido.Seleccion = new List<Seleccion>();
                            partido.Nombre = data.nombre;
                            partido.Seleccion.Add(seleccion1);
                            partido.Seleccion.Add(seleccion2);
                            partido.FechaHora = data.fecha;
                            partido.Incidencias = new List<IncidenciasPartido>();
                            foreach (IncidenciasPartido i in data.Incidencias)
                            {
                                partido.Incidencias.Add(i);
                            }
                            AltaPartidoDeGrupo.Add(partido);
                            return CreatedAtRoute("GetPartidoG", new { Id = partido.Id }, partido);
                        }
                        else
                        {
                            return BadRequest("Las selecciones deben ser del mismo grupo");
                        }
                    }
                    else
                    {
                        return BadRequest("Una seleccion no puede jugar contra si misma");
                    }
                }
                else
                {
                    return BadRequest("Uno de los id de seleccion no es valido.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        // PUT api/<PartidoDeGrupoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        // DELETE api/<PartidoDeGrupoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PartidoDeGrupo partido = MostrarPartidoDeGrupo.FindByID(id);
                EliminarPartidoDeGrupo.Delete(partido);
                return Ok("Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{letra}")]
        [Route("grupo/{letra}")]
        public IEnumerable<PartidoDeGrupo> GetGrupo(string letra)
        {
            try
            {
                IEnumerable<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
                partidos = MostrarPartidosPorGrupo.FindGrupo(letra);
                return partidos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("{nombre}")]
        [Route("pais/{nombre}")]
        public IEnumerable<PartidoDeGrupo> Get(string nombre)
        {
            try
            {
                IEnumerable<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
                partidos = MostrarPartidosPorPais.FindByPais(nombre);
                return partidos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("{codigo}"), Route("iso/{codigo}")]
        //[Route("iso/{codigo}")]
        public IEnumerable<PartidoDeGrupo> GetCodigo(string codigo)
        {
            try
            {
                IEnumerable<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
                partidos = MostrarPartidosPorIso.FindByISO(codigo);
                return partidos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("{desde}/{hasta}")]
        [Route("fecha/desde{desde}/hasta{hasta}")]
        public IEnumerable<PartidoDeGrupo> Get(DateTime desde, DateTime hasta)
        {
            try
            {
                IEnumerable<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
                partidos = MostrarPartidosPorFecha.FindByFechas(desde,hasta);
                return partidos;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet("{letra}")]
        [Route("tablaGrupo/{letra}")]
        public IEnumerable<SeleccionGrupoDTO> GetTabla(string letra)
        {
            try
            {
                IEnumerable<SeleccionGrupoDTO> s = new List<SeleccionGrupoDTO>();
                IEnumerable<SeleccionTablaGrupo> st = new List<SeleccionTablaGrupo>();
                st = MostrarTablaGrupo.FindGrupo(letra);
                s = st.Select(i => 
                new SeleccionGrupoDTO
                {
                    id= i.Id,
                    namePais= i.NamePais,
                    bandera= i.Bandera,
                    golesA= i.GolesA,
                    golesC= i.GolesC,
                    puntos= i.Puntos,
                }).ToList();
                s = s.OrderByDescending(i => i.puntos);
                return s;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
