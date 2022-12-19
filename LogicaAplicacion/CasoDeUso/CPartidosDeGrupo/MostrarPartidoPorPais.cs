using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarPartidoPorPais : IMostrarPartidosPorPais
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarPartidoPorPais(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }
        public IEnumerable<PartidoDeGrupo> FindByPais(string name)
        {
            try
            {
                return RepositorioGrupo.FindByPais(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
