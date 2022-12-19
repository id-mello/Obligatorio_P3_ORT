using LogicaAplicacionUsuarios.ICUsuarios;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.CUsuarios
{
    public class UserLog : ILogin
    {
        public IRepositorioUsuarios RepositorioUsuario { get; set; }

        public UserLog(IRepositorioUsuarios repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }
        public Usuarios Login(string email, string password, int idRol)
        {
            try
            {
                return RepositorioUsuario.Login(email, password, idRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
