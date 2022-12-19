using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocioUsuarios
{
    public class UsuarioException : Exception
    {
        public UsuarioException()
        {
        }

        public UsuarioException(string mensaje) : base(mensaje) {  }
    }
}
