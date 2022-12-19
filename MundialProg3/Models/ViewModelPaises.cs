using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MundialProg3.Models
{
    public class ViewModelPaises
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public string IsoAlfa3 { get; set; }
        public double PbiPerCapita { get; set; }
        public int Poblacion { get; set; }
        public IFormFile ImagenBandera { get; set; }
        public int IdRegion { get; set; }
        public IEnumerable<Region> TodasLasRegiones { get; set; }
    }
}

