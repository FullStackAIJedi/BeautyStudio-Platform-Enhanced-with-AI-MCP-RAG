namespace Identity.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidUserException : BaseDomainException
    {
        public InvalidUserException() { }
        public InvalidUserException(string error) => this.Error = error;
    }
}
