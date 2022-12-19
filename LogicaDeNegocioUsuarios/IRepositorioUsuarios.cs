using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocioUsuarios
{
    public interface IRepositorioUsuarios : IRepositorioU<Usuarios>
    {
        public Usuarios BuscarUsuarioPorNombre(string email);
        public Usuarios Login(string email, string password, int idRol);
    }
}
