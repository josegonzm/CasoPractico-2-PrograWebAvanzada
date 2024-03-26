using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    [Bind("Nombre, Indicaciones, Fecha_Caducidad, Efectos_Secundarios, Fabricante, Instrucciones")]
    public class Medicamento
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(35, ErrorMessage = "La longitud del nombre tiene que ser mayor a 4 y menor a 35 caracteres", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "La longitud de las indicaciones tiene que ser mayor a 20 y menor a 70 caracteres", MinimumLength = 20)]
        public string Indicaciones { get; set; }
        [Required]
        public DateTime Fecha_Caducidad { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "La longitud de los efectos secundarios tiene que ser mayor a 10 y menor a 70 caracteres", MinimumLength = 10)]
        public string Efectos_Secundarios { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "La longitud del nombre del fabricante tiene que ser mayor a 10 y menor a 20 caracteres", MinimumLength = 4)]
        public string Fabricante { get; set; }
    }
}
