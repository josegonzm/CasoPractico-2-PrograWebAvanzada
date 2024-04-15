using Abstracciones.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Receta
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Paciente { get; set; }
        [Required]
        public string Medico { get; set; }
        [Required]
        [ValidarFecha]
        public DateTime FechaEmision { get; set; }
        [Required]
        public string Medicamento { get; set; }
        [Required]
        public string Instrucciones { get; set; }
        [Required]
        [ValidarFechaExpiracion]
        public DateTime Expira { get; set; }
        [Required]
        public string Comentarios { get; set; }
    }
}
