using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

using Contracts;
using Contracts.Repository;
using Contracts.Repository.Exception;
using DomainModel;

namespace Repositories
{
    public class PresupuestoRepositoryImpl : AbstractRepositoryADOImpl , PresupuestoRepository
    {
        private static readonly string C_SQL_INSERT = "INSERT INTO Presupuestos(Estado , Importe , ClienteId , VehiculoId) VALUES (@Estado , @Importe , @ClienteId , @VehiculoId);SELECT @@IDENTITY AS 'Id';";
        private static readonly string C_SQL_UPDATE = "UPDATE Presupuestos SET Estado = @Estado, Importe = @Importe WHERE Id = @Id";
        private static readonly string C_SQL_DELETE = "DELETE FROM Presupuestos WHERE Id = @Id";
        private static readonly string C_SQL_FINDALL = "SELECT * FROM Presupuestos ORDER BY ClienteId, VehiculoId, Estado, Importe";
        private static readonly string C_SQL_FIND_BY_ID = "SELECT * FROM Presupuestos WHERE Id = @Id";
        private static readonly string C_SQL_SELECT_JOIN = "SELECT pre.*, cli.*, veh.* FROM Presupuestos pre INNER JOIN Clientes cli on pre.ClienteId = cli.Id INNER JOIN Vehiculos veh on pre.VehiculoId = veh.Id ";
        private static readonly string C_SQL_FINDALL_JOIN = C_SQL_SELECT_JOIN + "  ORDER BY ClienteId, VehiculoId, Estado, Importe";
        private static readonly string C_SQL_FIND_BY_ID_JOIN = C_SQL_SELECT_JOIN + "  WHERE pre.Id = @Id";
        private static readonly string C_SQL_FIND_BY_CLIENTE_JOIN = C_SQL_SELECT_JOIN + "  WHERE cli.Id = @ClienteId";

        //private UnitOfWorkADOImpl uof;
        public PresupuestoRepositoryImpl(UnitOfWork uof) : base(uof)
        {
            //this.uof = (UnitOfWorkADOImpl)uof;
        }

        protected override string CommandAdd { get { return C_SQL_INSERT; } }
        protected override string CommandDelete { get { return C_SQL_DELETE; } }
        protected override string CommandEdit { get { return C_SQL_UPDATE; } }
        protected override string CommandFindAll { get { return C_SQL_FINDALL_JOIN; } }
        protected override string CommandFindById { get { return C_SQL_FIND_BY_ID_JOIN; } }
        private string CommandFindByCliente { get { return C_SQL_FIND_BY_CLIENTE_JOIN; } }

        protected override IDictionary ComposeCommandParams(Entity entity)
        {
            IDictionary parameters = new Dictionary<string, object>();
            Presupuesto localEntity = (Presupuesto)entity;
            parameters.Add("Id", localEntity.Id);
            parameters.Add("Estado", localEntity.Estado);
            parameters.Add("Importe", localEntity.Importe);
            parameters.Add("ClienteId", localEntity.Cliente.Id);
            parameters.Add("VehiculoId", localEntity.Vehiculo.Id);
            return parameters;
        }

        protected override Entity ComposeEntity(SqlDataReader dr)
        {
            int idCliente = Int32.Parse(dr["ClienteId"].ToString());
            int idVehiculo = Int32.Parse(dr["VehiculoId"].ToString());
            Cliente cliente = new Cliente(idCliente, dr["Nombre"].ToString(), dr["Apellidos"].ToString(), dr["Telefono"].ToString(), (bool)dr["Vip"]);
            Vehiculo vehiculo = new Vehiculo(idVehiculo, dr["Marca"].ToString(), dr["Modelo"].ToString(), Int32.Parse(dr["Potencia"].ToString()));
            var estado = (Presupuesto.StatusEnum)Enum.Parse(typeof(Presupuesto.StatusEnum), dr["Estado"].ToString());
            return new Presupuesto(Int32.Parse(dr["Id"].ToString()), cliente, vehiculo, float.Parse(dr["Importe"].ToString()), estado);
        }

        public Presupuesto Add(Presupuesto entity)
        {
            return (Presupuesto)base.Add(entity);
        }

        public void Delete(Presupuesto entity)
        {
            base.Delete(entity);
        }

        public void Edit(Presupuesto entity)
        {
            base.Edit(entity);
        }

        public Presupuesto Find(Presupuesto entity)
        {
            return (Presupuesto)base.Find(entity);
        }

        public Presupuesto FindById(int id)
        {
            return (Presupuesto)base.FindById(id);
        }

        public IEnumerable<Presupuesto> FindAll()
        {
            List<Presupuesto> listAll = base.FindAll().Cast<Presupuesto>().ToList();
            return listAll;
        }

        public IEnumerable<Presupuesto> FindByCliente(Cliente cliente)
        {
            List<Presupuesto> entityList = new List<Presupuesto>();
            try
            {
                using (SqlCommand dbCommand = this.uof.CreateCommand(CommandFindByCliente))
                {
                    dbCommand.Parameters.AddWithValue("ClienteId", cliente.Id);
                    using (SqlDataReader dr = dbCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Presupuesto item = (Presupuesto)ComposeEntity(dr);
                            entityList.Add(item);
                        }
                    }
                }
                return entityList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception " + ex.Message);
                throw new EntityNotFoundRepositoryException("No se ha podido localizar las entidades en el repositorio", ex);
            }
        }
    }
}
