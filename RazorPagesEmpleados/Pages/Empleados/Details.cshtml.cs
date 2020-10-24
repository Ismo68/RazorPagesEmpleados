using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmpleados.Data;
using RazorPagesEmpleados.Models;

namespace RazorPagesEmpleados.Pages.Empleados
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesEmpleados.Data.RazorPagesEmpleadosContext _context;

        public DetailsModel(RazorPagesEmpleados.Data.RazorPagesEmpleadosContext context)
        {
            _context = context;
        }

        public Empleado Empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado = await _context.Empleado.FirstOrDefaultAsync(m => m.ID == id);

            if (Empleado == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
