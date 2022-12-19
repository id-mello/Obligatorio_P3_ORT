using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CSelecion
{
    public class ListaSeleccion : IListaSeleccion
    {
        public IRepositorio<Seleccion> RepositorioSeleccion { get; set; }

        public ListaSeleccion(IRepositorio<Seleccion> repositorioSeleccion)
        {
            RepositorioSeleccion = repositorioSeleccion;
        }

        IEnumerable<Seleccion> IListaSeleccion.FindAll()
        {
            return RepositorioSeleccion.FindAll();
        }
    }
}

