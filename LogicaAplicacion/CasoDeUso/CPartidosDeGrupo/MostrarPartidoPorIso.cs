using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarPartidoPorIso:IMostrarPartidosPorIso
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarPartidoPorIso(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }
        public IEnumerable<PartidoDeGrupo> FindByISO(string iso)
        {
            try
            {
                return RepositorioGrupo.FindByISO(iso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
