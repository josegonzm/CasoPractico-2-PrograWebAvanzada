using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class MedicamentoBW : IMedicamentoBW
    {
        private IMedicamentoDA _MedicamentoDA;

        public MedicamentoBW(IMedicamentoDA medicamentoDA)
        {
            _MedicamentoDA = medicamentoDA;
        }

        public async Task<Guid> AgregarMedicamento(Medicamento medicamento)
        {
            return await _MedicamentoDA.AgregarMedicamento(medicamento);
        }

        public async Task<Guid> EliminarMedicamento(Guid id)
        {
            return await _MedicamentoDA.EliminarMedicamento(id);
        }

        public async Task<Guid> ModificarMedicamento(Guid id, Medicamento medicamento)
        {
            return await _MedicamentoDA.ModificarMedicamento(id, medicamento);
        }

        public async Task<IEnumerable<Medicamento>> ObtenerMedicamento()
        {
            return await _MedicamentoDA.ObtenerMedicamento();
        }

        public async Task<Medicamento> ObtenerMedicamentoPorId(Guid id)
        {
            return await _MedicamentoDA.ObtenerMedicamentoPorId(id);
        }
    }
}
