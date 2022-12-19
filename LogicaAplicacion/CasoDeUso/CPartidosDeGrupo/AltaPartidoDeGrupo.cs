using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class AltaPartidoDeGrupo : IAltaPartidoDeGrupo
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public AltaPartidoDeGrupo(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }

        public void Add(PartidoDeGrupo grupo)
        {
            try
            {
                RepositorioGrupo.Add(grupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
