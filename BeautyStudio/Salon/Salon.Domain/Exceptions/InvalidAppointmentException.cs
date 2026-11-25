namespace Salon.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidAppointmentException : BaseDomainException
    {
        public InvalidAppointmentException() { }
        public InvalidAppointmentException(string error) => this.Error = error;
    }
}
