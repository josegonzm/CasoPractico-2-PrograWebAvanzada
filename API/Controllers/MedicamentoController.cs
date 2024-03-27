using Abstracciones.API;
using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class MedicamentoController : Controller, IMedicamentoController
    {

        private IMedicamentoBW _medicamentoBW;
        private readonly ILogger<MedicamentoController> _logger;

        public MedicamentoController(IMedicamentoBW medicamentoBW, ILogger<MedicamentoController> logger)
        {
            _medicamentoBW = medicamentoBW;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                _logger.LogInformation("Consultando medicamentos");
                return Ok(await _medicamentoBW.ObtenerMedicamento());
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar los medicamentos");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Consultando medicamento");
                return Ok(await _medicamentoBW.ObtenerMedicamentoPorId(id));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar los medicamentos");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Eliminando medicamento");
                return Ok(await _medicamentoBW.EliminarMedicamento(id));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al eliminar el medicamento");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Medicamento medicamento)
        {
            try
            {
                _logger.LogInformation("Agregando medicamento");
                var id = await _medicamentoBW.AgregarMedicamento(medicamento);
                medicamento.Id = id;
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, medicamento);
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al agregar un medicamento");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Medicamento medicamento)
        {
            try
            {
                _logger.LogInformation("Editando medicamento");
                return Ok(await _medicamentoBW.ModificarMedicamento(id, medicamento));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al modificar un medicamento");
            }
        }

        private IActionResult GenerarError(Exception ex, string mensaje)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { Idcorrelacion = Guid.NewGuid(), Detalle = "Error consultando los medicamentos" });
        }

    }
}
