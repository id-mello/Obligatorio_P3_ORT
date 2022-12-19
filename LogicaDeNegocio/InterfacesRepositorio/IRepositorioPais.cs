using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorioPais : IRepositorio<Pais>
    {
        public Pais BuscarPaisPorAlfa3(string codAlfa3);
        IEnumerable<Pais> ObtenerPaisesPorRegion(Region region);

    }
}
