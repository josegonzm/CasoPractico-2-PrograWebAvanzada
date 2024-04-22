using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IRecetaDA
    {
        Task<IEnumerable<Modelos.Receta>> ObtenerReceta();

        Task<Modelos.Receta> ObtenerRecetaPorId(Guid id);

        Task<Modelos.Receta> ObtenerCamposRecetaPorId(Guid id);

        Task<Guid> EliminarReceta(Guid id);

        Task<Guid> ModificarReceta(Guid id, Modelos.Receta receta);

        Task<Guid> AgregarReceta(Modelos.Receta receta);

        Task<Guid> ModificarEstado(Guid id, Modelos.Receta receta);

    }
}
