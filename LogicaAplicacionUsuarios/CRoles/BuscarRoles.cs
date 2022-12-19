using LogicaAplicacionUsuarios.ICRoles;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.CRoles
{
    public class BuscarRoles : IFindAll
    {
        public IRepositorioU<Roles> RepositorioRoles { get; set; }

        public BuscarRoles(IRepositorioU<Roles> repositorioRoles)
        {
            RepositorioRoles = repositorioRoles;
        }

        public IEnumerable<Roles> FindAll()
        {
            try
            {
                return RepositorioRoles.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
