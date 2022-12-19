using System;
using System.Collections.Generic;
using System.Text;
using LogicaDeNegocio.EntidadesNegocio;

namespace LogicaAplicacion.ICasoDeUso.ISeleccion
{
    public interface IListaSeleccion
    {
        IEnumerable <Seleccion> FindAll();
    }
}
