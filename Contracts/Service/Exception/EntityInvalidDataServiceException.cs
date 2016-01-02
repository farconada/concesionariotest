using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Service.Exception
{
    public class EntityInvalidDataServiceException : ServiceException
    {
        public EntityInvalidDataServiceException()
        {
        }

        public EntityInvalidDataServiceException(string message) : base(message)
        {
        }

        public EntityInvalidDataServiceException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
