using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class AltaPais : IAltaPais
    {

        public IRepositorioPais RepositorioPais { get; set; }

        public AltaPais(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        public void Add(Pais pais)
        {
            try
            {
                RepositorioPais.Add(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
