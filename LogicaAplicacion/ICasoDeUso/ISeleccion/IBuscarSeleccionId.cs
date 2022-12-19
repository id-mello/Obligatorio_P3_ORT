using System;
using System.Collections.Generic;
using System.Text;
using LogicaDeNegocio.EntidadesNegocio;



namespace LogicaAplicacion.ICasoDeUso.ISeleccion
{
    public interface IBuscarSeleccionId
    {
        Seleccion FindByID (int id);

    }
}