using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;
using Web.Data;

namespace Web.Pages.Recetas
{
    public class DetailsModel : PageModel
    {
        private readonly Web.Data.WebContext _context;

        public DetailsModel(Web.Data.WebContext context)
        {
            _context = context;
        }

      public Receta Receta { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Receta == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta.FirstOrDefaultAsync(m => m.Id == id);
            if (receta == null)
            {
                return NotFound();
            }
            else 
            {
                Receta = receta;
            }
            return Page();
        }
    }
}
