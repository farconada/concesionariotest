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
    public class PresupuestoServiceImpl : PresupuestoService
    {
        private ConcesionarioContext ctx;
        private PresupuestoRepository presurepo;

        public PresupuestoServiceImpl(ConcesionarioContext ctx, PresupuestoRepository presurepo)
        {
            this.ctx = ctx;
            this.presurepo = presurepo;
        }

        public Presupuesto Add(Presupuesto entity)
        {
            Presupuesto presu = null;
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.presurepo.Add(entity);
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
        public void Edit(Presupuesto entity)
        {
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.presurepo.Edit(entity);
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

        public void Delete(Presupuesto entity)
        {
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.presurepo.Delete(entity);
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

        

        

        public Presupuesto Find(Presupuesto entity)
        {
            return this.presurepo.Find(entity);
        }

        public IEnumerable<Presupuesto> FindAll()
        {
            return this.presurepo.FindAll();
        }

        public Presupuesto Create(Cliente cliente, Vehiculo vehiculo, float importe)
        {
            return Add(new Presupuesto(cliente, vehiculo, importe, Presupuesto.StatusEnum.Created));
        }

        public Presupuesto Edit(int id, float importe)
        {
            var presu = this.presurepo.FindById(id);
            presu.Importe = importe;
            this.presurepo.Edit(presu);
            return presu;
        }

        public IEnumerable<Presupuesto> FindByCliente(Cliente cliente)
        {
            return this.presurepo.FindByCliente(cliente);
        }

        public IEnumerable<Presupuesto> FindByVehiculo(Vehiculo vehiculo)
        {
            return this.presurepo.FindByVehiculo(vehiculo);
        }
    }
}
