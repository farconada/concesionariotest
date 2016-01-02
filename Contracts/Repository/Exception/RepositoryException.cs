namespace Contracts.Repository.Exception
{
    public class RepositoryException : System.Exception
    {
        public RepositoryException()
        {
        }

        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}