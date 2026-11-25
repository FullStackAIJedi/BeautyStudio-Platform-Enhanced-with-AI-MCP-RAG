namespace Salon.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidCategoryException : BaseDomainException
    {
        public InvalidCategoryException() { }
        public InvalidCategoryException(string error) => this.Error = error;
    }
}
