using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using DomainModel;

namespace Persistence
{
    class ClienteRepositoryImpl : ClienteRepository
    {
        private ConcesionarioContext ctx;

        public ClienteRepositoryImpl(ConcesionarioContext ctx)
        {
            this.ctx = ctx;
        }

        public Cliente Add(Cliente entity)
        {
            this.ctx.Clientes.Add(entity);
            return entity;
        }

        public void Delete(Cliente entity)
        {
            this.ctx.Clientes.Remove(entity);
        }

        public void Edit(Cliente entity)
        {
            this.ctx.Clientes.Remove(entity);
            this.ctx.Clientes.Add(entity);
        }

        public Cliente Find(Cliente entity)
        {
            return this.FindById(entity.id);
        }

        public Cliente FindById(int id)
        {
            return this.ctx.Clientes.Find(id);
        }

        public IEnumerable<Cliente> FindAll()
        {
            return this.ctx.Clientes;
        }
    }
}
