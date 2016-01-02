namespace Contracts.Repository.Exception
{
    public class DeleteEntityRepositoryException : RepositoryException
    {
        public DeleteEntityRepositoryException()
        {
        }

        public DeleteEntityRepositoryException(string message) : base(message)
        {
        }

        public DeleteEntityRepositoryException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}