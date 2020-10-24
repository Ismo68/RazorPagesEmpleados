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
    public class EditModel : PageModel
    {
        private readonly RazorPagesEmpleados.Data.RazorPagesEmpleadosContext _context;

        public EditModel(RazorPagesEmpleados.Data.RazorPagesEmpleadosContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.ID == id);
        }
    }
}
