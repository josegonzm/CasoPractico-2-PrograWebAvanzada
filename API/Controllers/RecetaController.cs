using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class RecetaController : Controller, IRecetaController
    {
        private IRecetaBW _recetaBW;
        private ILogger<RecetaController> _logger;

        public RecetaController(IRecetaBW recetaBW, ILogger<RecetaController> logger)
        {
            _recetaBW = recetaBW;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            try
            {
                _logger.LogInformation("Eliminando receta");
                return Ok(await _recetaBW.EliminarReceta(id));
            } catch (Exception ex)
            {
                return GenerarError(ex, "Error al eliminar receta");
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                _logger.LogInformation("Consultando recetas");
                return Ok(await _recetaBW.ObtenerReceta());
            } catch (Exception ex)
            {
                return GenerarError(ex, "Error al consultar recetas");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Obteniendo receta por id");
                return Ok(await _recetaBW.ObtenerRecetaPorId(id));
            } catch (Exception ex)
            {
                return GenerarError(ex, "Error consultando receta por id");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Receta receta)
        {
            try
            {
                _logger.LogInformation("Agregando receta");
                var id = await _recetaBW.AgregarReceta(receta);
                receta.Id = id;
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, receta);
            } catch (Exception ex)
            {
                return GenerarError(ex, "Error al agregar receta");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromQuery] Guid id, [FromBody] Receta receta)
        {
            try
            {
                _logger.LogInformation("Actualizando receta");
                return Ok(await _recetaBW.ModificarReceta(id, receta));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, "Error al actualizar receta");
            }
        }
        [HttpPut("Estado")]
        public async Task<IActionResult> PutEstadoAsync([FromQuery] Guid id, [FromBody] Receta receta)
        {
            try
            {
                _logger.LogInformation("Actualizando receta");
                return Ok(await _recetaBW.ModificarEstado(id, receta)); 
            }
            catch (Exception ex)
            {
                return GenerarError(ex, "Error al actualizar receta");
            }
        }

        private IActionResult GenerarError(Exception ex, string mensaje)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { Idcorrelacion = Guid.NewGuid(), Detalle = "Error consultando los medicamentos" });
        }
    }
}
