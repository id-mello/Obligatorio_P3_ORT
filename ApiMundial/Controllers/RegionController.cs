
using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MundialProg3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public IAltaRegion AltaRegion { get; set; }
        public IEditarRegion EditarRegion { get; set; }
        public IEliminarRegion EliminarRegion { get; set; }
        public IMostrarRegiones MostrarRegiones { get; set; }
        public IMostrarRegion MostrarRegion { get; set; }

        public RegionController(IAltaRegion altaRegion, 
            IEditarRegion editarRegion, 
            IEliminarRegion eliminarRegion, 
            IMostrarRegiones mostrarRegiones,
            IMostrarRegion mostrarRegion)
        {
            AltaRegion = altaRegion;
            EditarRegion = editarRegion;
            EliminarRegion = eliminarRegion;
            MostrarRegiones = mostrarRegiones;
            MostrarRegion = mostrarRegion;
        }
        // GET: api/<RegionController>
        [HttpGet]
        //public IEnumerable<Region> Get()
        public IActionResult Get()
        {
            IEnumerable<Region> Regiones = new List<Region>();
            try
            {
                Regiones = MostrarRegiones.FindAll();
            }
            catch (Exception ex)
            {
                BadRequest();
            }
            //return Regiones.ToList();
            return Ok(Regiones);

        }

        [HttpGet("{id}")]
        [Route("{id}", Name = "GetRegion")]
        public Region Get(int id)
        {
            
            return MostrarRegion.FindById(id);
            
        }

        // POST api/<RegionController>
        [HttpPost]
        public IActionResult Post([FromBody] Region region)
        {
            try
            {
                if (region.Nombre == "")
                {
                    return BadRequest();

                }
                AltaRegion.Add(region);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            return CreatedAtRoute("GetRegion", new { Id = region.Id }, region);

        }

        // PUT api/<RegionController>/5
        [HttpPut("Editar")]
        public IActionResult Put(Region region)
        {
            try
            {
                if (region.Nombre == "")
                {
                    return BadRequest();

                }
                EditarRegion.Update(region);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            return CreatedAtRoute("Get", new { Id = region.Id }, region);
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("Delete")]
        public void Delete(Region region)
        {
            try 
            { 
                EliminarRegion.Delete(region);
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
          
        }
    }
}
