using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.Models
{
    public class SeleccionRequest
    {
        
        public string Nombre { get; set; }
        public int idPais { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public string Grupo { get; set; }

    }
}
