using LogicaAplicacionUsuarios.ICRoles;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.CRoles
{
    public class BuscarPorId: IFindById
    {
        public IRepositorioU<Roles> RepositorioRoles { get; set; }

        public BuscarPorId(IRepositorioU<Roles> repositorioRoles)
        {
            RepositorioRoles = repositorioRoles;
        }

        public Roles FindById(int id)
        {
            try
            {
                return RepositorioRoles.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
