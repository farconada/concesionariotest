using System.Collections.Generic;
using DomainModel;

namespace Contracts.Service
{
    public interface PresupuestoService : Service<Presupuesto>{
        IEnumerable<Presupuesto> FindByCliente(Cliente cliente);
        IEnumerable<Presupuesto> FindByVehiculo(Vehiculo vehiculo);
        
    }
}
