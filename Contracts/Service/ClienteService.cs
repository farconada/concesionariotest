using DomainModel;

namespace Contracts.Service
{
    public interface ClienteService : Service<Cliente>
    {
        Presupuesto AddPresupuesto(Cliente cliente, Presupuesto presupuesto);
    }
}
