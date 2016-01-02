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
    public class ClienteRepositoryImpl : AbstractRepositoryADOImpl , ClienteRepository
    {        
        private readonly string C_SQL_INSERT = "INSERT INTO Clientes(Nombre,Apellidos,Telefono,Vip) VALUES (@Nombre, @Apellidos, @Telefono , @Vip);SELECT @@IDENTITY AS 'Id';";
        private readonly string C_SQL_UPDATE = "UPDATE Clientes SET Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, Vip = @Vip WHERE Id = @Id";
        private readonly string C_SQL_DELETE = "DELETE FROM Clientes WHERE Id = @Id";
        private readonly string C_SQL_FINDALL = "SELECT * FROM Clientes ORDER BY Apellidos, Nombre";
        private readonly string C_SQL_FIND_BY_ID = "SELECT * FROM Clientes WHERE Id = @Id";

        //private UnitOfWorkADOImpl uof;

        public ClienteRepositoryImpl(UnitOfWork uof): base(uof)
        {
            //this.uof = (UnitOfWorkADOImpl)uof;
        }

        protected override string CommandAdd { get { return C_SQL_INSERT; } }
        protected override string CommandDelete { get { return C_SQL_DELETE; } }
        protected override string CommandEdit { get { return C_SQL_UPDATE; } }
        protected override string CommandFindAll { get { return C_SQL_FINDALL; } }
        protected override string CommandFindById { get { return C_SQL_FIND_BY_ID; } }

        protected override IDictionary ComposeCommandParams(Entity entity)
        {
            IDictionary parameters = new Dictionary<string,object>();
            Cliente localEntity = (Cliente)entity;
            parameters.Add("Id", localEntity.Id);
            parameters.Add("Nombre", localEntity.Nombre);
            parameters.Add("Apellidos", localEntity.Apellidos);
            parameters.Add("Telefono", localEntity.Telefono);
            parameters.Add("Vip", localEntity.Vip);
            return parameters;
        }

        protected override Entity ComposeEntity(SqlDataReader dr)
        {
            return new Cliente((int)dr["Id"], dr["Nombre"].ToString(), dr["Apellidos"].ToString(), dr["Telefono"].ToString(), (bool)dr["Vip"]);
        }

        public Cliente Add(Cliente entity)
        {
            return (Cliente)base.Add(entity);
        }

        public void Delete(Cliente entity)
        {
            base.Delete(entity);
        }

        public void Edit(Cliente entity)
        {
            base.Edit(entity);
        }

        public Cliente Find(Cliente entity)
        {
            return (Cliente)base.Find(entity);
        }

        public Cliente FindById(int id)
        {
            return (Cliente)base.FindById(id);
        }

        public IEnumerable<Cliente> FindAll()
        {
            List<Cliente> listAll = base.FindAll().Cast<Cliente>().ToList();
            return listAll;
        }

        //public Cliente Add(Cliente entity)
        //{
        //    try
        //    {
        //        using (SqlCommand dbCommand = uof.CreateCommand(CommandAdd))
        //        {
        //            IDictionary entityParams = ComposeCommandParams(entity);
        //            foreach (var key in entityParams.Keys)
        //            {
        //                dbCommand.Parameters.AddWithValue(key.ToString(), entityParams[key]);
        //            }
        //            //dbCommand.ExecuteNonQuery();
        //            entity.Id = Int32.Parse(dbCommand.ExecuteScalar().ToString());
        //            return entity;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new AddEntityRepositoryException("No se ha podido añadir la entidad al repositorio", ex);
        //    }
        //}


        //public void Delete(Cliente entity)
        //{
        //    try
        //    {
        //        using (SqlCommand dbCommand = uof.CreateCommand(CommandDelete))
        //        {
        //            dbCommand.Parameters.AddWithValue("Id", entity.Id);
        //            dbCommand.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DeleteEntityRepositoryException("No se ha podido eliminar la entidad del repositorio", ex);
        //    }
        //}

        //public void Edit(Cliente entity)
        //{
        //    try
        //    {
        //        using (SqlCommand dbCommand = uof.CreateCommand(CommandEdit))
        //        {
        //            IDictionary entityParams = ComposeCommandParams(entity);
        //            foreach (var key in entityParams.Keys)
        //            {
        //                dbCommand.Parameters.AddWithValue(key.ToString(), entityParams[key]);
        //            }
        //            dbCommand.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new AddEntityRepositoryException("No se ha podido modificar la entidad en el repositorio", ex);
        //    }
        //}

        //public Cliente Find(Cliente entity)
        //{
        //    return FindById(entity.Id);
        //}


        //public Cliente FindById(int id)
        //{
        //    Cliente entity = null;
        //    try
        //    {
        //        using (SqlCommand dbCommand = uof.CreateCommand(CommandFindById))
        //        {
        //            dbCommand.Parameters.AddWithValue("Id", id);
        //            using (SqlDataReader dr = dbCommand.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    entity = (Cliente)ComposeEntity(dr);
        //                    break;
        //                }
        //            }
        //        }
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("exception " + ex.Message);
        //        throw new EntityNotFoundRepositoryException("No se ha podido localizar la entidad en el repositorio", ex);
        //    }
        //}

        //public IEnumerable<Cliente> FindAll()
        //{
        //    List<Cliente> clienteList = new List<Cliente>();
        //    try
        //    {
        //        using (SqlCommand dbCommand = uof.CreateCommand(CommandFindAll))
        //        {
        //            using (SqlDataReader dr = dbCommand.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    Cliente entity = (Cliente)ComposeEntity(dr);
        //                    clienteList.Add(entity);
        //                }
        //            }
        //        }
        //        return clienteList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("exception " + ex.Message);
        //        throw new EntityNotFoundRepositoryException("No se ha podido localizar las entidades en el repositorio", ex);
        //    }
        //}
    }
}
