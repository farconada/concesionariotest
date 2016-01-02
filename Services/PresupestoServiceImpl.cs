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

namespace Services
{
    public class PresupuestoServiceImpl : PresupuestoService
    {
        private UnitOfWork unitOfWork;

        public PresupuestoServiceImpl(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Presupuesto Add(Presupuesto entity)
        {
            if (entity.Cliente == null || entity.Vehiculo == null || entity.Importe <= 0)
            {
                throw new EntityInvalidDataServiceException("Los datos de cliente, vehiculo e importe son requeridos");
            }
            try
            {
                unitOfWork.StartProcess();
                Presupuesto result = unitOfWork.PresupuestoRepository.Add(entity);
                unitOfWork.ConfirmProcess();
                return result;
            }
            catch (AddEntityRepositoryException ex)
            {
                unitOfWork.RollbackProcess();
                throw ex;
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        public void Delete(Presupuesto entity)
        {
            try
            {
                unitOfWork.StartProcess();
                unitOfWork.PresupuestoRepository.Delete(entity);
                unitOfWork.ConfirmProcess();
            }
            catch (DeleteEntityRepositoryException ex)
            {
                unitOfWork.RollbackProcess();
                throw ex;
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        public void Edit(Presupuesto entity)
        {
            try
            {
                unitOfWork.StartProcess();
                unitOfWork.PresupuestoRepository.Edit(entity);
                unitOfWork.ConfirmProcess();
            }
            catch (EditEntityRepositoryException ex)
            {
                unitOfWork.RollbackProcess();
                throw ex;
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        

        public Presupuesto Find(Presupuesto entity)
        {
            try
            {
                unitOfWork.StartProcess();
                Presupuesto result = unitOfWork.PresupuestoRepository.Find(entity);
                unitOfWork.ConfirmProcess();
                return result;
            }
            catch (EntityNotFoundRepositoryException ex)
            {
                unitOfWork.RollbackProcess();
                throw ex;
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        public IEnumerable<Presupuesto> FindAll()
        {
            try
            {
                unitOfWork.StartProcess();
                IEnumerable<Presupuesto> result = unitOfWork.PresupuestoRepository.FindAll();
                unitOfWork.ConfirmProcess();
                return result;
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackProcess();
                throw new EntityNotFoundRepositoryException(ex.Message);
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        public Presupuesto Create(Cliente cliente, Vehiculo vehiculo, float importe)
        {
            return Add(new Presupuesto(cliente, vehiculo, importe, Presupuesto.StatusEnum.Created));
        }

        public Presupuesto Edit(int id, float importe)
        {
            try
            {
                unitOfWork.StartProcess();
                Presupuesto result = unitOfWork.PresupuestoRepository.FindById(id);
                result.Importe = importe;
                Edit(result);
                unitOfWork.ConfirmProcess();
                return result;
            }
            catch (EntityNotFoundRepositoryException ex)
            {
                unitOfWork.RollbackProcess();
                throw ex;
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        public IEnumerable<Presupuesto> FindByCliente(Cliente cliente)
        {
            try
            {
                unitOfWork.StartProcess();
                IEnumerable<Presupuesto> result = unitOfWork.PresupuestoRepository.FindByCliente(cliente);
                unitOfWork.ConfirmProcess();
                return result;
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackProcess();
                throw new EntityNotFoundRepositoryException(ex.Message);
            }
            finally
            {
                unitOfWork.EndProcess();
            }
        }

        public IEnumerable<Presupuesto> FindByVehiculo(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }
    }
}
