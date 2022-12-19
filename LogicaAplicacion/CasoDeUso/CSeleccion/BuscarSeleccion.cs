using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaDeNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasoDeUso.CSeleccion

{
    public class BuscarSeleccion : IBuscarSeleccionId
    {
        public IRepositorio<Seleccion> RepositorioSeleccion { get; set; }

        public BuscarSeleccion(IRepositorio<Seleccion> repositorioseleccion)
        {
            RepositorioSeleccion = repositorioseleccion;
        }

        public Seleccion FindByID(int id)
        {
            try
            {
                return RepositorioSeleccion.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
