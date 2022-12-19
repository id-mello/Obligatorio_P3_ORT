using LogicaDeAccesoADatos.BDD;
using LogicaDeNegocio.EntidadesNegocio;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaDeAccesoADatos.Repositorio
{
    public class RepositorioPartidoDeGrupo : IRepositorioPartidoDeGrupo
    {
        public MundialContext Context { get; set; }

        public RepositorioPartidoDeGrupo(MundialContext context)
        {
            Context = context;
        }
        public void Add(PartidoDeGrupo grupo)
        {
            try
            {
                Context.Grupos.Add(grupo);
                Context.SaveChanges();
            }
            //catch (GrupoException ex)
            //{
            //    throw new GrupoException(ex.Message);
            //}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(PartidoDeGrupo grupo)
        {
            Context.Grupos.Remove(grupo);
            Context.SaveChanges();
        }

        public IEnumerable<PartidoDeGrupo> FindAll()
        {
            return Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais).Include(i=> i.Incidencias);
        }

        public PartidoDeGrupo FindById(int id)
        {
            try
            {
                return (PartidoDeGrupo)Context.Grupos.Where(grupo => grupo.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(PartidoDeGrupo grupo)
        {

            Context.Grupos.Update(grupo);
            Context.SaveChanges();
        }


        public IEnumerable<PartidoDeGrupo> FindGrupo(string letra)
        {
            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
            foreach (PartidoDeGrupo p in Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais))
            {
                Seleccion s = p.Seleccion[0];
                if(s.Grupo == letra) {partidos.Add(p); }
            }
            return partidos;
        }

        public IEnumerable<PartidoDeGrupo> FindByPais(string nombre)
        {
            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
            foreach (PartidoDeGrupo p in Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais))
            {
                Seleccion s = p.Seleccion[0];
                Seleccion s2 = p.Seleccion[1];
                if (s.Pais.Nombre == nombre || s2.Pais.Nombre == nombre) { partidos.Add(p); }
            }
            return partidos;
        }

        public IEnumerable<PartidoDeGrupo> FindByISO(string iso)
        {
            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
            foreach (PartidoDeGrupo p in Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais))
            {
                Seleccion s = p.Seleccion[0];
                Seleccion s2 = p.Seleccion[1];
                if (s.Pais.IsoAlfa3 == iso || s2.Pais.IsoAlfa3 == iso) { partidos.Add(p); }
            }
            return partidos;
        }

        public IEnumerable<PartidoDeGrupo> FindByFechas(DateTime inicio, DateTime fin)
        {
            
            List<PartidoDeGrupo> partidos = new List<PartidoDeGrupo>();
            foreach (PartidoDeGrupo p in Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais))
            {
                if(p.FechaHora >= inicio && p.FechaHora <= fin) { partidos.Add(p); }
            }
            return partidos;
        }

        public IEnumerable<SeleccionTablaGrupo> TablaGrupo(string letra)
        {
            SeleccionTablaGrupo s1 = new SeleccionTablaGrupo();
            SeleccionTablaGrupo s2 = new SeleccionTablaGrupo();
            SeleccionTablaGrupo s3 = new SeleccionTablaGrupo();
            SeleccionTablaGrupo s4 = new SeleccionTablaGrupo();
            s1.Id = -1; s1.Puntos = 0; s1.GolesC = 0; s1.GolesA = 0;
            s2.Id = -1; s2.Puntos = 0; s2.GolesC = 0; s2.GolesA = 0;
            s3.Id = -1; s3.Puntos = 0; s3.GolesC = 0; s3.GolesA = 0;
            s4.Id = -1; s4.Puntos = 0; s4.GolesC = 0; s4.GolesA = 0;
            List<SeleccionTablaGrupo> selecciones = new List<SeleccionTablaGrupo>();
            foreach (PartidoDeGrupo item in Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais))
            {
                foreach (Seleccion s in item.Seleccion)
                {
                    if (s.Grupo == letra)
                    {
                        int idseleccion = s.Id;
                        if (s1.Id == -1 && s2.Id == -1 && s3.Id == -1 && s4.Id == -1)
                        {
                            s1.Id = idseleccion;
                            s1.NamePais = s.Pais.Nombre;
                            s1.Bandera = s.Pais.Imagen;
                        }
                        else if (s2.Id == -1 && s3.Id == -1 && s4.Id == -1)
                        {
                            s2.Id = idseleccion;
                            s2.NamePais = s.Pais.Nombre;
                            s2.Bandera = s.Pais.Imagen;
                        }
                        else if (s3.Id == -1 && s4.Id == -1)
                        {
                            s3.Id = idseleccion;
                            s3.NamePais = s.Pais.Nombre;
                            s3.Bandera = s.Pais.Imagen;
                        }
                        else if (s4.Id == -1)
                        {
                            s4.Id = idseleccion;
                            s4.NamePais = s.Pais.Nombre;
                            s4.Bandera = s.Pais.Imagen;
                        }
                    }
                }
            }


            foreach (PartidoDeGrupo p in Context.Grupos.Include(a => a.Seleccion).ThenInclude(a => a.Pais).Include(i => i.Incidencias))
            {
                if (p.Nombre == letra)
                {
                    foreach (IncidenciasPartido ip in p.Incidencias)
                    {

                        if (ip.SeleccionId == s1.Id)
                        {
                            if (ip.TipoIncidencia == "Victoria")
                            {
                                s1.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "Empate")
                            {
                                s1.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesAFavor")
                            {
                                s1.GolesA += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesEnContra")
                            {
                                s1.GolesC += ip.Valor;
                            }
                        }

                        if (ip.SeleccionId == s2.Id)
                        {
                            if (ip.TipoIncidencia == "Victoria")
                            {
                                s2.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "Empate")
                            {
                                s2.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesAFavor")
                            {
                                s2.GolesA += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesEnContra")
                            {
                                s2.GolesC += ip.Valor;
                            }
                        }

                        if (ip.SeleccionId == s3.Id)
                        {
                            if (ip.TipoIncidencia == "Victoria")
                            {
                                s3.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "Empate")
                            {
                                s3.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesAFavor")
                            {
                                s3.GolesA += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesEnContra")
                            {
                                s3.GolesC += ip.Valor;
                            }
                        }

                        if (ip.SeleccionId == s4.Id)
                        {
                            if (ip.TipoIncidencia == "Victoria")
                            {
                                s4.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "Empate")
                            {
                                s4.Puntos += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesAFavor")
                            {
                                s4.GolesA += ip.Valor;
                            }
                            if (ip.TipoIncidencia == "GolesEnContra")
                            {
                                s4.GolesC += ip.Valor;
                            }
                        }

                    }
                }
            }
            if (s1.Id > -1) { selecciones.Add(s1); }
            if (s2.Id > -1) { selecciones.Add(s2); }
            if (s3.Id > -1) { selecciones.Add(s3); }
            if (s4.Id > -1)
            {
                selecciones.Add(s4);
            }
            return selecciones;
        }
    }
}
