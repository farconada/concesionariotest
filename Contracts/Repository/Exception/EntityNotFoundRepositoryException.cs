namespace Contracts.Repository.Exception
{
    public class EntityNotFoundRepositoryException : RepositoryException
    {
        public EntityNotFoundRepositoryException()
        {
        }

        public EntityNotFoundRepositoryException(string message) : base(message)
        {
        }

        public EntityNotFoundRepositoryException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}