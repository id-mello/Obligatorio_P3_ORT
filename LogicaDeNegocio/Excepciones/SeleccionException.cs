using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.Excepciones
{
    public class SeleccionException : Exception
    {
        public SeleccionException()
        {
        }

        public SeleccionException(string mensaje) : base(mensaje) { }
    }
}
