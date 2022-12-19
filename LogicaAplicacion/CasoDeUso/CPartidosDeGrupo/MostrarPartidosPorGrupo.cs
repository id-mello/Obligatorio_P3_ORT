using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarPartidosPorGrupo : IMostrarPartidosPorGrupo
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarPartidosPorGrupo(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }
        public IEnumerable<PartidoDeGrupo> FindGrupo(string grupo)
        {
            try
            {
                return RepositorioGrupo.FindGrupo(grupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
