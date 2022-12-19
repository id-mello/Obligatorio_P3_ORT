using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MundialProg3.Models
{
    public class ViewModelSeleccion
    {
        public int IdSeleccion { get; set; }
        public string NombrePais { get; set; }
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public string Grupo { get; set; }

    }
}
