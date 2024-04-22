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
    public class RecetaBW : IRecetaBW
    {
        private IRecetaDA _recetaDA;

        public RecetaBW(IRecetaDA recetaDA)
        {
            _recetaDA = recetaDA;
        }

        public async Task<Guid> AgregarReceta(Receta receta)
        {
            return await _recetaDA.AgregarReceta(receta);
        }

        public async Task<Guid> EliminarReceta(Guid id)
        {
            return await _recetaDA.EliminarReceta(id);
        }

        public async Task<Guid> ModificarEstado(Guid id, Receta receta)
        {
            return await _recetaDA.ModificarEstado(id,receta);
        }

        public async Task<Guid> ModificarReceta(Guid id, Receta receta)
        {
            return await _recetaDA.ModificarReceta(id, receta);
        }

        public async Task<IEnumerable<Receta>> ObtenerReceta()
        {
            return await _recetaDA.ObtenerReceta();
        }

        public async Task<Receta> ObtenerRecetaPorId(Guid id)
        {
            return await _recetaDA.ObtenerRecetaPorId(id);
        }

        public async Task<Receta> ObtenerCamposRecetaPorId(Guid id)
        {
            return await _recetaDA.ObtenerCamposRecetaPorId(id);
        }
    }
}
