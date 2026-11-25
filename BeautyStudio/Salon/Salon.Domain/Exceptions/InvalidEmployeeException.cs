namespace Salon.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidEmployeeException : BaseDomainException
    {
        public InvalidEmployeeException() { }
        public InvalidEmployeeException(string error) => this.Error = error;
    }
}
