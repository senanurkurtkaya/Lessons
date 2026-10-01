namespace ExceptionHandling.API.Exceptions
{
    public class DependencyFailureException : Exception
    {
        public DependencyFailureException()
        {
        }

        public DependencyFailureException(string? message) : base(message)
        {
        }
    }
}
