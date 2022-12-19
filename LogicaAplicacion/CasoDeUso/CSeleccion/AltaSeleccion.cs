using LogicaAplicacion.ICasoDeUso.ISeleccion;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CSeleccion
{
    public class AltaSeleccion : IAltaSeleccion
    {

        public IRepositorio<Seleccion> RepositorioSeleccion { get; set; }

        public AltaSeleccion(IRepositorio<Seleccion> repositorioSeleccion)
        {
            RepositorioSeleccion = repositorioSeleccion;
        }

        public void Add(Seleccion seleccion)
        {

            try { 

                RepositorioSeleccion.Add(seleccion);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

