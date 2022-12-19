using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaDeNegocio.EntidadesNegocio
{
    public class Seleccion: IValidable
    {
        public int Id { get; set; }
        public Pais Pais { get; set; }    
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public string Grupo { get; set; }

        public void SoyValido()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new SeleccionException("El nombre no puede estar vacío.");
            }

            int i = 0;
            int espacios = 0;

            while (i < Nombre.Length & espacios <= 1)
            {
                if (Nombre[i] == ' ')
                {
                    espacios++;
                }
                i++;
            }

            if (!Regex.IsMatch(Nombre, @"^[a-zA-Z]+$"))
            {
                throw new PaisException("El nombre no puede contener números.");
            }
            
            if (Telefono <= 0)
            {
                throw new SeleccionException("El teléfono debe ser un número mayor a 0.");

            }

            int digitos = (int)Math.Floor(Math.Log10(Telefono) + 1);

            if (digitos < 7)
            {
                throw new SeleccionException("El teléfono no puede contener menos de 7 digitos.");

            }

            if (CantidadApostadores <= 0)
            {
                throw new PaisException("La CantidadApostadores debe ser mayor a 0.");
            }

        }
    }
}
