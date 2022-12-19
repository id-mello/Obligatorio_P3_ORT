using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.Models
{
    public class PartidoGrupoEdicion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idSeleccion1 { get; set; }
        public int idSeleccion2 { get; set; }
        public DateTime fecha { get; set; }
        public string Grupo { get; set; }
    }
}
