﻿using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasoDeUso.IRegion
{
    public interface IMostrarRegiones
    {
        IEnumerable<Region> FindAll();
    }
}
