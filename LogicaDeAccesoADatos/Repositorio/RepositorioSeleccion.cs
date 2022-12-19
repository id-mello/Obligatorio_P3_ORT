using LogicaDeAccesoADatos.BDD;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaDeAccesoADatos.Repositorio
{
    public class RepositorioSeleccion : IRepositorio<Seleccion>
    {
        public MundialContext Context { get; set; }

        public RepositorioSeleccion(MundialContext context)
        {
            Context = context;
        }

        public void Add(Seleccion obj)
        {
            try
            {
                Context.Selecciones.Add(obj);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Seleccion obj)
        {
            Context.Selecciones.Remove(obj);
            Context.SaveChanges();
        }

        public IEnumerable<Seleccion> FindAll()
        {
            return Context.Selecciones.Include(a => a.Pais);
        }

        public Seleccion FindById(int id)
        {
            try
            {
                return Context.Selecciones.Where(seleccion => seleccion.Id == id).Include(a => a.Pais).ThenInclude(a => a.Region).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Seleccion obj)
        {
            Context.Selecciones.Update(obj);
            Context.SaveChanges();
        }
    }
}
