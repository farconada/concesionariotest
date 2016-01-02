using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;

namespace Persistence
{
    public class ConcesionarioContext : DbContext, IDisposable
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}