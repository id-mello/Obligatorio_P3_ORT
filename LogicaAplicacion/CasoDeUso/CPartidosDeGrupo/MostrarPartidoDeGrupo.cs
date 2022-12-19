using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarPartidoDeGrupo : IMostrarPartidoDeGrupo
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarPartidoDeGrupo(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }

        public PartidoDeGrupo FindByID(int id)
        {
            try
            {
              return  RepositorioGrupo.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
