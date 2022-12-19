using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogicaDeNegocioUsuarios
{
    public class Usuarios
    {


        public int Id { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "El formato de email no es valido.")]
        [Required(ErrorMessage = "El email es obligatorio y único.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
         ErrorMessage = "El password debe contener al menos una minúscula,una mayúscula, un dígito y un punto")]
        public string Password { get; set; }

        public List<Roles> MisRoles { get; set; }

 
    }
}
