using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class BuscarPaisPorAlfa3 : IBuscarPaisPorAlfa3
    {
        public IRepositorioPais RepositorioPais { get; set; }

        public BuscarPaisPorAlfa3(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        Pais IBuscarPaisPorAlfa3.BuscarPaisPorAlfa3(string codAlfa3)
        {
            try
            {
               return RepositorioPais.BuscarPaisPorAlfa3(codAlfa3);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
