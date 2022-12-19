using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPais
{
    public interface IObtenerPorRegion
    {
        IEnumerable<Pais> ObtenerPaisesPorRegion(Region region);
    }
}
