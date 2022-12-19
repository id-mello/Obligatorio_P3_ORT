using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class SeleccionGrupoDTO
    {
        public int id { get; set; }
        public string namePais { get; set; }
        public string bandera { get; set; }
        public int golesA { get; set; }
        public int golesC { get; set; }
        public int puntos { get; set; }
    }
}
