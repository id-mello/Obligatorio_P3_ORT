using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CRegion
{
    public class MostrarRegiones : IMostrarRegiones
    {
        public IRepositorio<Region> RepositorioRegion { get; set; }
        public MostrarRegiones(IRepositorio<Region> repositorioRegion)
        {
            RepositorioRegion = repositorioRegion;
        }
        IEnumerable<Region> IMostrarRegiones.FindAll()
        {
            return RepositorioRegion.FindAll();
        }
    }
}
