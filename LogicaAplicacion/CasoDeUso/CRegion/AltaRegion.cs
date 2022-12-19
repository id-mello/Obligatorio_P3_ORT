using LogicaAplicacion.ICasoDeUso.IRegion;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CRegion
{
    public class AltaRegion : IAltaRegion
    {
        public IRepositorio<Region> RepositorioRegion { get; set; }
        public AltaRegion(IRepositorio<Region> repositorioRegion)
        {
            RepositorioRegion = repositorioRegion;
        }

        public void Add(Region obj)
        {
            try
            {
                RepositorioRegion.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}

