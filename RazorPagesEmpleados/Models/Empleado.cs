using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RazorPagesEmpleados.Models
{
    public class Empleado
    {
        public int ID { get; set; } //identificador para cada empleado

        public string Nombre { get; set; } // nombre del empleado

        public string Apellido1 { get; set; } // Primer Apellido del empleado

        public string Apellido2 { get; set; } // Segundo apellido del empleado


        [Display(Name ="Fecha de Nacimiento")]
        [DataType(DataType.Date)] //tipo de dato que utilizara la FechaNacimiento( si es de tipo date solo se vera la fecha, no la hora)
        public DateTime FechaNacimiento { get; set; } // fecha de nacimiento del empleado

        public string Email { get; set; } // Correo Electronico del empleado

        public string Telefono { get; set; } // Telefono del empleado

    }
}

