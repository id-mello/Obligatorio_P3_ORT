using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.EntidadesNegocio
{
    public abstract class Partido
    {
        public int Id { get; set; }
        //public List<Seleccion> Selecciones { get; set; }
        public DateTime FechaHora { get; set; }
        public List<IncidenciasPartido> Incidencias { get; set; }
        public List<Seleccion> Seleccion { get; set; }
    }
}
