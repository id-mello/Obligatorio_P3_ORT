using LogicaDeNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeAccesoADatos.BDD;
using System.Linq;

namespace LogicaDeAccesoADatos.Repositorio
{
    public class RepositorioRegion : IRepositorio<Region>
    {

        public MundialContext Context { get; set; }

        public RepositorioRegion(MundialContext context)
        {
            Context = context;
        }

        public void Add(Region obj)
        {
            try
            {
                Context.Regiones.Add(obj);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Region obj)
        {
            Context.Regiones.Remove(obj);
            Context.SaveChanges();
        }

        public IEnumerable<Region> FindAll()
        {
            return Context.Regiones.ToList();
        }

        public Region FindById(int id)
        {
            try
            {
                return Context.Regiones.Where(region => region.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Region obj)
        {
            
            Context.Regiones.Update(obj);
            Context.SaveChanges();
        }
    }
}
