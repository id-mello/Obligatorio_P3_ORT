using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarTablaGrupo : IMostrarTablaGrupo
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarTablaGrupo(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }
        public IEnumerable<SeleccionTablaGrupo> FindGrupo(string grupo)
        {
            return RepositorioGrupo.TablaGrupo(grupo);
        }
    }
}
