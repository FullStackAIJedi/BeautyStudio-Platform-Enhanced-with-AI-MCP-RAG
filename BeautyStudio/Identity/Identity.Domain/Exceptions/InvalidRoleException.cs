namespace Identity.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidRoleException : BaseDomainException
    {
        public InvalidRoleException() { }
        public InvalidRoleException(string error) => this.Error = error;
    }
}
