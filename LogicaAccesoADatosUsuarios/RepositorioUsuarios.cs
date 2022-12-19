using LogicaAccesoADatosUsuarios.BDD;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoADatosUsuarios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        public UsuariosContext Context { get; set; }

        public RepositorioUsuarios(UsuariosContext context)
        {
            Context = context;
        }

        public void Add(Usuarios usuario)
        {
            try
            {
                //usuario.SoyValido();
                Context.Usuarios.Add(usuario);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Usuarios BuscarUsuarioPorNombre (string email)
        {
            try
            {
                return Context.Usuarios.Where(usuario => usuario.Email == email).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuarios Login(string email, string password, int idRol)
        {

            try
            {   
                Roles rolBuscado = Context.Roles.Where(rol => rol.Id == idRol).First();

                Usuarios usu = Context.Usuarios.Where(usuario => usuario.Email == email && usuario.Password == password && usuario.MisRoles.Contains(rolBuscado)).First();

                return usu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void Delete(Usuarios obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuarios> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuarios FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuarios obj)
        {
            throw new NotImplementedException();
        }
    }
}
