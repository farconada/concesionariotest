using System;
using System.Data;
using System.Data.SqlClient;
using Contracts;
using Contracts.Repository;

namespace Repositories
{


    public class UnitOfWorkADOImpl : UnitOfWork
    {
        protected SqlConnection connection;
        protected SqlTransaction transaction;
        

        private ClienteRepository clienteRepository;
        private VehiculoRepository vehiculoRepository;
        private PresupuestoRepository presupuestoRepository;

        public UnitOfWorkADOImpl(SqlConnection connection)
        {
            this.connection = connection;
            this.clienteRepository = new ClienteRepositoryImpl(this);
            this.vehiculoRepository = new VehiculoRepositoryImpl(this);
            this.presupuestoRepository = new PresupuestoRepositoryImpl(this);
        }
        public SqlCommand CreateCommand(String query)
        {
            SqlCommand command = new SqlCommand();
            //if (transaction == null)
            //   transaction = connection.BeginTransaction();
            command.Connection = this.connection;
            command.Transaction = this.transaction;
            command.CommandText = query;
            return command;
        }

        public void StartProcess()
        {
           // if (connection.State != ConnectionState.Open)
                this.connection.Open();
            this.transaction = connection.BeginTransaction();
        }
        public void EndProcess()
        {
            this.connection.Close();
        }
        public void ConfirmProcess()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
            }
        }
        public void RollbackProcess()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
            }
        }

        public ClienteRepository ClienteRepository
        {
            get { return clienteRepository; }
        }

        public VehiculoRepository VehiculoRepository
        {
            get { return vehiculoRepository; }
        }

        public PresupuestoRepository PresupuestoRepository
        {
            get { return presupuestoRepository; }
        }
    }

}
