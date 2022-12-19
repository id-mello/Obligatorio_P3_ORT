using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CRegion
{
    public class EliminarRegion : IEliminarRegion
    {
        public IRepositorio<Region> RepositorioRegion { get; set; }
        public EliminarRegion(IRepositorio<Region> repositorioRegion)
        {
            RepositorioRegion = repositorioRegion;
        }
        public void Delete(Region region)
        {
            try
            {
                RepositorioRegion.Delete(region);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
