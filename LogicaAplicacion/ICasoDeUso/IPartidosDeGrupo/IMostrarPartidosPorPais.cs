using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo
{
    public interface IMostrarPartidosPorPais
    {
        IEnumerable<PartidoDeGrupo> FindByPais(string name);
    }
}
