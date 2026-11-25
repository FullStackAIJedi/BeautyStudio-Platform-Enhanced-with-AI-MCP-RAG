namespace Salon.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidLocationException : BaseDomainException
    {
        public InvalidLocationException() { }
        public InvalidLocationException(string error) => this.Error = error;
    }
}
