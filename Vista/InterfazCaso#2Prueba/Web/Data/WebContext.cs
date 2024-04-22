using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abstracciones.Modelos;

namespace Web.Data
{
    public class WebContext : DbContext
    {
        public WebContext (DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        public DbSet<Abstracciones.Modelos.Medicamento> Medicamento { get; set; } = default!;

        public DbSet<Abstracciones.Modelos.Receta> Receta { get; set; } = default!;
    }
}
