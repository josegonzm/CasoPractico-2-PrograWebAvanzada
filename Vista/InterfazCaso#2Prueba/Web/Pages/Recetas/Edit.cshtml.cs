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

namespace Web.Pages.Recetas
{
    public class EditModel : PageModel
    {
        
        [BindProperty]
        public Receta Receta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string endpoint = "https://localhost:7179/API/Receta/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var receta = JsonConvert.DeserializeObject<Receta>(resultado);
            if (receta == null)
            {
                return NotFound();
            }
            Receta = receta;
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
            if (await RecetaExistsAsync(id))
            {
                string endpoint = "https://localhost:7179/API/Receta/{0}";
                var cliente = new HttpClient();
                var respuesta = await cliente.PutAsJsonAsync<Receta>(string.Format(endpoint, id), Receta);
                respuesta.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }

        private async Task<bool> RecetaExistsAsync(Guid id)
        {
            string endpoint = "https://localhost:7179/API/Receta/{0}";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var Receta = JsonConvert.DeserializeObject<Receta>(resultado);
            if (Receta != null)
                return true;
            return false;
        }
    }
}
