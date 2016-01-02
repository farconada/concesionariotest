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
    public class VehiculoRepositoryImpl : AbstractRepositoryADOImpl , VehiculoRepository
    {
        private readonly string C_SQL_INSERT = "INSERT INTO Vehiculos(Marca , Modelo , Potencia) VALUES(@Marca , @Modelo , @Potencia);SELECT @@IDENTITY AS 'Id';";
        private readonly string C_SQL_UPDATE = "UPDATE Vehiculos SET Marca = @Marca, Modelo = @Modelo, Potencia = @Potencia WHERE Id = @Id";
        private readonly string C_SQL_DELETE = "DELETE FROM Vehiculos WHERE Id = @Id";
        private readonly string C_SQL_FINDALL = "SELECT * FROM Vehiculos ORDER BY Marca, Modelo, Potencia";
        private readonly string C_SQL_FIND_BY_ID = "SELECT * FROM Vehiculos WHERE Id = @Id";

        //private UnitOfWorkADOImpl uof;

        public VehiculoRepositoryImpl(UnitOfWork uof):base(uof)
        {

        }
        protected override string CommandAdd { get { return C_SQL_INSERT; } }
        protected override string CommandDelete { get { return C_SQL_DELETE; } }
        protected override string CommandEdit { get { return C_SQL_UPDATE; } }
        protected override string CommandFindAll { get { return C_SQL_FINDALL; } }
        protected override string CommandFindById { get { return C_SQL_FIND_BY_ID; } }

        protected override IDictionary ComposeCommandParams(Entity entity)
        {
            IDictionary parameters = new Dictionary<string, object>();
            Vehiculo localEntity = (Vehiculo)entity;
            parameters.Add("Id", localEntity.Id);
            parameters.Add("Marca", localEntity.Marca);
            parameters.Add("Modelo", localEntity.Modelo);
            parameters.Add("Potencia", localEntity.Potencia);
            return parameters;
        }

        protected override Entity ComposeEntity(SqlDataReader dr)
        {
            return new Vehiculo((int)dr["Id"], dr["Marca"].ToString(), dr["Modelo"].ToString(), (int)dr["Potencia"]);
        }

        public Vehiculo Add(Vehiculo entity)
        {
            return (Vehiculo)base.Add(entity);
        }

        public void Delete(Vehiculo entity)
        {
            base.Delete(entity);
        }

        public void Edit(Vehiculo entity)
        {
            base.Edit(entity);
        }

        public Vehiculo Find(Vehiculo entity)
        {
            return (Vehiculo)base.Find(entity);
        }

        public Vehiculo FindById(int id)
        {
            return (Vehiculo)base.FindById(id);
        }

        public IEnumerable<Vehiculo> FindAll()
        {
            List<Vehiculo> listAll = base.FindAll().Cast<Vehiculo>().ToList();
            return listAll;
        }        
    }
}
