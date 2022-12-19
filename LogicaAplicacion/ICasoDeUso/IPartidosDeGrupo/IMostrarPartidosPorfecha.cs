using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo
{
    public interface IMostrarPartidosPorfecha
    {
        IEnumerable<PartidoDeGrupo> FindByFechas(DateTime inicio,DateTime fin);
    }
}
