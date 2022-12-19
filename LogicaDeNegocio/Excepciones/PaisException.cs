using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.Excepciones
{
    public class PaisException : Exception
    {
        public PaisException()
        {
        }

        public PaisException(string mensaje) : base(mensaje) {  }
    }
}
