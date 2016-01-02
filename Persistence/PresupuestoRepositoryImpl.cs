using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using DomainModel;

namespace Persistence
{
    class PresupuestoRepositoryImpl : PresupuestoRepository
    {
        private ConcesionarioContext ctx;

        public PresupuestoRepositoryImpl(ConcesionarioContext ctx)
        {
            this.ctx = ctx;
        }

        public Presupuesto Add(Presupuesto entity)
        {
            this.ctx.Presupuestos.Add(entity);
            return entity;
        }

        public void Delete(Presupuesto entity)
        {
            this.ctx.Presupuestos.Remove(entity);
        }

        public void Edit(Presupuesto entity)
        {
            this.ctx.Presupuestos.Remove(entity);
            this.ctx.Presupuestos.Add(entity);
        }

        public Presupuesto Find(Presupuesto entity)
        {
            return this.FindById(entity.id);
        }

        public Presupuesto FindById(int id)
        {
            return this.ctx.Presupuestos.Find(id);
        }

        public IEnumerable<Presupuesto> FindAll()
        {
            return this.ctx.Presupuestos;
        }

        public IEnumerable<Presupuesto> FindByCliente(Cliente cliente)
        {
            return this.ctx.Presupuestos.Where(p => p.Cliente == cliente);
        }

        public IEnumerable<Presupuesto> FindByVehiculo(Vehiculo vehiculo)
        {
            return this.ctx.Presupuestos.Where(p => p.Vehiculo == vehiculo);
        }
    }
}
