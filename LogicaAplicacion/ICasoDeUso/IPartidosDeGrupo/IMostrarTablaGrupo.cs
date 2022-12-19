using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IPartidosDeGrupo
{
    public interface IMostrarTablaGrupo
    {
        IEnumerable<SeleccionTablaGrupo> FindGrupo(string grupo);
    }
}
