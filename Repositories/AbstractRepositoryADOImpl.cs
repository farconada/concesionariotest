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
    public abstract class AbstractRepositoryADOImpl : Repository<Entity>
    {
        
        protected UnitOfWorkADOImpl uof;

        protected AbstractRepositoryADOImpl(UnitOfWork uof)
        {
            this.uof = (UnitOfWorkADOImpl)uof;
        }

        protected abstract string CommandAdd { get; }
        protected abstract string CommandDelete { get; }
        protected abstract string CommandEdit { get; }
        protected abstract string CommandFindAll { get; }
        protected abstract string CommandFindById { get; }
        protected abstract IDictionary ComposeCommandParams(Entity entity);
        protected abstract Entity ComposeEntity(SqlDataReader dr);



        public Entity Add(Entity entity)
        {
            try
            {
                using (SqlCommand dbCommand = uof.CreateCommand(CommandAdd))
                {
                    IDictionary entityParams = ComposeCommandParams(entity);
                    foreach (var key in entityParams.Keys)
                    {
                        dbCommand.Parameters.AddWithValue(key.ToString(), entityParams[key]);    
                    }
                    //dbCommand.ExecuteNonQuery();
                    entity.Id = Int32.Parse(dbCommand.ExecuteScalar().ToString());
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new AddEntityRepositoryException("No se ha podido añadir la entidad al repositorio", ex);
            }
        }


        public void Delete(Entity entity)
        {
            try
            {
                using (SqlCommand dbCommand = uof.CreateCommand(CommandDelete))
                {
                    if (!dbCommand.Parameters.Contains(Entity.PropertyEnum.Id.ToString()))
                    {
                        dbCommand.Parameters.AddWithValue(Entity.PropertyEnum.Id.ToString(), entity.Id);
                    }
                    dbCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new DeleteEntityRepositoryException("No se ha podido eliminar la entidad del repositorio", ex);
            }
        }

        public void Edit(Entity entity)
        {
            try
            {
                using (SqlCommand dbCommand = uof.CreateCommand(CommandEdit))
                {
                    IDictionary entityParams = ComposeCommandParams(entity);
                    entityParams[Entity.PropertyEnum.Id.ToString()] = entity.Id;
                    foreach (var key in entityParams.Keys)
                    {
                        dbCommand.Parameters.AddWithValue(key.ToString(), entityParams[key]);
                    }
                    dbCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new AddEntityRepositoryException("No se ha podido modificar la entidad en el repositorio", ex);
            }
        }

        public Entity Find(Entity entity)
        {
            return FindById(entity.Id);
        }

        public Entity FindById(int id)
        {
            Entity entity = null;
            try
            {
                using (SqlCommand dbCommand = uof.CreateCommand(CommandFindById))
                {
                    dbCommand.Parameters.AddWithValue(Entity.PropertyEnum.Id.ToString(), id);
                    using (SqlDataReader dr = dbCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            
                            entity = ComposeEntity(dr);
                            break;
                        }
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception " + ex.Message);
                throw new EntityNotFoundRepositoryException("No se ha podido localizar la entidad en el repositorio", ex);
            }
        }

        public IEnumerable<Entity> FindAll()
        {
            List<Entity> entityList = new List<Entity>();
            try
            {
                using (SqlCommand dbCommand = uof.CreateCommand(CommandFindAll))
                {
                    using (SqlDataReader dr = dbCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Entity item = ComposeEntity(dr);
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
