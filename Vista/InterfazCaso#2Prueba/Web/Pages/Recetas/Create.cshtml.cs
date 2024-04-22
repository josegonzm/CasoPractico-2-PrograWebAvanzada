using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abstracciones.Modelos;
using Web.Data;

namespace Web.Pages.Recetas
{
    public class CreateModel : PageModel
    {
       
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Receta Receta { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string endpoint = "https://localhost:7179/API/Receta";
            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync<Receta>(endpoint, Receta);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
