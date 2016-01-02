using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using DomainModel;

namespace Persistence
{
    class VehiculoRepositoryImpl : VehiculoRepository
    {
        private ConcesionarioContext ctx;

        public VehiculoRepositoryImpl(ConcesionarioContext ctx)
        {
            this.ctx = ctx;
        }

        public Vehiculo Add(Vehiculo entity)
        {
            this.ctx.Vehiculos.Add(entity);
            return entity;
        }

        public void Delete(Vehiculo entity)
        {
            this.ctx.Vehiculos.Remove(entity);
        }

        public void Edit(Vehiculo entity)
        {
            this.ctx.Vehiculos.Remove(entity);
            this.ctx.Vehiculos.Add(entity);
        }

        public Vehiculo Find(Vehiculo entity)
        {
            return this.FindById(entity.id);
        }

        public Vehiculo FindById(int id)
        {
            return this.ctx.Vehiculos.Find(id);
        }

        public IEnumerable<Vehiculo> FindAll()
        {
            return this.ctx.Vehiculos;
        }
    }
}
