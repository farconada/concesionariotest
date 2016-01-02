using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repository;
using Contracts.Repository.Exception;
using Contracts.Service;
using Contracts.Service.Exception;
using DomainModel;
using Persistence;

namespace Services
{
    public class ClienteServiceImpl : ClienteService
    {
        private ConcesionarioContext ctx;
        private ClienteRepository clienterepo;

        public ClienteServiceImpl(ConcesionarioContext ctx, ClienteRepository clienterepo)
        {
            this.ctx = ctx;
            this.clienterepo = clienterepo;
        }

        public Cliente Add(Cliente entity)
        {
            if (entity.Nombre.TrimEnd().Equals("") || entity.Apellidos.TrimEnd().Equals(""))
            {
                throw new EntityInvalidDataServiceException("El nombre y los apellidos son obligatorios");
            }

            Cliente cliente = null;
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.clienterepo.Add(entity);
                        trs.Commit();
                    }
                    catch (Exception e)
                    {
                        trs.Rollback();
                        throw;
                    }
                }
            }
            return entity;
        }

        public void Edit(Cliente entity)
        {
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.clienterepo.Edit(entity);
                        trs.Commit();
                    }
                    catch (Exception e)
                    {
                        trs.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(Cliente entity)
        {
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.clienterepo.Delete(entity);
                        trs.Commit();
                    }
                    catch (Exception e)
                    {
                        trs.Rollback();
                        throw;
                    }
                }
            }
        }

        public Cliente Find(Cliente entity)
        {
            return this.clienterepo.Find(entity);
        }

        public IEnumerable<Cliente> FindAll()
        {
            return this.clienterepo.FindAll();
        }

        public Presupuesto AddPresupuesto(Cliente cliente, Presupuesto presupuesto)
        {
            presupuesto.Cliente = cliente;
            return presupuesto;
        }
    }
}
