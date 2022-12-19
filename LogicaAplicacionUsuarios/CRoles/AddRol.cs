using LogicaAplicacionUsuarios.ICRoles;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.CRoles
{
    public class AddRol : IAdd
    {
        public IRepositorioU<Roles> RepositorioRoles { get; set; }

        public AddRol(IRepositorioU<Roles> repositorioRoles)
        {
            RepositorioRoles = repositorioRoles;
        }
        public void Add(Roles rol)
        {
            try
            {
                RepositorioRoles.Add(rol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
