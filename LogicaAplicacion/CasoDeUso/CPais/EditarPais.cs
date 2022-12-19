using LogicaAplicacion.ICasoDeUso.IPais;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasoDeUso.CPais
{
    public class EditarPais : IEditarPais
    {
        public IRepositorioPais RepositorioPais { get; set; }

        public EditarPais(IRepositorioPais repositorioPais)
        {
            RepositorioPais = repositorioPais;
        }

        public void Update(Pais pais)
        {
            try
            {
                RepositorioPais.Update(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
