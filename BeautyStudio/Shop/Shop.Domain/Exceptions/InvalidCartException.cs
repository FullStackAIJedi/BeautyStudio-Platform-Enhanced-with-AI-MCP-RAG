namespace Shop.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidCartException : BaseDomainException
    {
        public InvalidCartException() { }
        public InvalidCartException(string error) => this.Error = error;
    }
}
