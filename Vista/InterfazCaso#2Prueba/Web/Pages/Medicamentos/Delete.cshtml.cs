using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Web.Data;
using Newtonsoft.Json;

namespace Web.Pages.Medicamentos
{
    public class DeleteModel : PageModel
    {

      [BindProperty]
      public Medicamento Medicamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7179/API/Medicamento/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var medicamento = JsonConvert.DeserializeObject<Medicamento>(resultado);

            if (medicamento == null)
            {
                return NotFound();
            }
            else 
            {
                Medicamento = medicamento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string endpoint = "https://localhost:7179/API/Medicamento/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            

            return RedirectToPage("./Index");
        }

        private async Task<bool> MedicamentoExistsAsync(Guid id)
        {
            string endpoint = "https://localhost:7229/API/Medicamento/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var medicamento = JsonConvert.DeserializeObject<Medicamento>(resultado);
            if (medicamento != null)
                return true;
            return false;
        }
    }
}
