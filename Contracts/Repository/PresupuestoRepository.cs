using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DomainModel;

namespace Contracts.Repository
{
    public interface PresupuestoRepository : Repository<Presupuesto>
    {
        IEnumerable<Presupuesto> FindByCliente(Cliente cliente);
        IEnumerable<Presupuesto> FindByVehiculo(Vehiculo vehiculo);
    }
}
