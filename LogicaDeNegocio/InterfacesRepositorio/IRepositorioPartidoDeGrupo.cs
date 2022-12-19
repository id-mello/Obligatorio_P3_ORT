using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorioPartidoDeGrupo: IRepositorio<PartidoDeGrupo>
    {
        IEnumerable<PartidoDeGrupo> FindGrupo(string letraD);

        IEnumerable<PartidoDeGrupo> FindByPais(string nombre);

        IEnumerable<PartidoDeGrupo> FindByISO(string iso);

        IEnumerable<PartidoDeGrupo> FindByFechas(DateTime inicio, DateTime fin);
        IEnumerable<SeleccionTablaGrupo> TablaGrupo(string letra);
    }
}
