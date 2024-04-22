using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Receta
    {
        public Guid Id { get; set; }
        public Guid Paciente { get; set; }
        public Guid Medico { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Medicamento { get; set; }
        public string Instrucciones { get; set; }
        public DateTime Expira { get; set; }
        public string Comentarios { get; set; }

        public string Estado { get; set; }
    }
}
