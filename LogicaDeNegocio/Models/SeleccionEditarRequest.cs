using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.Models
{
    public class SeleccionEditarRequest
    {
        public int IdSeleccion { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public string Grupo { get; set; }

    }
}
