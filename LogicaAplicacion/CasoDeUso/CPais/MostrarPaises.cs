using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class MostrarPaises : IMostrarPaises
    {
        public IRepositorioPais RepositorioPais { get; set; }

        public MostrarPaises(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        IEnumerable<Pais> IMostrarPaises.FindAll()
        {
            
            try
            {
                return RepositorioPais.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
