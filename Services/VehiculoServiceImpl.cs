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
    public class VehiculoServiceImpl : VehiculoService
    {
        private ConcesionarioContext ctx;
        private VehiculoRepository vehiculorepo;

        public VehiculoServiceImpl(ConcesionarioContext ctx, VehiculoRepository vehiculorepo)
        {
            this.ctx = ctx;
            this.vehiculorepo = vehiculorepo;
        }

        public Vehiculo Add(Vehiculo entity)
        {

            Vehiculo vehiculo = null;
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.vehiculorepo.Add(entity);
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
        public void Edit(Vehiculo entity)
        {
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.vehiculorepo.Edit(entity);
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

        public void Delete(Vehiculo entity)
        {
            using (this.ctx)
            {
                using (var trs = this.ctx.Database.BeginTransaction())
                {
                    try
                    {
                        this.vehiculorepo.Delete(entity);
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

        



        public Vehiculo Find(Vehiculo entity)
        {
            return this.vehiculorepo.Find(entity);
        }

        public IEnumerable<Vehiculo> FindAll()
        {
            return this.vehiculorepo.FindAll();
        }
    }
}
