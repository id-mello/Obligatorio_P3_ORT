using LogicaAplicacionUsuarios.ICUsuarios;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.CUsuarios
{
    public class AltaUsuario : IAltaUsuario
    {

        public IRepositorioUsuarios RepositorioUsuario { get; set; }

        public AltaUsuario(IRepositorioUsuarios repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void Add(Usuarios usuario)
        {
            try
            {
                RepositorioUsuario.Add(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
