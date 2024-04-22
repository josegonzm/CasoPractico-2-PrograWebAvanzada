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

namespace Web.Pages.Recetas
{
    public class IndexModel : PageModel
    {

        public IList<Receta> Receta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            string endpoint = "https://localhost:7179/API/Receta";
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            Receta = JsonConvert.DeserializeObject<List<Receta>>(resultado);
        }
    }
}
