using LogicaDeNegocioUsuarios;
using System.Collections.Generic;

namespace MundialProg3.Models
{
    public class ViewModelUsuarios
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public IEnumerable<Roles> TodosLosRoles { get; set; }
    }
}

