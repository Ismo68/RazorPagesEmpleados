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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesEmpleados.Data.RazorPagesEmpleadosContext _context;

        public DeleteModel(RazorPagesEmpleados.Data.RazorPagesEmpleadosContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado = await _context.Empleado.FindAsync(id);

            if (Empleado != null)
            {
                _context.Empleado.Remove(Empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
