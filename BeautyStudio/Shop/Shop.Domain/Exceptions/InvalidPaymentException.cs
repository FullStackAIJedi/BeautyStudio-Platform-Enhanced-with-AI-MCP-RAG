namespace Shop.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidPaymentException : BaseDomainException
    {
        public InvalidPaymentException() { }
        public InvalidPaymentException(string error) => this.Error = error;
    }
}
