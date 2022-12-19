using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class BuscarPaisPorID : IBuscarPaisPorID
    {
        public IRepositorioPais RepositorioPais { get; set; }

        public BuscarPaisPorID(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        public Pais FindByID(int id)
        {
            try
            {
                return RepositorioPais.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
