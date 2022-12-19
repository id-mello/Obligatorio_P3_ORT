using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class ObtenerPorRegion : IObtenerPorRegion
    {

        public IRepositorioPais RepositorioPais { get; set; }

        public ObtenerPorRegion(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        public IEnumerable<Pais> ObtenerPaisesPorRegion(Region region)
        {
            // Ver como implementar
            return RepositorioPais.ObtenerPaisesPorRegion(region);
        }
    }
}
