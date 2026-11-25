namespace Salon.Domain.Exceptions
{ 
    using SharedKernel.Exceptions;

    public class InvalidServiceException : BaseDomainException
    {
        public InvalidServiceException() { }
        public InvalidServiceException(string error) => this.Error = error;
    }
}
