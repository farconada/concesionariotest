namespace Contracts.Repository.Exception
{
    public class EditEntityRepositoryException : RepositoryException
    {
        public EditEntityRepositoryException()
        {
        }

        public EditEntityRepositoryException(string message) : base(message)
        {
        }

        public EditEntityRepositoryException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}