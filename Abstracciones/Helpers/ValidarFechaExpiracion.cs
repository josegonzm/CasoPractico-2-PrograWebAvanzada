using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Helpers
{
    public class ValidarFechaExpiracion :  ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fechaIngresada = (DateTime)value;
                if (fechaIngresada == DateTime.Now)
                {
                    return new ValidationResult("La fecha de expiracion no puede ser igual a la fecha actual");
                }
            }
            return ValidationResult.Success;
        }
    }
}
