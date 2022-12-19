using LogicaDeAccesoADatos.BDD;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaDeAccesoADatos.Repositorio
{
    public class RepositorioPais : IRepositorioPais
    {

        public MundialContext Context { get; set; }

        public RepositorioPais(MundialContext context)
        {
            Context = context;
        }

        public void Add(Pais pais)
        {
            try
            {
                pais.SoyValido();
                Context.Paises.Add(pais);
                Context.SaveChanges();
            }
            catch (PaisException ex)
            {
                throw new PaisException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pais BuscarPaisPorAlfa3(string codAlfa3)
        {
            try
            {
                return Context.Paises.Where(pais => pais.IsoAlfa3 == codAlfa3).Include(a => a.Region).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Pais pais)
        {
            Context.Paises.Remove(pais);
            Context.SaveChanges();
        }

        public IEnumerable<Pais> FindAll()
        {
            return Context.Paises.Include(a => a.Region);
        }

        public Pais FindById(int id)
        {
            try
            {
                return Context.Paises.Where(pais => pais.Id == id).Include(a => a.Region).First(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Pais> ObtenerPaisesPorRegion(Region region)
        {
            try
            {
                return Context.Paises.Where(pais => pais.Region == region).Include(a => a.Region);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Pais pais)
        {
            pais.SoyValido();
            Context.Paises.Update(pais);
            Context.SaveChanges();
        }
    }
}
