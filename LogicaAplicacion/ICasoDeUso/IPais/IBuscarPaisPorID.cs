using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPais
{
    public interface IBuscarPaisPorID
    {
        Pais FindByID(int id);

    }
}
