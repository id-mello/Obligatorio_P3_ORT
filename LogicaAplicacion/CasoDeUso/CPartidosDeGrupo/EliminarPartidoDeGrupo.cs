using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class EliminarPartidoDeGrupo : IEliminarPartidoDeGrupo
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public EliminarPartidoDeGrupo(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }

        public void Delete(PartidoDeGrupo grupo)
        {

            try
            {
                RepositorioGrupo.Delete(grupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }
    }
}
