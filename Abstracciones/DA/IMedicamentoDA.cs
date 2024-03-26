using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IMedicamentoDA
    {
        Task<IEnumerable<Modelos.Medicamento>> ObtenerMedicamento();

        Task<Modelos.Medicamento> ObtenerMedicamentoPorId(Guid id);

        Task<Guid> EliminarMedicamento(Guid id);

        Task<Guid> ModificarMedicamento(Guid id, Modelos.Medicamento medicamento);

        Task<Guid> AgregarMedicamento(Modelos.Medicamento medicamento);
    }
}
