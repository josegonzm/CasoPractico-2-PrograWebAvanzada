using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Web.Data;
using Newtonsoft.Json;

namespace Web.Pages.Medicamentos
{
    public class EditModel : PageModel
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
            Medicamento = medicamento;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var id = Guid.Parse(HttpContext.Request.Query["id"]);
            if (await MedicamentoExistsAsync(id))
            {
                string endpoint = "https://localhost:7179/API/Medicamento/{0}";
                var cliente = new HttpClient();
                var respuesta = await cliente.PutAsJsonAsync<Medicamento>(string.Format(endpoint, id), Medicamento);
                respuesta.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }
    

        private async Task<bool> MedicamentoExistsAsync(Guid id)
        {
            string endpoint = "https://localhost:7179/API/Medicamento/{0}";
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
