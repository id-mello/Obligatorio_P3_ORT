using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CSeleccion
{
    public class EliminarSeleccion : IEliminarSeleccion
    {

        public IRepositorio<Seleccion> RepositorioSeleccion { get; set; }

        public EliminarSeleccion(IRepositorio<Seleccion> repositorioSeleccion)
        {
            RepositorioSeleccion = repositorioSeleccion;
        }

        public void Delete(Seleccion seleccion)
        {
            RepositorioSeleccion.Delete(seleccion);
        }
    }
}
