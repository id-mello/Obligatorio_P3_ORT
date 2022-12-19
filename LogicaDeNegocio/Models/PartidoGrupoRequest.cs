using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.Models
{
    public class PartidoGrupoRequest
    {
     
        public string nombre { get; set; }
        public int idSeleccion1 { get; set; }
        public int idSeleccion2 { get; set; }
        public DateTime fecha { get; set; }
        public List<IncidenciasPartido> Incidencias { get; set; }

        
    }
}
