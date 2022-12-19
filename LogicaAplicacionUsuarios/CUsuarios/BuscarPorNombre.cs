using LogicaAplicacionUsuarios.ICUsuarios;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacionUsuarios.CUsuarios
{
    public class BuscarPorNombre : IBuscarUsuarioPorNombre
    {

        public IRepositorioUsuarios RepositorioUsuario { get; set; }

        public BuscarPorNombre(IRepositorioUsuarios repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public Usuarios BuscarUsuarioPorNombre(string nombre)
        {
            try
            {
                return RepositorioUsuario.BuscarUsuarioPorNombre(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
