using LogicaAccesoADatosUsuarios.BDD;
using LogicaDeNegocioUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoADatosUsuarios
{
    public class RepositorioRoles : IRepositorioU<Roles>
    {
        public UsuariosContext Context { get; set; }

        public RepositorioRoles(UsuariosContext context)
        {
            Context = context;
        }

        public void Add(Roles rol)
        {
            try
            {
                
                Context.Roles.Add(rol);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Roles obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roles> FindAll()
        {
            try
            {
                return Context.Roles.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Roles FindById(int id)
        {
            try
            {
                return Context.Roles.Where(Roles => Roles.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Roles obj)
        {
            throw new NotImplementedException();
        }
    }
}
