using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CSeleccion
{
    public class EditarSeleccion : IModificarSelecion
    {
        public IRepositorio<Seleccion> RepositorioSeleccion { get; set; }

        public EditarSeleccion(IRepositorio<Seleccion> repositorioSeleccion)
        {
            RepositorioSeleccion = repositorioSeleccion;
        }

        public void Update(Seleccion seleccion)
        {
            try
            {
                RepositorioSeleccion.Update(seleccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
