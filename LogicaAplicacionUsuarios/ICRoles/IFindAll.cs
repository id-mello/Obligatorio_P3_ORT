using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.ICRoles
{
    public interface IFindAll
    {
        IEnumerable<Roles> FindAll();
    }
}
