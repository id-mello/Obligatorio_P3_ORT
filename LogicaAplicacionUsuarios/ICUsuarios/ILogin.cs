using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.ICUsuarios
{
    public interface ILogin
    {

        public Usuarios Login(string email, string password, int idRol);

    }
}
