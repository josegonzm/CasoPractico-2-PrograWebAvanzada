using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Medicamento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Indicaciones { get; set; }
        public DateTime Fecha_Caducidad { get; set; }
        public string Efectos_Secundarios { get; set; }
        public string Fabricante { get; set; }
    }
}
