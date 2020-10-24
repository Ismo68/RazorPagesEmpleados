using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesEmpleados.Data;
using RazorPagesEmpleados.Models;

namespace RazorPagesEmpleados.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesEmpleados.Data.RazorPagesEmpleadosContext _context;

        public CreateModel(RazorPagesEmpleados.Data.RazorPagesEmpleadosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Empleado Empleado { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Empleado.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
