using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo
{
    public interface IMostrarPartidosPorGrupo
    {
        IEnumerable<PartidoDeGrupo> FindGrupo(string grupo);
    }
}
