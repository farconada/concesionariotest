namespace Contracts.Repository.Exception
{
    public class AddEntityRepositoryException : RepositoryException
    {
        public AddEntityRepositoryException()
        {
        }

        public AddEntityRepositoryException(string message) : base(message)
        {
        }

        public AddEntityRepositoryException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}