using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Helpers
{
    public class ValidarFecha : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fechaIngresada = (DateTime)value;
                if (fechaIngresada < DateTime.Now)
                {
                    return new ValidationResult("La fecha no puede ser anterior a la fecha actual.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
