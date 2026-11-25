namespace Salon.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidClientException : BaseDomainException
    {
        public InvalidClientException() { }
        public InvalidClientException(string error) => this.Error = error;
    }
}
