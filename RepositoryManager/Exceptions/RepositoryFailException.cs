namespace RepositoryManager.Exceptions;

public class RepositoryFailWriteException : Exception
{
    public RepositoryFailWriteException()
    {
    }

    public RepositoryFailWriteException(string message)
        : base(message)
    {
    }

    public RepositoryFailWriteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}