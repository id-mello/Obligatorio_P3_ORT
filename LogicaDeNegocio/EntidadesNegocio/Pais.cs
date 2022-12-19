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
    public class Pais: IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string IsoAlfa3 { get; set; }
        public double PbiPerCapita { get; set; }
        public int Poblacion { get; set; }
        public string Imagen { get; set; }
        public Region Region { get; set; }
        public int IdRegion {  get; set; }

        public void SoyValido()
        {

            #region Validación nombre
            
                if (String.IsNullOrEmpty(Nombre))
                {
                    throw new PaisException("El nombre no puede estar vacío.");
                }

                if (Nombre.Length > 50)
                {
                    throw new PaisException("El nombre puede contener hasta 50 caracteres.");
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

                if (espacios > 1)
                {
                    throw new PaisException("El nombre no puede tener más de un espacio.");
                }

                if (!Regex.IsMatch(Nombre, @"^[a-zA-Z]+$"))
                {
                    throw new PaisException("El nombre no puede contener números.");
                }

            #endregion

            #region Validación ISO

                if (String.IsNullOrEmpty(IsoAlfa3))
                {
                    throw new PaisException("El código IsoAlfa3 no puede estar vacío.");
                }


                if (IsoAlfa3.Length != 3)
                {
                    throw new PaisException("El código IsoAlfa3 debe contener 3 caracteres");
                }

                bool esIgual = false;
                string isoMayus = IsoAlfa3.ToUpper();
                string nombreMayus = Nombre.ToUpper();

                if (nombreMayus[0] == isoMayus[0])
                {
                    esIgual = true;
                }

                if (!esIgual)
                {
                    throw new PaisException("La primer letra del código IsoAlfa3 debe coincidir con la primer letra del nombre del País.");
                }


            #endregion

            #region Validación de positivos, bandera y región 

                if (PbiPerCapita <= 0)
                {
                    throw new PaisException("El PbiPerCapita debe ser mayor a 0.");
                }

                if (Poblacion <= 0)
                {
                    throw new PaisException("La Poblacion debe ser mayor a 0.");
                }

                if (String.IsNullOrEmpty(Imagen))
                {
                    throw new PaisException("Debe cargar una imagen de la bandera del país.");
                }

                if (Region is null)
                {
                    throw new PaisException("Debe seleccionar una región.");
                }

            #endregion

        }
    }
}
