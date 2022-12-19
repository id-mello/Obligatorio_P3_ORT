using LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo;
using LogicaDeAccesoADatos.Repositorio;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPartidosDeGrupo
{
    public class MostrarPartidosDeGrupos : IMostrarPartidosDeGrupos
    {
        public IRepositorioPartidoDeGrupo RepositorioGrupo { get; set; }

        public MostrarPartidosDeGrupos(IRepositorioPartidoDeGrupo repositorioGrupo)
        {
            RepositorioGrupo = repositorioGrupo;
        }

        public IEnumerable<PartidoDeGrupo> FindAll()
        {
            return RepositorioGrupo.FindAll();
        }
    }
}
