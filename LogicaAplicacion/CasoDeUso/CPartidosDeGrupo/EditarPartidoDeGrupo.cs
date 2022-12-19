using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class EditarPartidoDeGrupo : IEditarPartidoDeGrupo
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public EditarPartidoDeGrupo(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }

        public void Update(PartidoDeGrupo grupo)
        {
            try
            {
                RepositorioGrupo.Update(grupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
