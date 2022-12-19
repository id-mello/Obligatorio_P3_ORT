using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaDeNegocioUsuarios
{
    public class Roles
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }


    }
}
