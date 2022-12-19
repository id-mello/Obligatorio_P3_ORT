using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class EliminarPais : IEliminarPais
    {

        public IRepositorioPais RepositorioPais { get; set; }

        public EliminarPais(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        public void Delete(Pais pais)
        { 
            try
            {
                RepositorioPais.Delete(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
