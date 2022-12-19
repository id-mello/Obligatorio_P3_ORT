using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CRegion
{
    public class MostrarRegion : IMostrarRegion
    {
        public IRepositorio<Region> RepositorioRegion { get; set; }

        public MostrarRegion(IRepositorio<Region> repositorioRegion)
        {
            RepositorioRegion = repositorioRegion;
        }
        public Region FindById(int id)
        {
            //Region region = new Region();
            return RepositorioRegion.FindById(id);
        }
    }
}
