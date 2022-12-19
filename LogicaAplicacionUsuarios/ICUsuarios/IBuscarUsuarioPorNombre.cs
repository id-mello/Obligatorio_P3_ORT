using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.ICUsuarios
{
    public interface IBuscarUsuarioPorNombre
    {
        public Usuarios BuscarUsuarioPorNombre(string nombre);
    }
}
