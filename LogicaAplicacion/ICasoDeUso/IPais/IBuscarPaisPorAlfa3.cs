using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPais
{
    public interface IBuscarPaisPorAlfa3
    {

        Pais BuscarPaisPorAlfa3(string codAlfa3);

    }
}
