using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repository;

namespace Repositories
{
    public class UnitOfWorkFactory
    {
        public static UnitOfWork Create()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcesionarioDataSource"].ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=localhost\\MASTERTIC;Initial Catalog=concesionario;Persist Security Info=True;User ID=sa;Password=sa");
            //connection.Open();
            return new UnitOfWorkADOImpl(connection);
        }
    }
}
