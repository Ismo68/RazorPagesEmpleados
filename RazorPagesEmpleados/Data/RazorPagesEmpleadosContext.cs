using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesEmpleados.Models;

namespace RazorPagesEmpleados.Data
{
    public class RazorPagesEmpleadosContext : DbContext
    {
        public RazorPagesEmpleadosContext (DbContextOptions<RazorPagesEmpleadosContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesEmpleados.Models.Empleado> Empleado { get; set; }
    }
}
