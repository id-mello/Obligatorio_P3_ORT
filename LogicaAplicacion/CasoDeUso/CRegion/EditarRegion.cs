using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CRegion
{
    public class EditarRegion : IEditarRegion
    {
        public IRepositorio<Region> RepositorioRegion { get; set; }
        public EditarRegion(IRepositorio<Region> repositorioRegion)
        {
            RepositorioRegion = repositorioRegion;
        }
        public void Update(Region region)
        {
            try
            {
                RepositorioRegion.Update(region);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
