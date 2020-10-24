using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmpleados.Data;
using RazorPagesEmpleados.Models;

namespace RazorPagesEmpleados.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesEmpleados.Data.RazorPagesEmpleadosContext _context;

        public IndexModel(RazorPagesEmpleados.Data.RazorPagesEmpleadosContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Apellido1 { get; set; }

        public async Task OnGetAsync()
        {
            //La primera línea del método OnGetAsync crea una consulta LINQ para seleccionar los empleados
            var empleados = from m in _context.Empleado
                            select m;

            ////Si la propiedad SearchString no es NULL ni está vacía, 
            ////la consulta de películas se modifica para filtrar según la cadena de búsqueda:
            if (!string.IsNullOrEmpty(SearchString))
            {
   
                empleados = empleados.Where(s => s.Apellido1.Contains(SearchString));

            }

           Empleado = await empleados.ToListAsync();
            
        
        }
    }
}
