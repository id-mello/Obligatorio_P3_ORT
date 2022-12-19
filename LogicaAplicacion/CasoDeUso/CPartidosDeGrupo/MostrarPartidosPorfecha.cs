using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarPartidosPorfecha : IMostrarPartidosPorfecha
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarPartidosPorfecha(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }
        public IEnumerable<PartidoDeGrupo> FindByFechas(DateTime inicio, DateTime fin)
        {
            try
            {
                return RepositorioGrupo.FindByFechas(inicio,fin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
